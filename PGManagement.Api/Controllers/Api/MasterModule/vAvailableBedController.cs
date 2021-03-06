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
    [Access(18)]
    public class vAvailableBedController : BaseDomainController<vAvailableBed, vAvailableBed>

    {
        public vAvailableBedController(IvAvailableBedDomain domain):base(domain) {}

    }
}
