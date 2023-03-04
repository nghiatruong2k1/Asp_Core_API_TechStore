using Application.Contexts;
using Application.Helper;

using Application.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("default")]
    public class UserController : BaseController
    {
        UserRepository userRepository;
        public UserController(JwtService service) : base(service)
        {
            userRepository = new UserRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {

                int id = GetId(Request);
                if (id <= 0)
                {
                    return NoContent();
                }
                var user = await userRepository.Get(id);
                if (user == null)
                {
                    return NoContent();
                }
                var auth = new Auth(user);
                return Ok(auth);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
