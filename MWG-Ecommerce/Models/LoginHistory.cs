using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MWG_Ecommerce.Models
{
    [Table("LoginHistory")]
    public partial class LoginHistory
    {
        [Key]
        [Column("HistoryID")]
        public int HistoryId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Time { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("LoginHistories")]
        public virtual User User { get; set; }
    }
}
