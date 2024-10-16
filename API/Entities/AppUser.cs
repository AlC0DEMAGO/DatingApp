using API.Extensions;

namespace API.Entities;
public class AppUser
{
    public int id {get;set;}

    public required string UserName {get;set;}
    public required byte[] PassWordHash {get;set;} = [];

    public required byte[] PassWordSalt {get;set;} = [];

    public DateOnly BirthDay {get;set;}
    public required string KnownAs {get;set;}
    public DateTime Created {get;set;}
    public DateTime LastActive {get;set;}
    public required string Gender {get;set;}
    public string? Introduction {get;set;}
    public string? Interests {get;set;}
    public string? LookingFor{get;set;}
    public required string City{get;set;}
    public required string Country {get;set;}
    public List<Photo> Photos{get;set;} =[];
    public int GetAge() => BirthDay.CalculateAge();
}