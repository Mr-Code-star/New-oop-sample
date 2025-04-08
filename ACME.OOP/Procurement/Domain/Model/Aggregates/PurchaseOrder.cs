using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;

/// <summary>
///  This class represents a purchase order aggregate roat for the procurement bounded context
/// </summary>
/// <param name="orderNumber">The uninque identifier for the purchase order</param>
/// <param name="supplierId">The unique identifier for the suplier. See</param>
/// <param name="orderDate"></param>
/// <param name="currency"></param>
public class PurchaseOrder(string orderNumber, SupplierId supplierId, DateTime orderDate, string currency)
{
    private readonly List<PurchaseOrderItem> _items = [];
    public string OrderNumber { get; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId SupplierID { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;
    public string Currency { get; } =string.IsNullOrEmpty(currency) || 
                                     currency.Length != 3 ?
        throw new ArgumentOutOfRangeException("Currency must be 3 a-letter ISO code.", nameof(currency))
        : currency;
    
    public IReadOnlyList<PurchaseOrderItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Constructor for creating a new purchase order with a specifict order number SuplierID, and currency
    /// </summary>
    /// <param name="orderNumber"></param>
    /// <param name="supplierId"></param>
    /// <param name="currency"></param>
    
    public PurchaseOrder(string orderNumber, SupplierId supplierId, string currency) :
        this(orderNumber, supplierId, DateTime.UtcNow, currency)
    {
    }
    
    /// <summary>
    ///  Adds an item to the purchase order. aggregate
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    /// <param name="unitPriceMount"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>

    public void AddItem(ProductID productId, int quantity, decimal unitPriceMount)
    {
        ArgumentNullException.ThrowIfNull(productId, nameof(productId));
        if(quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if(unitPriceMount <= 0)
            throw new ArgumentOutOfRangeException(nameof(unitPriceMount), "UnitPrice must be greater than zero.");
        
        var unitPrice = new Money(unitPriceMount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
        _items.Add(item);
    }

    /// <summary>
    /// Calcuate the total amount for the purchase order by summing the subtotal
    /// </summary>
    /// <returns></returns>
    public Money CalculateSubtotal()
    {
        var total = _items.Sum(item => item.CalculateSubtotal().Amount);
        return new Money(total, Currency);
    }
                                     
}