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
using WorldCulture.Api.Helpers;
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
        private readonly ICloudinaryConfiguration _cloudinaryConfiguration;

        public ProfilesController(IAccountService accountService,
            IMapper mapper,
            IRelationService relationService,
            ICloudinaryConfiguration cloudinaryConfiguration)
        {
            _accountService = accountService;
            _mapper = mapper;
            _relationService = relationService;
            _cloudinaryConfiguration = cloudinaryConfiguration;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/profile/{id}")]
        public IActionResult GetProfileData(int id)
        {
            var account = _mapper.Map<AccountForProfileDto>(_accountService.GetAccountByID(id));
            account.Followers = _relationService.GetFollowersCount(id);
            account.Followings = _relationService.GetFollowingsCount(id);
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

        [HttpGet]
        [Authorize(Roles = "Admin,Client")]
        [Route("api/changeToRelationStatus/{id}")]
        public IActionResult ChangeToRelationStatus(int id)
        {
            try
            {
                var currentAccountId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                Relation relation = _relationService.GetRelation(currentAccountId, id);
                if (relation != null)
                {
                    _relationService.Delete(relation);
                    return Ok();
                }
                else
                {
                    _relationService.Add(new Relation
                    {
                        FromAccountID = currentAccountId,
                        ToAccountID = id
                    });
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Authorize]
        [Route("api/changePassword")]
        public IActionResult ChangePassword([FromBody]AccountForChangePasswordDto changePasswordDto)
        {
            if (changePasswordDto.Password != changePasswordDto.ConfirmPassword)
            {
                return BadRequest("Yazdığınız şifreler eşleşmemektedir! Lütfen Tekrar Deneyiniz");
            }

            int currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (!_accountService.ChangePassword(_accountService.GetAccountByID(currentId), changePasswordDto.Password))
            {
                return BadRequest("Yeni şifre eski şifre ile aynı olamaz!");
            }

            return Ok("Şifreniz başarıyla değiştirildi.");
        }

        [HttpPost]
        [Authorize]
        [Route("api/profile/changeProfilePhoto")]
        public IActionResult ChangeProfilePhoto([FromForm]PhotoForUploadDto photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı işlem tespit edildi.");
            }

            if (int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == 0)
            {
                return Unauthorized();
            }

            if (photo.File == null)
            {
                return BadRequest("Gönderilen dosya hatalı");
            }

            CloudinaryForReturnDto cloudinaryForReturn = _cloudinaryConfiguration.UploadImage(photo.File);
            int currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Account account = _accountService.GetAccountByID(currentId);
            account.ProfilePhotoPath = cloudinaryForReturn.Url;
            account.PublicId = cloudinaryForReturn.PublicId;

            _accountService.Update(account);

            return Ok();

        }

        [HttpGet]
        [Authorize]
        [Route("api/profile/getPublicInfo")]
        public IActionResult GetPublicInfo()
        {
            var currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Account account = _accountService.GetAccountByID(currentId);

            AccountForPublicSetting accountForPublic = new AccountForPublicSetting
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                PersonelInfo = account.PersonelInfo,
                BirthDate = account.BirthDate
            };
            return Ok(accountForPublic);
        }

        [HttpPut]
        [Authorize]
        [Route("api/profile/changePublicInfo")]
        public IActionResult ChangePublicInfo([FromBody]AccountForPublicSetting accountForPublic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model uygun değil");
            }

            int currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Account account = _accountService.GetAccountByID(currentId);

            account.BirthDate = accountForPublic.BirthDate;
            account.FirstName = accountForPublic.FirstName;
            account.LastName = accountForPublic.LastName;
            account.PersonelInfo = accountForPublic.PersonelInfo;

            _accountService.Update(account);

            return Ok();
        }

        [HttpGet]
        [Route("api/profile/followers/{id}")]
        public IActionResult GetFollowers(int id)
        {
            List<Account> accounts = new List<Account>();

            List<int> followersId = _relationService.GetFollowerAccountsId(id);

            foreach (var item in followersId)
            {
                accounts.Add(_accountService.GetAccountByID(item));
            }

            List<AccountForProfileDto> followerAccounts = _mapper.Map<List<AccountForProfileDto>>(accounts);

            return Ok(followerAccounts);
        }

        [HttpGet]
        [Route("api/profile/followings/{id}")]
        public IActionResult GetFollowings(int id)
        {
            List<Account> accounts = new List<Account>();

            List<int> followingsId = _relationService.GetFollowingAccountsId(id);

            foreach (var item in followingsId)
            {
                accounts.Add(_accountService.GetAccountByID(item));
            }

            List<AccountForProfileDto> followingAccounts = _mapper.Map<List<AccountForProfileDto>>(accounts);

            return Ok(followingAccounts);
        }
        
        [HttpGet]
        [Route("api/profile/most-follower-accounts")]
        public IActionResult GetMostFollowerAccounts()
        {
            List<AccountForProfileDto> accounts = _mapper.Map<List<AccountForProfileDto>>(_accountService.GetHasMostFollowerAccounts());
            return Ok(accounts);
        }
    }
}