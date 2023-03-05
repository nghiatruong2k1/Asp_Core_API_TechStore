using Application.Helper;
using Application.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : BaseController
    {
        ProductImageRepository productImageRepository;
        public ImageController(JwtService service) : base(service)
        {
            productImageRepository = new ProductImageRepository(this.context);

        }
        [HttpGet]
        [Route("product")]
        public async Task<IActionResult> GetsAsync([FromQuery] int id)
        {
            try
            {
                var imgs = await productImageRepository.GetsByProduct(id);
                if (imgs == null)
                {
                    return NoContent();
                }
                return Ok(imgs);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
