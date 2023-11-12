using Mapster;
using PropertyAPI.Application.Authentication.Commands.Register;
using PropertyAPI.Application.Authentication.Common;
using PropertyAPI.Application.Authentication.Queries.Login;
using PropertyAPI.Contract.Authentication;

namespace PropertyAPI.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest,RegisterCommand>();
        config.NewConfig<LoginRequest,LoginQuery>();
        config.NewConfig<AuthenticationResult,AuthenticationResponse>()
        .Map(dest => dest, src => src.User);
    }
}