using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Budgeting.Models;

[Table("FOOD_PANTRY")]
[Index("FoodItemId", "UserId", Name = "IX_FOOD_PANTRY_USER_FOOD")]
public partial class FoodPantry
{
    [Key]
    [Column("FOOD_ITEM_ID")]
    public long FoodItemId { get; set; }

    [Column("ITEM_NAME")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ItemName { get; set; }

    [Column("ITEM_DESCRIPTION")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? ItemDescription { get; set; }

    [Column("MOST_RECENT_PRICE", TypeName = "money")]
    public decimal? MostRecentPrice { get; set; }

    [Column("MOST_RECENT_PURCHASE_DATE", TypeName = "datetime")]
    public DateTime? MostRecentPurchaseDate { get; set; }

    [Column("USE_BY", TypeName = "datetime")]
    public DateTime? UseBy { get; set; }

    [Column("EXPIRATION_DATE", TypeName = "datetime")]
    public DateTime? ExpirationDate { get; set; }

    [Column("USER_ID")]
    public long? UserId { get; set; }

    [Column("SPENDING_ITEM_ID")]
    public long? SpendingItemId { get; set; }

    [InverseProperty("FoodItem")]
    public virtual ICollection<FoodPantryPriceHistorical> FoodPantryPriceHistoricals { get; set; } = new List<FoodPantryPriceHistorical>();

    [ForeignKey("SpendingItemId, UserId")]
    [InverseProperty("FoodPantries")]
    public virtual Spending? Spending { get; set; }
}
