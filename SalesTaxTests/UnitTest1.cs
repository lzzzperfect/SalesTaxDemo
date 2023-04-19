using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json.Linq;
using SalesTax.Models;
using SalesTax.Services;

namespace SalesTaxTests;

[TestClass]
public class TaxServiceUnitTests
{
    private TaxService TaxService;

    [TestInitialize]
    public void testInit()
    {
        this.TaxService = new TaxService();
    }

    [TestMethod]
    public void TestItemTax()
    {
        Item item1 = new Item() { Count = 1, Kind = Kind.Book, Name = "book1", UnitPrice = 12.49m };
        Item item2 = new Item() { Count = 1, Kind = Kind.Default, Name = "music CD", UnitPrice = 14.99m };
        Item item3 = new Item() { Count = 1, Kind = Kind.Food, Name = "chocolate bar", UnitPrice = 0.85m };
        List<Item> items = new List<Item>() { item1, item2, item3 };

        
        var result = this.TaxService.CalculateTax(items);
        Assert.AreEqual(3, result.PaidItems.Count);
        Assert.AreEqual(1.50m, result.SalesTax);
        Assert.AreEqual(29.83m, result.Total);
    }

    [TestMethod]
    public void TestImportItemTax()
    {
        Item item1 = new Item() { Count = 1, IsImport = true, Kind = Kind.Food, Name = "chocolates", UnitPrice = 10.00m };
        Item item2 = new Item() { Count = 1, IsImport = true, Kind = Kind.Default, Name = "perfume", UnitPrice = 47.50m };
        List<Item> items = new List<Item>() { item1, item2 };


        var result = this.TaxService.CalculateTax(items);
        Assert.AreEqual(2, result.PaidItems.Count);
        Assert.AreEqual(7.65m, result.SalesTax);
        Assert.AreEqual(65.15m, result.Total);
    }

    [TestMethod]
    public void TestMixedItemTax()
    {
        Item item1 = new Item() { Count = 1, Kind = Kind.Medical, Name = "headache pills", UnitPrice = 9.75m };
        Item item2 = new Item() { Count = 1, IsImport = true, Kind = Kind.Default, Name = "perfume", UnitPrice = 27.99m };
        Item item3 = new Item() { Count = 1, Kind = Kind.Default, Name = "perfume", UnitPrice = 18.99m };
        Item item4 = new Item() { Count = 1, IsImport = true, Kind = Kind.Food, Name = "chocolates", UnitPrice = 11.25m };
        List<Item> items = new List<Item>() { item1, item2, item3, item4 };

        var result = this.TaxService.CalculateTax(items);
        Assert.AreEqual(4, result.PaidItems.Count);
        Assert.AreEqual(6.70m, result.SalesTax);
        Assert.AreEqual(74.68m, result.Total);
    }

    [TestMethod]
    public void TestMultipleSameItemTax()
    {
        Item item1 = new Item() { Count = 10, Kind = Kind.Medical, Name = "headache pills", UnitPrice = 10.00m };
        Item item2 = new Item() { Count = 1, IsImport = true, Kind = Kind.Default, Name = "perfume", UnitPrice = 100.00m };

        List<Item> items = new List<Item>() { item1, item2 };

        var result = this.TaxService.CalculateTax(items);
        Assert.AreEqual(2, result.PaidItems.Count);
        Assert.AreEqual(10, result.PaidItems[0].Count);
        Assert.AreEqual(15m, result.SalesTax);
        Assert.AreEqual(215m, result.Total);
    }
}
