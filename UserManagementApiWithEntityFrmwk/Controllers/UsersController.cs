using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using UserManagementApiWithEntityFrmwk.Model;
using UserManagementApiWithEntityFrmwk.DAL;

namespace UserManagementApiWithEntityFrmwk.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [EnableCors()]
    public IEnumerable<User> GetAllUsers()
    {
        List<User> users = UsersDataAccess.GetAllUsers();
        return users;
    }

    [HttpPost]
    [EnableCors()]
    public IActionResult InsertNewUser(User user)
    {
        UsersDataAccess.InsertNewUser(user);
        return Ok(new { message = "User created" });
    }

    [Route("{id}")]
    [HttpDelete]
    [EnableCors()]
    public ActionResult<User> DeleteOneUser(int id)
    {
        UsersDataAccess.DeleteOneUser(id);
        return Ok(new { message = "User deleted" });
    }
}