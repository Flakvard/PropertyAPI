using PropertyAPI.Domain.Common.Models;
namespace PropertyAPI.Domain.Bids;
using PropertyAPI.Domain.Bids.ValueObjects;
using PropertyAPI.Domain.Price;

public sealed class Bid : AggregateRoot<BidId>
{
    public decimal BidPrice { get; }
    public DateTime BidDueDate { get; }
    public DateTime CreatedDate { get; }
    public PropertyPrice PropertyPrice { get; }
    public Bid(
        BidId id,
        decimal bidPrice,
        DateTime bidDueDate,
        DateTime createdDate,
        PropertyPrice propertyPrice) : base(id)
    {
        BidPrice = bidPrice;
        BidDueDate = bidDueDate;
        CreatedDate = createdDate;
        PropertyPrice = propertyPrice;
    }
}