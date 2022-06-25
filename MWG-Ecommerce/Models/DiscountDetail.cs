using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    public partial class DiscountDetail
    {
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Key]
        [Column("DiscountID")]
        public int DiscountId { get; set; }

        [ForeignKey(nameof(DiscountId))]
        [InverseProperty("DiscountDetails")]
        public virtual Discount Discount { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("DiscountDetails")]
        public virtual Product Product { get; set; }
    }
}
