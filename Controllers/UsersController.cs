using Microsoft.AspNetCore.Mvc;
using Users.Models;
using Users.Service;


namespace Users.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller{

    public readonly UserService _userservice;

    // assigns the contruct the value of service
    public UsersController(UserService userservice) => _userservice = userservice;

    [HttpGet]
    public async Task<List<UserModel>> GetTaskAsync() => await _userservice.GetTask();


  
    
}