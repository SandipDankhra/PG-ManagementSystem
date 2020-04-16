using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using PGManagement.BoundedContext.SqlContext;
namespace PGManagement.Models.Main
{
    [Table("vEmployeeRecord",Schema="dbo")]
    public partial class vEmployeeRecord
    {
		#region UserId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion UserId Annotations

        public int UserId { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public int Salary { get; set; }


        public string RoleName { get; set; }


        public string DocumentUrl { get; set; }


        public System.DateTimeOffset JoinDate { get; set; }


        public string Email { get; set; }


        public decimal MobileNumber { get; set; }


        public string ApplicationObjectName { get; set; }


        public vEmployeeRecord()
        {
        }
	}
}