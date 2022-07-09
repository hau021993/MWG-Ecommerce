using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            ColorDetails = new HashSet<ColorDetail>();
            DiscountDetails = new HashSet<DiscountDetail>();
            OrderDetails = new HashSet<OrderDetail>();
            SizeDetails = new HashSet<SizeDetail>();
        }

        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("ColorID")]
        public int? ColorId { get; set; }
        [Column("SizeID")]
        public int? SizeId { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(150)]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(150)]
        public string Picture { get; set; }
        public int QuanlityInStock { get; set; }
        [StringLength(50)]
        public string Warranty { get; set; }
        public int? Views { get; set; }
        [StringLength(50)]
        public string Note { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("Products")]
        public virtual Supplier Supplier { get; set; }
        [InverseProperty(nameof(ColorDetail.Product))]
        public virtual ICollection<ColorDetail> ColorDetails { get; set; }
        [InverseProperty(nameof(DiscountDetail.Product))]
        public virtual ICollection<DiscountDetail> DiscountDetails { get; set; }
        [InverseProperty(nameof(OrderDetail.Product))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [InverseProperty(nameof(SizeDetail.Product))]
        public virtual ICollection<SizeDetail> SizeDetails { get; set; }
    }
}
