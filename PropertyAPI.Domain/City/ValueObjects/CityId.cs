using PropertyAPI.Domain.Common.Models;

namespace CityAPI.Domain.City.ValueObjects;
public sealed class CityId : ValueObject{
    public Guid Value {get;}
    private CityId(Guid value){
        Value = value;
    }
    public static CityId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}