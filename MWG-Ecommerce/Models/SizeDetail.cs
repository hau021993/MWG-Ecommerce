using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    public partial class SizeDetail
    {
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Key]
        [Column("SizeID")]
        public int SizeId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("SizeDetails")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(SizeId))]
        [InverseProperty("SizeDetails")]
        public virtual Size Size { get; set; }
    }
}
