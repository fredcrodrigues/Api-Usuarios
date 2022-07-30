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

    [HttpGet("{id:length(24)}")]

    public async Task<ActionResult<UserModel>> GetId(string id){
        var valuesId = await _userservice.GestTaskAsycId(id);

        if( valuesId is null){
             return NotFound();
        }
           

        return valuesId;
    }
  
    
}