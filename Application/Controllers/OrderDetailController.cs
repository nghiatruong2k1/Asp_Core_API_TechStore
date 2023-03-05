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
    public class OrderDetailController : BaseController
    {

        OrderDetailRepository orderDetailRepository;
        public OrderDetailController(JwtService service) : base(service)
        {

            orderDetailRepository = new OrderDetailRepository(this.context);

        }
        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetsAsync(int orderId,[FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {
           
                var orders = await orderDetailRepository.Gets(orderId, limit, offset);
                if (orders == null)
                {
                    return NoContent();
                }
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("count/{orderId}")]
        public async Task<IActionResult> GetCountAsync(int orderId)
        {
            try
            {
               
                int count = await orderDetailRepository.GetCount(orderId);
                return Ok(count);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
