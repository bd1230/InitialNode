using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Budgeting.Models;

public partial class Budgeting : DbContext
{
    public Budgeting()
    {
    }

    public Budgeting(DbContextOptions<Budgeting> options)
        : base(options)
    {
    }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<BudgetGoal> BudgetGoals { get; set; }

    public virtual DbSet<FoodPantry> FoodPantries { get; set; }

    public virtual DbSet<FoodPantryPriceHistorical> FoodPantryPriceHistoricals { get; set; }

    public virtual DbSet<Spending> Spendings { get; set; }

    public virtual DbSet<SpendingRecurring> SpendingRecurrings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Budgeting;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Budget>(entity =>
        {
            entity.HasKey(e => e.BudgetId).HasName("PK__BUDGET__8AD87462DD749B9A");

            entity.HasOne(d => d.User).WithMany(p => p.Budgets).HasConstraintName("FK_BUDGET_USERS");
        });

        modelBuilder.Entity<BudgetGoal>(entity =>
        {
            entity.HasKey(e => e.BudgetGoalId).HasName("PK__BUDGET_G__A3C72FB8585BC051");

            entity.Property(e => e.DailyProgress).IsFixedLength();

            entity.HasOne(d => d.Budget).WithMany(p => p.BudgetGoals).HasConstraintName("FK_BUDGET_GOAL_BUDGET");
        });

        modelBuilder.Entity<FoodPantry>(entity =>
        {
            entity.HasKey(e => e.FoodItemId).HasName("PK__FOOD_PAN__B2AE5D7C9CA663BE");

            entity.ToTable("FOOD_PANTRY", tb => tb.HasTrigger("TRG_FOOD_PANTRY_IU"));

            entity.HasOne(d => d.Spending).WithMany(p => p.FoodPantries)
                .HasPrincipalKey(p => new { p.SpendingItemId, p.UserId })
                .HasForeignKey(d => new { d.SpendingItemId, d.UserId })
                .HasConstraintName("FK_FOOD_PANTRY_SPENDING");
        });

        modelBuilder.Entity<FoodPantryPriceHistorical>(entity =>
        {
            entity.HasKey(e => e.HistoricalPriceId).HasName("PK__FOOD_PAN__C400719725E5C2D9");

            entity.HasOne(d => d.FoodItem).WithMany(p => p.FoodPantryPriceHistoricals).HasConstraintName("FK_FOOD_PANTRY_PRICE_HISTORICAL_FOOD_PANTRY");
        });

        modelBuilder.Entity<Spending>(entity =>
        {
            entity.HasKey(e => e.SpendingItemId).HasName("PK__SPENDING__79B5F5510C9EF882");

            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Spendings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SPENDING_USERS");
        });

        modelBuilder.Entity<SpendingRecurring>(entity =>
        {
            entity.HasKey(e => e.RecurringSpendingItemId).HasName("PK__SPENDING__79B5F55119EE1EE4");

            entity.Property(e => e.MonthlySpendC).HasComputedColumnSql("(isnull([YEARLY_SPEND]/(12),(0)))", true);
            entity.Property(e => e.YearlySpendC).HasComputedColumnSql("(isnull([MONTHLY_SPEND]*(12),(0)))", true);

            entity.HasOne(d => d.User).WithMany(p => p.SpendingRecurrings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SPENDING_RECURRING_USERS");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__F3BEEBFF40FB1782");

            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
