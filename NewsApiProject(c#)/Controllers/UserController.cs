using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApiProject.Repository;

namespace NewsApiProject.Controllers
{
    [Route("profile/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [Route("GetProfile")]
        public IActionResult Get()
        {
            var sources = _userRepository.Get(1);

            return Ok(sources);
        }
    }
}
