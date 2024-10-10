namespace API.Entities;
public class AppUser
{
    public int id {get;set;}

    public required string UserName {get;set;}
    public required byte[] PassWordHash {get;set;}

    public required byte[] PassWordSalt {get;set;}


}