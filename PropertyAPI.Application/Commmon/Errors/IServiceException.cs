using System.Net;

namespace PropertyAPI.Application.Commmon.Errors;

public interface IServiceException{
    public HttpStatusCode StatusCode{get;}
    public string ErrorMessage {get;}
}