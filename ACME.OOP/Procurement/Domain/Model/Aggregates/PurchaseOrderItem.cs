using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;

public class PurchaseOrderItem(ProductID productID, int quantity, Money unitPrice )
{
    public ProductID ProductID { get; } = productID ?? throw new ArgumentNullException(nameof(productID));
    public int Quantity { get; } = quantity > 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity));
    public Money UnitPrice { get; } = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
    
    public Money CalculateSubtotal() => new(quantity * unitPrice.Amount, unitPrice.Currency);
    
}