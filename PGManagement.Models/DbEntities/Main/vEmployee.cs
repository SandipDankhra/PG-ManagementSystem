using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using PGManagement.BoundedContext.SqlContext;
namespace PGManagement.Models.Main
{
    [Table("vEmployee",Schema="dbo")]
    public partial class vEmployee
    {
		#region EmployeeId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion EmployeeId Annotations

        public int EmployeeId { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public int Salary { get; set; }


        public System.DateTimeOffset JoinDate { get; set; }


        public string RoleName { get; set; }


        public string Email { get; set; }


        public decimal MobileNumber { get; set; }


        public vEmployee()
        {
        }
	}
}