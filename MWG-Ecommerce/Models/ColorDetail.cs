using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    public partial class ColorDetail
    {
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Key]
        [Column("ColorID")]
        public int ColorId { get; set; }

        [ForeignKey(nameof(ColorId))]
        [InverseProperty("ColorDetails")]
        public virtual Color Color { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ColorDetails")]
        public virtual Product Product { get; set; }
    }
}
