namespace PropertyAPI.Domain.Entities;

public class User
{
    public Guid Id{get;set;} = Guid.NewGuid();
    required public string FirstName{get;set;}
    required public string LastName{get;set;}
    required public string Email {get;set;}
    required public string Password {get;set;}

} 