using PropertyAPI.Domain.BidAggregate;
using PropertyAPI.Domain.Common.Models;
using PropertyAPI.Domain.PriceAggregate.ValueObjects;
using PropertyAPI.Domain.PropertyAggregate;

namespace PropertyAPI.Domain.PriceAggregate;

public sealed class Price : AggregateRoot<PriceId>
{
    private readonly List<Bid> _bids = new();
    public decimal StartPropertyPrice { get; }
    public decimal LatestBidPrice { get; }
    public DateTime LastDateUpdated { get; }
    public Property Property { get; }

    public IReadOnlyList<Bid> Bids => _bids.AsReadOnly(); // can be casted into a list again
    private Price(
        PriceId id,
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
    public static Price Create(
        decimal startPropertyPrice,
        decimal latestBidPropertyPrice,
        DateTime lastDateUpdated,
        Property property)
    {
        return new(
            PriceId.CreateUnique(),
            startPropertyPrice,
            latestBidPropertyPrice,
            lastDateUpdated,
            property
            );
    }
}