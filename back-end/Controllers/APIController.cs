using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Entities.Models;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {
        private IUserService _userService;
        private TESTDBContext context;

        public APIController(IUserService userService, TESTDBContext tESTDBContext)
        {
            _userService = userService;
            context = tESTDBContext;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            Console.WriteLine("Hello World!");

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        //[Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("persons")]
        public IActionResult GetAllPerson()
        {
            //var users = _userService.GetAll();
            var person = context.Persons.ToList();
            return Ok(person);
        }

        [HttpPost("persons/getPersonById")]
        public IActionResult GetPersonById(getPersonByIdParameterModel model)
        {
            //var users = _userService.GetAll();
            var person = context.Persons.FirstOrDefault(f => f.Id == model.id);
            return Ok(person);
        }
    }

    public class getPersonByIdParameterModel
    {
        public int id { get; set; }
    }
}
