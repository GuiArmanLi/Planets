using Planets.Service.User;

namespace Planets.Applicantion.Controllers;

[Controller]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly _service;

    public UserController(USerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUSers()
    {
        return _service.GetAllUSers();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(UserSignUpDTO request)
    {
        return _service.SignUp(request);
    }

    [HttpGet]
    public async Task<IActionResult> SignIn(UserEntity userView)
    {
        return _service.SignIn(userView);
    }
}
