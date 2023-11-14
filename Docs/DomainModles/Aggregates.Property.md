# Domain Models

## Proptery

```csharp
public class Property{
    Property Create();
    void AddProperty(Proptery prop);
    void DeleteProperty(int id);
    List<Property> GetProperties();
    Property GetProperty(int id);
}
```

```json
}
    "propertyId": { "value": "00000000-0000-0000-0000-000000000000" },
    "yearbuild": "1985",
    "insideM2": "158",
    "outsideM2": "305",
    "rooms": "4",
    "floorLevels": "2",
    "Idaddress": { "value": "00000000-0000-0000-0000-000000000000" },
    "Idhouse_num": { "value": "00000000-0000-0000-0000-000000000000" },
    "priceId": { "value": "00000000-0000-0000-0000-000000000000" },
    "createdDate": "2023-01-01-00:00:00:00000000",
}
```