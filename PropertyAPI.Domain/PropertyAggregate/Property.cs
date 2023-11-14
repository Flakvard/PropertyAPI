using PropertyAPI.Domain.Common.Models;
using PropertyAPI.Domain.PriceAggregate;
using PropertyAPI.Domain.PropertyAggregate.ValueObjects;

namespace PropertyAPI.Domain.PropertyAggregate;

public sealed class Property
    : AggregateRoot<PropertyId>
{
    public int YearBuild { get; }
    public int InsideM2 { get; }
    public int OutsideM2 { get; }
    public int Rooms { get; }
    public int FloorLevels { get; }
    public DateTime CreatedDate { get; }
    public Price PropertyPrice { get; }
    private Property(
        PropertyId id,
        int yearBuild,
        int insideM2,
        int outsideM2,
        int rooms,
        int floorLevels,
        DateTime createdDate,
        Price propertyPrice) : base(id)
    {
        YearBuild = yearBuild;
        InsideM2 = insideM2;
        OutsideM2 = outsideM2;
        Rooms = rooms;
        FloorLevels = floorLevels;
        CreatedDate = createdDate;
        PropertyPrice = propertyPrice;
    }

    // static factory method
    public static Property Create(
            int yearBuild,
            int insideM2,
            int outsideM2,
            int rooms,
            int floorLevels,
            DateTime createdDate,
            Price propertyPrice
        )
    {
        return new(
            PropertyId.CreateUnique(),
            yearBuild,
            insideM2,
            outsideM2,
            rooms,
            floorLevels,
            createdDate,
            propertyPrice
        );

    }

}