using PropertyAPI.Domain.Common.Models;

namespace PropertyAPI.Domain.House.ValueObjects;

public sealed class HouseNumId : ValueObject{
    public Guid Value {get;}
    private HouseNumId(Guid value){
        Value = value;
    }
    public static HouseNumId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}