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
    [Access(11)]
    public class noticesController : BaseDomainController<Notice,vNotice>

    {
        public noticesController(InoticeDomain domain):base(domain) {}

    }
}
