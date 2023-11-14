using PropertyAPI.Domain.Common.Models;

namespace PropertyAPI.Domain.PropertyAggregate.ValueObjects;

public sealed class PropertyId : ValueObject
{
    public Guid Value { get; }
    private PropertyId(Guid value)
    {
        Value = value;
    }
    public static PropertyId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}