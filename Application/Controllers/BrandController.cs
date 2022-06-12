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
    [EnableCors("default")]
    public class BrandController : BaseController
    {
        BrandRepository brandRepository;
        public BrandController(JwtService service) : base(service)
        {
            brandRepository = new BrandRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {
                var brands = await brandRepository.Gets(limit,offset);
                if (brands == null)
                {
                    return NoContent();
                }
                return Ok(brands);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("{alias}")]
        public async Task<IActionResult> GetAsync(String alias)
        {
            try
            {
                var brand = await brandRepository.Get(alias);
                if (brand == null)
                {
                    return NoContent();
                }
                return Ok(brand);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> GetCountAsync()
        {
            try
            {
                int count = await brandRepository.GetCount();
                return Ok(count);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("search/{query}")]
        public async Task<IActionResult> GetsBySeachAsync(string query, [FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {

                var products = await brandRepository.GetsBySearch(query, limit, offset);
                if (products == null)
                {
                    return NoContent();
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("search/count/{query}")]
        public async Task<IActionResult> GetCountBySeachAsync(string query)
        {
            try
            {

                var products = await brandRepository.GetCountBySearch(query);
                if (products == null)
                {
                    return NoContent();
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
