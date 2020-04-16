using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PGManagement.UnitOfWork.Main;
using PGManagement.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;
using PGManagement.Domain.MasterModule;
using Microsoft.AspNetCore.Authorization;

namespace PGManagement.Api.Controllers.MasterModule
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Access(7)]
    public class ExpenseController : BaseController<Expens,vExpense, Expens>

    {
        public ExpenseController(IMasterUow uow):base(uow) {}

    }
}
