using PropertyAPI.Domain.Common.Models;

namespace PropertyAPI.Domain.BidAggregate.ValueObjects;

public sealed class BidId : ValueObject
{
    public Guid Value { get; }
    private BidId(Guid value)
    {
        Value = value;
    }

    // static factory method
    public static BidId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}