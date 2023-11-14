using PropertyAPI.Domain.Common.Models;
using PropertyAPI.Domain.HouseAggregate.ValueObjects;
using PropertyAPI.Domain.PriceAggregate;
using PropertyAPI.Domain.PropertyAggregate;

namespace PropertyAPI.Domain.HouseAggregate;
public sealed class HouseNum
    : AggregateRoot<HouseNumId>
{
    public string Number { get; }
    public Property Property { get; }
    public Price PropertyPrice { get; }
    private HouseNum(
        HouseNumId id,
        Property property,
        Price propertyPrice,
        string name) : base(id)
    {
        Property = property;
        PropertyPrice = propertyPrice;
        Number = name;
    }

    // static factory method
    public static HouseNum Create(
        HouseNumId housenumid,
        Property property,
        Price propertyPrice,
        string number
        )
    {
        return new(
            HouseNumId.CreateUnique(),
            property,
            propertyPrice,
            number
        );

    }

}