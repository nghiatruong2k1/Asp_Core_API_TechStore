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
    public class CategoryController : BaseController
    {
        CategoryRepository categoryRepository;
        public CategoryController(JwtService service) : base(service)
        {
            categoryRepository = new CategoryRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {
                var categorys = await categoryRepository.Gets(limit,offset);
                if (categorys == null)
                {
                    return NoContent();
                }
                return Ok(categorys);
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
                var category = await categoryRepository.Get(alias);
                if (category == null)
                {
                    return NoContent();
                }
                return Ok(category);
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
                int count = await categoryRepository.GetCount();
                return Ok(count);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("popular")]
        public async Task<IActionResult> GetsIsPopular([FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {
                var categorys = await categoryRepository.GetsIsPopular(limit,offset);
                if(categorys == null)
                {
                    return NoContent();
                }
                return Ok(categorys);
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

                var categorys = await categoryRepository.GetsBySearch(query, limit, offset);
                if (categorys == null)
                {
                    return NoContent();
                }
                return Ok(categorys);
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

                var categorys = await categoryRepository.GetCountBySearch(query);
                if (categorys == null)
                {
                    return NoContent();
                }
                return Ok(categorys);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
