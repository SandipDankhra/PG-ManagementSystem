using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using PGManagement.BoundedContext.SqlContext;
namespace PGManagement.Models.Main
{
    [Table("vRequestLookup",Schema="dbo")]
    public partial class vRequestLookup
    {
		#region RequesterId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion RequesterId Annotations

        public int RequesterId { get; set; }


        public string locality { get; set; }


        public string FlatNumber { get; set; }


        public int RoomType { get; set; }


        public string RoomSharing { get; set; }


        public int BedId { get; set; }


        public bool BedStatus { get; set; }


        public vRequestLookup()
        {
        }
	}
}