using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RxWeb.Core;
using PGManagement.UnitOfWork.Main;
using PGManagement.Models.ViewModels;
using Microsoft.Data.SqlClient;
using RxWeb.Core.Data;
using PGManagement.BoundedContext.Main;
using PGManagement.BoundedContext.SqlContext;
using PGManagement.Models.Main;

namespace PGManagement.Domain.MasterModule
{
    public class CreateBookBedDomain : ICreateBookBedDomain
    {
        private IDbContextManager<MainSqlDbContext> DbContextManager { get; set; }
        
        public CreateBookBedDomain(IMasterUow uow, IDbContextManager<MainSqlDbContext> dbContextManager) {
            this.Uow = uow;
            DbContextManager = dbContextManager;
        }

        public async Task<object> GetAsync(CreateBookBed parameters)
        {
            return await Uow.Repository<vBookBed>().AllAsync();
            //throw new NotImplementedException();
        }

        public async Task<object> GetBy(CreateBookBed parameters)
        {
              return await Uow.Repository<vBookBed>().FindByAsync(t=>t.UserId==parameters.UserId);
              //return await Uow.Repository<vBookBed>().FirstOrDefaultAsync(t=>t.UserId==parameters.UserId);
            //throw new NotImplementedException();
        }


        public HashSet<string> AddValidation(CreateBookBed entity)
        {
            return ValidationMessages;
        }

        public async Task AddAsync(CreateBookBed entity)
        {
            await DbContextManager.BeginTransactionAsync();
            try
            {
                var spParameters = new SqlParameter[8];
                spParameters[0] = new SqlParameter() { ParameterName = "userId", Value = entity.UserId };
                spParameters[1] = new SqlParameter() { ParameterName = "rentalCity", Value = entity.RentalCity };
                spParameters[2] = new SqlParameter() { ParameterName = "rentalType", Value = entity.RentalType };
                spParameters[3] = new SqlParameter() { ParameterName = "paymentType", Value = entity.PaymentTypeId };
                spParameters[4] = new SqlParameter() { ParameterName = "paymentAmount", Value = entity.PaymentAmount };
                spParameters[5] = new SqlParameter() { ParameterName = "bedId", Value = entity.BedId };
                spParameters[6] = new SqlParameter() { ParameterName = "startDate", Value = entity.StartDate };
                spParameters[7] = new SqlParameter() { ParameterName = "endDate", Value = entity.EndDate };
                await DbContextManager.StoreProc<StoreProcResult>("[dbo].spBookBed ", spParameters);
                 await DbContextManager.CommitAsync();
                UserRole userRole = new UserRole() { UserId =entity.UserId, RoleId = 3 };
                await Uow.RegisterNewAsync(userRole);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                DbContextManager.RollbackTransaction();
            }
           
        }

        public HashSet<string> UpdateValidation(CreateBookBed entity)
        {
            return ValidationMessages;
        }

        public async Task UpdateAsync(CreateBookBed entity)
        {
            await Uow.RegisterDirtyAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> DeleteValidation(CreateBookBed parameters)
        {
            return ValidationMessages;
        }

        public async Task DeleteAsync(CreateBookBed parameters)
        {
            var candidate = Uow.Repository<BookBed>().FindByKey(parameters.BookBedId);
            await Uow.RegisterDeletedAsync(candidate);
            await Uow.CommitAsync();
            //await Uow.Repository<CreateBookBed>().FindByAsync(a => a.BedId == parameters.BedId);
            //throw new NotImplementedException();
        }

      

        public IMasterUow Uow { get; set; }

        private HashSet<string> ValidationMessages { get; set; } = new HashSet<string>();
    }

    public interface ICreateBookBedDomain : ICoreDomain<CreateBookBed, CreateBookBed> { }
}
