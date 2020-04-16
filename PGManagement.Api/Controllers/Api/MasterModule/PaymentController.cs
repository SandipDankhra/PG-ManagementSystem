using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PGManagement.UnitOfWork.Main;
using PGManagement.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;

namespace PGManagement.Api.Controllers.UserModule
{
    [ApiController]
    [Route("api/[controller]")]
    [Access(12)]
    public class PaymentController : BaseController<Payment,Payment,Payment>

    {
        public PaymentController(IMasterUow uow):base(uow) {}

    }
}
