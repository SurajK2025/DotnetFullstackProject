using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace UsersController;
using UserManagementApi.Model;
using UserManagementApi.DAL;

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

    [Route("{id}")]
    [HttpGet]
    [EnableCors()]
    public ActionResult<User> GetOneUser(int id)
    {
        User users = UsersDataAccess.GetUserById(id);
        return users;
    }

    [HttpPost]
    [EnableCors()]
    public IActionResult InsertNewUser(User user)
    {
        UsersDataAccess.SaveNewUser(user);
        return Ok(new { message = "User created" });
    }

    [Route("{id}")]
    [HttpDelete]
    [EnableCors()]
    public ActionResult<User> DeleteOneUser(int id)
    {
        UsersDataAccess.DeleteUserById(id);
        return Ok(new { message = "User deleted" });
    }
}