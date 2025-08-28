using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


public class WCCContext: DbContext {

    public static readonly string DbName = "WasteCostCalculator.db";

    public DbSet<Food> Foods {
        get; set;
    }

    public DbSet<Waste> Waste {
        get; set;
    }

    public string DbPath {
        get;
    }

    public WCCContext() {
        DbPath = AppDomain.CurrentDomain.BaseDirectory+DbName;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    //this force the food name to be unique, it can't be done on the class decaration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Food>().HasIndex(f => f.Name).IsUnique();
}

public class Food {
    public int FoodId {
        get; set;
    }
    /* The name needs to be unique but not a key, the atribute "[Index(isUnique = true)]" doesn't work
     * it may be a SQLite problem
     * it's made unique by the method OnModelCreating(ModelBuilder modelBuilder)
     */
    [Required]
    public required string Name {
        get; set;
    }
    [Required]
    public  float Cost {
        get; set;
    }
    //this could become a table, but it adds unnecessary complexity
    [Required]
    public required string MeasurementUnit {
        get; set;
    }

    public ListViewItem toListViewItem() {
        ListViewItem item = new ListViewItem(Name);
        item.SubItems.Add(Cost.ToString());
        item.SubItems.Add(MeasurementUnit.ToString());
        return item;
    }
}

/* the combo FoodId-Date could be made unique
 * but there is a "Reason" field, so i prefer to leave them non unique
 */
public class Waste {
    public int WasteId {
        get; set;
    }
    [ForeignKey("Food")]
    public int FoodId {
        get; set;
    }
    [Required]
    public float QuantityWasted {
        get; set;
    }
    [Required]
    [Column(TypeName = "Date")]
    public required string Date {
        get; set;
    }
    [Required]
    public float FoodCostAtWasteDate {
        get; set;
    }

    public string? Reason {
        get; set;
    }

}
public class WasteHelper {

    public int WasteID {
        get; set;
    }

    public string? FoodName {
        get; set;
    }
    public float QuantityWasted {
        get; set;
    }
    public float TotalCost {
        get; set;
    }

    public ListViewItem toListViewItem() {
        ListViewItem item = new ListViewItem(FoodName);
        item.SubItems.Add(QuantityWasted.ToString());
        item.SubItems.Add(TotalCost.ToString());
        item.SubItems.Add(WasteID.ToString());//this is added but never showed, it makes easier to retrive wastes from DB while selecting a waste from a listbox
        return item;
    }
}

public class ArrangedWastes {
    public float TotalCost {
        get; set;
    }
    public required string Date {
        get; set;
    }
    public ListViewItem toListViewItem() {
        ListViewItem item = new ListViewItem(Date);
        item.SubItems.Add(TotalCost.ToString());
        return item;
    }
}