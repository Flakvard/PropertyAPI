using PropertyAPI.Domain.Bids;
using PropertyAPI.Domain.Common.Models;
using PropertyAPI.Domain.Price.ValueObjects;
using PropertyAPI.Domain.Properties;

namespace PropertyAPI.Domain.Price;

public sealed class PropertyPrice : AggregateRoot<PropertyPriceId>
{
    private readonly List<Bid> _bids = new();
    public decimal StartPropertyPrice { get; }
    public decimal LatestBidPrice { get; }
    public DateTime LastDateUpdated { get; }
    public Property Property { get; }

    public IReadOnlyList<Bid> Bids => _bids.AsReadOnly(); // can be casted into a list again
    private PropertyPrice(
        PropertyPriceId id,
        decimal startPropertyPrice,
        decimal latestBidPropertyPrice,
        DateTime lastDateUpdated,
        Property property) : base(id)
    {
        StartPropertyPrice = startPropertyPrice;
        LatestBidPrice = latestBidPropertyPrice;
        LastDateUpdated = lastDateUpdated;
        Property = property;
    }
    // static factory method
    public static PropertyPrice Create(
        decimal startPropertyPrice,
        decimal latestBidPropertyPrice,
        DateTime lastDateUpdated,
        Property property)
    {
        return new(
            PropertyPriceId.CreateUnique(),
            startPropertyPrice,
            latestBidPropertyPrice,
            lastDateUpdated,
            property
            );
    }
}