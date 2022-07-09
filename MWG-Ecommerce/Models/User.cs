using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    [Index(nameof(Username), Name = "IX_Users", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            LoginHistories = new HashSet<LoginHistory>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Passwword { get; set; }
        [StringLength(50)]
        public string Sex { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(20)]
        public string Email { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        public bool Role { get; set; }
        [StringLength(10)]
        public string Status { get; set; }

        [InverseProperty(nameof(LoginHistory.User))]
        public virtual ICollection<LoginHistory> LoginHistories { get; set; }
        [InverseProperty(nameof(Order.User))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
