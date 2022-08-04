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
    public async Task<List<UserModel>> Get2() => await _userservice.GetTask();

    [HttpGet("{id:length(24)}")]

    public async Task<ActionResult<UserModel>> Get(string id){
        var valuesId = await _userservice.GestTaskAsycId(id);

        if( valuesId is null){
             return NotFound();
        }
           
        return valuesId;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(UserModel date){

        await _userservice.Create(date);
        return CreatedAtAction(nameof(Get2), date.Id, date);

    }



    [HttpPut("{id:length(24)}")]

    public async Task<ActionResult> Update(string id, UserModel users){
        
        var user = await _userservice.GestTaskAsycId(id);

        if(user is null){
            return NotFound();
        }

        users.Id = user.Id;
        
        
        await _userservice.Update(id, users);

        return Ok("Update Sucess!!");
        
   
    }
    [HttpDelete("{id:length(24)}")]
    
    public async Task<ActionResult> DeleteAsync(string id){

        var user = _userservice.GestTaskAsycId(id);

        if(user is null){
            return NotFound();
        }

        await _userservice.Delete(id);

        return Ok("Document Deleted");


    }
    
}