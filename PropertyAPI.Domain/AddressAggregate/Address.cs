using PropertyAPI.Domain.Common.Models;
using PropertyAPI.Domain.HouseAggregate;
using PropertyAPI.Domain.AddressAggregate.ValueObjects;

namespace PropertyAPI.Domain.AddressAggregate;
public sealed class Address
    : AggregateRoot<AddressId>
{
    private readonly List<HouseNum> _houseNum = new();
    public string Name { get; }
    public IReadOnlyList<HouseNum> HouseNum => _houseNum.AsReadOnly();
    private Address(
        AddressId id,
        string name) : base(id)
    {
        Name = name;
    }

    // static factory method
    public static Address Create(
        string name
        )
    {
        return new(
            AddressId.CreateUnique(),
            name
        );

    }

}