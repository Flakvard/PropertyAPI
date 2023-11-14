using PropertyAPI.Domain.Common.Models;

namespace PropertyAPI.Domain.AddressAggregate.ValueObjects;
public sealed class AddressId : ValueObject
{
    public Guid Value { get; }
    private AddressId(Guid value)
    {
        Value = value;
    }
    public static AddressId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}