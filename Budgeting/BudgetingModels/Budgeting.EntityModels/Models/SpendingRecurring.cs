using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Budgeting.Models;

[Table("SPENDING_RECURRING")]
public partial class SpendingRecurring
{
    [Key]
    [Column("RECURRING_SPENDING_ITEM_ID")]
    public long RecurringSpendingItemId { get; set; }

    [Column("MONTHLY_SPEND", TypeName = "money")]
    public decimal? MonthlySpend { get; set; }

    [Column("MONTHLY_SPEND_C", TypeName = "money")]
    public decimal MonthlySpendC { get; set; }

    [Column("YEARLY_SPEND", TypeName = "money")]
    public decimal? YearlySpend { get; set; }

    [Column("YEARLY_SPEND_C", TypeName = "money")]
    public decimal YearlySpendC { get; set; }

    [Column("USER_ID")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("SpendingRecurrings")]
    public virtual User User { get; set; } = null!;
}
