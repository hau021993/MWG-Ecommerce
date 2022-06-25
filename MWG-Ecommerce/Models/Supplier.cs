using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Note { get; set; }

        [InverseProperty(nameof(Product.Supplier))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
