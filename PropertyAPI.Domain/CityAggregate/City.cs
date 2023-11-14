using PropertyAPI.Domain.Common.Models;
using PropertyAPI.Domain.CityAggregate.ValueObjects;
using PropertyAPI.Domain.AddressAggregate;

namespace PropertyAPI.Domain.CityAggregate;

public sealed class City
    : AggregateRoot<CityId>
{
    private readonly List<Address> _addresses = new();
    public string PostNum { get; }
    public string Name { get; }
    public IReadOnlyList<Address> Addresses => _addresses.AsReadOnly();
    private City(
        CityId id,
        string postNum,
        string name) : base(id)
    {
        PostNum = postNum;
        Name = name;
    }

    // static factory method
    public static City Create(
        CityId id,
        string postNum,
        string name
        )
    {
        return new(
            CityId.CreateUnique(),
            postNum,
            name
        );

    }

}