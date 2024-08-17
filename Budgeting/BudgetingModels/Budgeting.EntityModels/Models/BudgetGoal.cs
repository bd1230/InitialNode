using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Budgeting.Models;

[Table("BUDGET_GOAL")]
public partial class BudgetGoal
{
    [Key]
    [Column("BUDGET_GOAL_ID")]
    public long BudgetGoalId { get; set; }

    [Column("BUDGET_GOAL_AMOUNT", TypeName = "money")]
    public decimal? BudgetGoalAmount { get; set; }

    [Column("DAILY_PROGRESS")]
    [StringLength(10)]
    public string DailyProgress { get; set; } = null!;

    [Column("MONTHLY_PROGRESS", TypeName = "money")]
    public decimal? MonthlyProgress { get; set; }

    [Column("GOAL_DATE", TypeName = "money")]
    public decimal? GoalDate { get; set; }

    [Column("PROJECTED_GOAL_COMPLETION", TypeName = "datetime")]
    public DateTime? ProjectedGoalCompletion { get; set; }

    [Column("BUDGET_ID")]
    public long? BudgetId { get; set; }

    [Column("CURRENT_AMOUNT_SAVED", TypeName = "money")]
    public decimal? CurrentAmountSaved { get; set; }

    [Column("PERCENT_COMPLETE", TypeName = "decimal(18, 0)")]
    public decimal? PercentComplete { get; set; }

    [ForeignKey("BudgetId")]
    [InverseProperty("BudgetGoals")]
    public virtual Budget? Budget { get; set; }
}
