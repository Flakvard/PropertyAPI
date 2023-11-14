using PropertyAPI.Domain.Common.Models;
using PropertyAPI.Domain.Addresses.ValueObjects;
using PropertyAPI.Domain.House;

namespace PropertyAPI.Domain.Addresses;
public sealed class Address
    : AggregateRoot<AddressId>
{
    private readonly List<HouseNum> _houseNum = new();
    public string Name { get;}
    public IReadOnlyList<HouseNum> HouseNum => _houseNum.AsReadOnly();
    private Address(
        AddressId id,
        string name) : base(id)
    {
        Name = name;
    }

    // static factory method
    public static Address Create(
        AddressId id,
        string name
        )
    {
        return new(
            AddressId.CreateUnique(),
            name
        );

    }

}