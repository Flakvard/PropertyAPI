using PropertyAPI.Domain.Common.Models;
using PropertyAPI.Domain.PriceAggregate;
using PropertyAPI.Domain.BidAggregate.ValueObjects;

namespace PropertyAPI.Domain.BidAggregate;
public sealed class Bid : AggregateRoot<BidId>
{
    public decimal BidPrice { get; }
    public DateTime BidDueDate { get; }
    public DateTime CreatedDate { get; }
    public Price PropertyPrice { get; }
    public Bid(
        BidId id,
        decimal bidPrice,
        DateTime bidDueDate,
        DateTime createdDate,
        Price propertyPrice) : base(id)
    {
        BidPrice = bidPrice;
        BidDueDate = bidDueDate;
        CreatedDate = createdDate;
        PropertyPrice = propertyPrice;
    }
}