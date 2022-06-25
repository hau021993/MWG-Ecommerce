using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    [Table("Size")]
    public partial class Size
    {
        public Size()
        {
            SizeDetails = new HashSet<SizeDetail>();
        }

        [Key]
        [Column("SizeID")]
        public int SizeId { get; set; }
        [Required]
        [Column("Size")]
        [StringLength(50)]
        public string Size1 { get; set; }

        [InverseProperty(nameof(SizeDetail.Size))]
        public virtual ICollection<SizeDetail> SizeDetails { get; set; }
    }
}
