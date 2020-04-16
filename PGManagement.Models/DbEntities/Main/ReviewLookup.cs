using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using PGManagement.BoundedContext.SqlContext;
namespace PGManagement.Models.Main
{
    [Table("ReviewLookup",Schema="dbo")]
    public partial class ReviewLookup
    {
		#region ReviewId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion ReviewId Annotations

        public int ReviewId { get; set; }


        public int Rating { get; set; }


        public string ReviewDescription { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public ReviewLookup()
        {
        }
	}
}