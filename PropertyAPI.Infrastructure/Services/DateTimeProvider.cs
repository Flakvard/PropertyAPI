using PropertyAPI.Application.Commmon.Interfaces.Services;

namespace PropertyAPI.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider{
    public DateTime UtcNow => DateTime.UtcNow;
}