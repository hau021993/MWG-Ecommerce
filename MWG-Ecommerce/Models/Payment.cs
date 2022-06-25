using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    [Table("Payment")]
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("PaymentID")]
        public int PaymentId { get; set; }
        [Required]
        [StringLength(50)]
        public string PaymentType { get; set; }
        public bool PaymentStatus { get; set; }

        [InverseProperty(nameof(Order.Payment))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
