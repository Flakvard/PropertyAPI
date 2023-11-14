using PropertyAPI.Domain.Common.Models;

namespace PropertyAPI.Domain.Price.ValueObjects;

public sealed class PropertyPriceId : ValueObject
{
    public Guid Value { get; }
    private PropertyPriceId(Guid value)
    {
        Value = value;
    }
    public static PropertyPriceId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}