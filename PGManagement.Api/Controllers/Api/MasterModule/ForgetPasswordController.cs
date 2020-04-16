using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PGManagement.Domain.MasterModule;
using PGManagement.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace PGManagement.Api.Controllers.MasterModule
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [Access(9)]
    public class ForgetPasswordController : BaseDomainController<Authentication, Authentication>

    {
        public ForgetPasswordController(IForgetPasswordDomain domain):base(domain) {}

    }
}
