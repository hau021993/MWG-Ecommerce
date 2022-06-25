using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    [Table("Color")]
    public partial class Color
    {
        public Color()
        {
            ColorDetails = new HashSet<ColorDetail>();
        }

        [Key]
        [Column("ColorID")]
        public int ColorId { get; set; }
        [Required]
        [Column("Color")]
        [StringLength(50)]
        public string Color1 { get; set; }

        [InverseProperty(nameof(ColorDetail.Color))]
        public virtual ICollection<ColorDetail> ColorDetails { get; set; }
    }
}
