using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WorldCulture.Api.Dtos;
using WorldCulture.Business.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Api.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

        public AuthController(IAccountService accountService,
            IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("api/auth/Login")]
        public IActionResult Login([FromBody]AccountForLoginDto accountLogin)
        {
            var account = _accountService.Login(accountLogin.Email, accountLogin.Password);

            if (account == null)
            {
                return Unauthorized();
            }

            string role = _accountService.GetRoleByAccountID(account.AccountID);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, account.AccountID.ToString()),
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(ClaimTypes.Role, role),
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                    , SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
        }

        [HttpPost]
        [Route("api/auth/Register")]
        public IActionResult Register([FromBody]AccountForRegisterDto userForRegisterDto)
        {
            if (_accountService.UserExists(userForRegisterDto.Email))
            {
                ModelState.AddModelError("Email", "Bu mail adresi başka bir kişi tarafından kullanılmaktadır.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToCreate = new Account
            {
                RoleID = 2,
                IsActive = true,
                LastName = userForRegisterDto.LastName,
                FirstName = userForRegisterDto.FirstName,
                MemberDate = DateTime.Now,
                Email = userForRegisterDto.Email,
                BirthDate = userForRegisterDto.BirthDate,
                UserName = userForRegisterDto.Email
            };

            _accountService.Register(userToCreate, userForRegisterDto.Password);

            return Ok();
        }
    }
}