using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using PGManagement.Models.Enums.Main;
using PGManagement.BoundedContext.SqlContext;
using RxWeb.Core.Sanitizers.Enums;

namespace PGManagement.Models.Main
{
    [Table("Rentals",Schema="dbo")]
    public partial class Rental
    {
		#region RentalId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion RentalId Annotations

        public int RentalId { get; set; }

		#region RentalCity Annotations

        [Required]
        [MaxLength(50)]
		#endregion RentalCity Annotations

        public string RentalCity { get; set; }

		#region RentalType Annotations

        [Range(1,int.MaxValue)]
        [Required]
		#endregion RentalType Annotations

        public RentalType RentalType { get; set; }

		#region UserId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [OnAction("POST", ActionValueType.NameClaimIdentifier)]
        [RelationshipTableAttribue("Users","dbo","","UserId")]
		#endregion UserId Annotations

        public int UserId { get; set; }


        public Nullable<bool> IsVerfied { get; set; }


        public Nullable<bool> SoftDelete { get; set; }

		#region User Annotations

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(PGManagement.Models.Main.User.Rentals))]
		#endregion User Annotations

        public virtual User User { get; set; }

		#region BookBed Annotations

        [InverseProperty("Rental")]
		#endregion BookBed Annotations

        public virtual ICollection<BookBed> BookBed { get; set; }


        public Rental()
        {
			BookBed = new HashSet<BookBed>();
        }
	}
}