using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersController
{

    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]

    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = _context.Users.ToList();

        return users;
    }

    [HttpGet("{id}")]

    public ActionResult<IEnumerable<AppUser>> GetUsersById(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null) return NotFound();

        return user;
    }


}