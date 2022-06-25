using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    [Table("Discount")]
    public partial class Discount
    {
        public Discount()
        {
            DiscountDetails = new HashSet<DiscountDetail>();
        }

        [Key]
        [Column("DiscountID")]
        public int DiscountId { get; set; }
        [StringLength(255)]
        public string DiscountContent { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal DiscountPrice { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartTime { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }

        [InverseProperty(nameof(DiscountDetail.Discount))]
        public virtual ICollection<DiscountDetail> DiscountDetails { get; set; }
    }
}
