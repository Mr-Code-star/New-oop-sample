namespace ACME.OOP.Procurement.Domain.Model.ValueObjects;

public record ProductID
{
    public Guid Id { get; init; }
    /// <summary>
    ///  Constructor to create a ProductId with a specific Ghid
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ProductID(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id));
        Id = id;
    }
    /// <summary>
    /// Generate a new ProductID.
    /// </summary>
    /// <returns> A new ProductID instance with a unique identifier</returns>
    
    
    public static ProductID New() => new(Guid.NewGuid());
}