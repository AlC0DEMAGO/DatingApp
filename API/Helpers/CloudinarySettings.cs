namespace API.Helpers;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
public class CloudinarySettings
{
    public required string CloudName {get;set;}    
    public required string ApiKey {get;set;}    
    public required string ApiSecret {get;set;}    
}
