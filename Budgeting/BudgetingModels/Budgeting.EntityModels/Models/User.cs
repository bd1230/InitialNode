using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Budgeting.Models;

[Table("USERS")]
public partial class User
{
    [Key]
    [Column("USER_ID")]
    public long UserId { get; set; }

    [Column("DATE_ADDED", TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    [Column("USER_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UserName { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    [InverseProperty("User")]
    public virtual ICollection<SpendingRecurring> SpendingRecurrings { get; set; } = new List<SpendingRecurring>();

    [InverseProperty("User")]
    public virtual ICollection<Spending> Spendings { get; set; } = new List<Spending>();
}
