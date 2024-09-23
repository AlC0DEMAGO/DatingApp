using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


//[Authorize]

public class AccountController(
    DataContext context,
    ITokenService tokenService) : BaseApiController
{
    
    [HttpPost("register")]

    public async Task<ActionResult<UserResponse>> RegisterAsync (RegisterRequest request)
        {

            if (await UserExistsAsync(request.Username)) 
            {
                return BadRequest("Username already in use");
            }

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = request.Username,
                PassWordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                PassWordSalt = hmac.Key
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new UserResponse
            {
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }

    [HttpPost("login")]

    public async Task<ActionResult<UserResponse>> Login(LoginRequest request)
    {
        var user = await context.Users.FirstOrDefaultAsync(x=>
        x.UserName.ToLower() == request.Username.ToLower());
    

    if (user==null)
    {
        return Unauthorized("invalid username or password");
    }

    using var hmac = new HMACSHA512(user.PassWordSalt);
    var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

    for (int i=0;i<computeHash.Length;i++)
    {
        if (computeHash[i] != user.PassWordHash[i]){
            return Unauthorized("invalid username or password");
        }
    }
    return new UserResponse
    {
        Username = user.UserName,
        Token = tokenService.CreateToken(user)
    };

    }


    private async Task<bool> UserExistsAsync(string username)
    {
        return await context.Users.AnyAsync(
            user => user.UserName.ToLower() == username.ToLower()
        );
    }
}