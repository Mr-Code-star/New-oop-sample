using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.SCM.Domain.Model.Aggregates;

/// <summary>
/// this class represents a supplier agregate in the bounded context of the Supply Chain Management
/// </summary>
/// <param name="identifier"></param>
/// <param name="name"></param>
/// <param name="address"></param>



//Esto ya es una clase
public class Supplier(string identifier, string name, Address address)
{
    public string Identifier { get; } = identifier ?? throw new ArgumentNullException(nameof(identifier));
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    public Address Address { get; } = address ?? throw new ArgumentNullException(nameof(address));
}