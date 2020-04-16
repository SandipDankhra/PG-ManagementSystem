using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using PGManagement.Models.Enums.Main;
using PGManagement.BoundedContext.SqlContext;
namespace PGManagement.Models.Main
{
    [Table("Reviews",Schema="dbo")]
    public partial class Review
    {
		#region ReviewId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion ReviewId Annotations

        public int ReviewId { get; set; }

		#region Rating Annotations

        [Range(1, int.MaxValue)]
        [Required]
		#endregion Rating Annotations

        public int Rating { get; set; }


        public string ReviewDescription { get; set; }

		#region RentalId Annotations

        [Range(1, int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Users","dbo","","RentalId")]
		#endregion RentalId Annotations

        public int RentalId { get; set; }

		#region User Annotations

        [ForeignKey(nameof(RentalId))]
        [InverseProperty(nameof(PGManagement.Models.Main.User.Reviews))]
		#endregion User Annotations

        public virtual User User { get; set; }


        public Review()
        {
        }
	}
}