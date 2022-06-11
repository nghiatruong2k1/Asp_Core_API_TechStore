using Application.Helper;
using Application.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("default")]
    public class OrderStatusController : BaseController
    {
        OrderStatusRepository orderStatusRepository;
        public OrderStatusController(JwtService service) : base(service)
        {
            orderStatusRepository = new OrderStatusRepository(this.context);

        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync()
        {
            try
            {
                var status = await orderStatusRepository.Gets();
                if (status == null)
                {
                    return NoContent();
                }
                return Ok(status);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
