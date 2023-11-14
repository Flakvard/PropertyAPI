using PropertyAPI.Domain.Common.Models;

namespace PropertyAPI.Domain.PriceAggregate.ValueObjects;

public sealed class PriceId : ValueObject
{
    public Guid Value { get; }
    private PriceId(Guid value)
    {
        Value = value;
    }
    public static PriceId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}