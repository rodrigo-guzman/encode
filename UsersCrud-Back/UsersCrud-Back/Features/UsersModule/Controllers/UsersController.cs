using Microsoft.AspNetCore.Mvc;
using UsersCrud_Back.Features.UsersModule.Users.InputOutput;
using UsersCrud_Back.Features.UsersModule.Users.Interactor;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersCrud_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersUseCase usersUseCase;

        public UsersController(IUsersUseCase usersUseCase)
        {
            this.usersUseCase = usersUseCase;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string user)
        {
            var input = new UsersInput { User = user };
            try
            {
                var result = await UsersUseCase.ExecuteAsync(input);
                return Ok(result.ToOutput());
            }
            catch (Exception)
            {
                return BadRequest("Error al consultar los usuarios en la base de datos");
            }
            
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
