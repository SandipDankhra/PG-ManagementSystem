using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PGManagement.Infrastructure.Security;
using PGManagement.Models.Main;
using PGManagement.Models.ViewModels;
using PGManagement.UnitOfWork.Main;
using RxWeb.Core.Security.Cryptography;
using System;
using System.Linq;
using System.Threading.Tasks;
using RxWeb.Core.Security.Filters;
using System.Collections.Generic;
using System.Collections;

namespace PGManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private ILoginUow LoginUow { get; set; }
        private IApplicationTokenProvider ApplicationTokenProvider { get; set; }
        private IPasswordHash PasswordHash { get; set; }

        public AuthenticationController(ILoginUow loginUow, IApplicationTokenProvider tokenProvider, IPasswordHash passwordHash)
        {
            this.LoginUow = loginUow;
            ApplicationTokenProvider = tokenProvider;
            PasswordHash = passwordHash;
        }

        [HttpGet]
        [AllowAnonymous]
        [AllowRequest(MaxRequestCountPerIp = 100)]
        public async Task<IActionResult> Get()
        {
            var token = await ApplicationTokenProvider.GetTokenAsync(new vUser { UserId = 0, ApplicationTimeZoneName = string.Empty, LanguageCode = string.Empty });
            return Ok(token);
        }

        [HttpPost]
        //[AllowAnonymousUser]
        [AllowAnonymous]
        public async Task<IActionResult> Post(AuthenticationModel authentication)
        {

            var user = await LoginUow.Repository<vUser>().SingleOrDefaultAsync(t => t.Email == authentication.Email && !t.LoginBlocked);
            if (user != null && PasswordHash.VerifySignature(authentication.Password, user.Password, user.Salt))
            {
                var token = await ApplicationTokenProvider.GetTokenAsync(user);
                Dictionary<string,Object> userInfo = new Dictionary<string,Object>();
                userInfo.Add("userrole",LoginUow.Repository<UserRole>().FindBy(t => t.UserId == user.UserId).ToList());
                userInfo.Add("username", user.FirstName);
                userInfo.Add("token", token);
                userInfo.Add("userid", user.UserId);
                return Ok(userInfo);
            }
            else
                return BadRequest();
        }
    }
}

