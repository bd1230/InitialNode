using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Budgeting.Models;

[Table("SPENDING")]
[Index("SpendingItemId", "UserId", Name = "AK_SPENDING_SPEND_USER", IsUnique = true)]
public partial class Spending
{
    [Key]
    [Column("SPENDING_ITEM_ID")]
    public long SpendingItemId { get; set; }

    [Column("SOURCE")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Source { get; set; }

    [Column("DATE", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("CATEGORY")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Category { get; set; }

    [Column("USER_ID")]
    public long UserId { get; set; }

    [InverseProperty("Spending")]
    public virtual ICollection<FoodPantry> FoodPantries { get; set; } = new List<FoodPantry>();

    [ForeignKey("UserId")]
    [InverseProperty("Spendings")]
    public virtual User User { get; set; } = null!;
}
