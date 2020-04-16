using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PGManagement.UnitOfWork.Main;
using PGManagement.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace PGManagement.Api.Controllers.UserModule
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Access(8)]

    public class FlatController : BaseController<Flat,Flat,Flat>

    {
        public FlatController(IMasterUow uow):base(uow) {}

    }
}
