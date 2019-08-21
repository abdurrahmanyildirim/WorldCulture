using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCulture.Api.Dtos;
using WorldCulture.Business.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ProfilesController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IRelationService _relationService;

        public ProfilesController(IAccountService accountService,
            IMapper mapper,
            IRelationService relationService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _relationService = relationService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/profile/{id}")]
        public IActionResult GetProfileData(int id)
        {
            var account = _mapper.Map<AccountForProfileDto>(_accountService.GetAccountByID(id));
            return Ok(account);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Client")]
        [Route("api/isFollower/{id}")]
        public IActionResult GetRelationStatus(int id)
        {
            var currentAccountId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok(_relationService.isFollower(currentAccountId, id));
        }

        [HttpPost]
        [Authorize]
        [Route("api/changeToRelationStatus/{id}")]
        public IActionResult ChangeToRelationStatus(int id)
        {
            try
            {
                var currentAccountId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                Relation relation = _relationService.GetRelation(id, currentAccountId);
                if (relation != null)
                {
                    _relationService.Delete(relation);
                    return Ok();
                }
                else
                {
                    _relationService.Add(new Relation
                    {
                        FromAccountID = id,
                        ToAccountID = currentAccountId
                    });
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}