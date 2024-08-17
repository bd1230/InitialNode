using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Budgeting.Models;

[Table("BUDGET")]
public partial class Budget
{
    [Key]
    [Column("BUDGET_ID")]
    public long BudgetId { get; set; }

    [Column("USER_ID")]
    public long? UserId { get; set; }

    [Column("TOTAL_SPENDING", TypeName = "money")]
    public decimal? TotalSpending { get; set; }

    [Column("TOTAL_REVENUE", TypeName = "money")]
    public decimal? TotalRevenue { get; set; }

    [InverseProperty("Budget")]
    public virtual ICollection<BudgetGoal> BudgetGoals { get; set; } = new List<BudgetGoal>();

    [ForeignKey("UserId")]
    [InverseProperty("Budgets")]
    public virtual User? User { get; set; }
}
