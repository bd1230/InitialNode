using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Budgeting.Models;

[Table("FOOD_PANTRY_PRICE_HISTORICAL")]
public partial class FoodPantryPriceHistorical
{
    [Key]
    [Column("HISTORICAL_PRICE_ID")]
    public long HistoricalPriceId { get; set; }

    [Column("FOOD_ITEM_ID")]
    public long? FoodItemId { get; set; }

    [Column("ITEM_NAME")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ItemName { get; set; }

    [Column("PRICE", TypeName = "money")]
    public decimal? Price { get; set; }

    [Column("AS_OF_DATE", TypeName = "datetime")]
    public DateTime? AsOfDate { get; set; }

    [ForeignKey("FoodItemId")]
    [InverseProperty("FoodPantryPriceHistoricals")]
    public virtual FoodPantry? FoodItem { get; set; }
}
