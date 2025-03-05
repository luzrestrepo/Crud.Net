using Microsoft.AspNetCore.Mvc;
using ResiduosApi.Services;
using ResiduosApi.Models;
using ResiduosApi.Repositories;

namespace ResiduosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserServices userServices;

    public UserController(ApplicationDbContext context)
    {
        userServices = new UserServices(context);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllusers()
    {
        var users = await userServices.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = userServices.GetUserById(id);
        
        if(user == null)
        {
            return NotFound(new ErrorResponse {Message = "User not found", StatusCode = 404, Title = "Not Found"});
        }
        return Ok(user);
    }
    
   [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var user = await userServices.CreateUser(request);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] CreateUserRequest request)
    {
        var updatedUser = await userServices.UpdateUserById(id, request);
        if (updatedUser == null)
        {
            return NotFound(new ErrorResponse { Message = "User not found", StatusCode = 404, Title = "Not Found" });
        }
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var isDeleted = await userServices.DeleteUserById(id);
        if (!isDeleted)
        {
            return NotFound(new ErrorResponse { Message = "User not found", StatusCode = 404, Title = "Not Found" });
        }
        return NoContent();
    }
}