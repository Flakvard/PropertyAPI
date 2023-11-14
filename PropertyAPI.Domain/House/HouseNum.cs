using PropertyAPI.Domain.Common.Models;
using PropertyAPI.Domain.House.ValueObjects;
using PropertyAPI.Domain.Price;
using PropertyAPI.Domain.Properties;

namespace PropertyAPI.Domain.House;
public sealed class HouseNum
    : AggregateRoot<HouseNumId>
{
    public string Number { get; }
    public Property Property { get; }
    public PropertyPrice PropertyPrice { get; }
    private HouseNum(
        HouseNumId id,
        Property property,
        PropertyPrice propertyPrice,
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
        PropertyPrice propertyPrice,
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