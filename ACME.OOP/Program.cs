using ACME.OOP.Procurement.Domain.Model.Aggregates;
using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.Aggregates;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

var suplierAddres = new Address("Main St", "123456", "New York", "New York", "NY", "USA");
var supplier = new Supplier("SUP0001","Microsfot, Inc", suplierAddres);

// Create a purchaseorder object
var purchaseorder = new PurchaseOrder("P0001",new SupplierId(supplier.Identifier),"USD");
purchaseorder.AddItem(ProductID.New(), 10,25.99m);
purchaseorder.AddItem(ProductID.New(), 5,15.99m);

// Display the purchase order details
Console.WriteLine($"Purchase Order ID: {purchaseorder.OrderNumber} created on {purchaseorder.OrderDate} for supplier {supplier.Name}");
foreach (var item in purchaseorder.Items)
{
    var itemSubtotal = item.CalculateSubtotal();
    Console.WriteLine($"Item Subtotal: {itemSubtotal.Amount:C} {itemSubtotal.Currency}");
}

var total = purchaseorder.CalculateSubtotal();
Console.WriteLine($"Total Subtotal: {total.Amount:C} {total.Currency}");

