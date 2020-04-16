using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PGManagement.UnitOfWork.Main;
using PGManagement.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace PGManagement.Api.Controllers.MasterModule
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Access(13)]

    public class RentalController : BaseController<Rental, vRentalRecord, vRentalRecord>

    {
        public RentalController(IMasterUow uow):base(uow) {}

    }
}
