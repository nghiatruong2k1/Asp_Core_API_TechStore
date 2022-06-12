using Application.Helper;
using Application.Interface;
using Application.Models;
using Application.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("default")]
    public class ProductController : BaseController
    {
        ProductRepository productRepository;
        BrandRepository brandRepository;
        CategoryRepository categoryRepository;
        public ProductController(JwtService service) : base(service)
        {
            productRepository = new ProductRepository(this.context);
            brandRepository = new BrandRepository(this.context);
            categoryRepository = new CategoryRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] int limit, [FromQuery] int offset,[FromQuery] String sort)
        {
            try
            {
                var products = await productRepository.Gets(limit,offset,sort);
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
        [Route("count")]
        public async Task<IActionResult> GetCountAsync()
        {
            try
            {
                int count = await productRepository.GetCount();
                return Ok(count);
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
                
                var product = await productRepository.Get(alias);
                if (product == null)
                {
                    return NoContent();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {

                var product = await productRepository.Get(id);
                if (product == null)
                {
                    return NoContent();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("search/{query}")]
        public async Task<IActionResult> GetsBySeachAsync(string query, [FromQuery] int limit, [FromQuery] int offset, [FromQuery] String sort)
        {
            try
            {

                var products = await productRepository.GetsBySearch(query,limit, offset,sort);
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

                var products = await productRepository.GetCountBySearch(query);
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
        [Route("type/{id}")]
        public async Task<IActionResult> GetByTypeAsync(int id, [FromQuery] int limit, [FromQuery] int offset)
        {
            
            try
            {
                var products = await productRepository.GetsByType(id,limit,offset);
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
        [Route("type/count/{id}")]
        public async Task<IActionResult> GetCountByTypeAsync(int id)
        {
            try
            {
                int count = await productRepository.GetCountByType(id);
                return Ok(count);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("category/{alias}")]
        public async Task<IActionResult> GetByCategoryAsync(String alias, [FromQuery] int limit, [FromQuery] int offset, [FromQuery] String sort)
        {
            try
            {
                var category = await categoryRepository.Get(alias);
                if(category == null || category.Id == null)
                {
                    return NoContent();
                }
                int id = (int)category.Id;
                var products = await productRepository.GetsByCategory(id,limit,offset,sort);
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
        [Route("category/count/{alias}")]
        public async Task<IActionResult> GetCountByCategoryAsync(String alias)
        {
            try
            {
                var category = await categoryRepository.Get(alias);
                if (category == null || category.Id == null)
                {
                    return NoContent();
                }
                int id = (int)category.Id;
                int count = await productRepository.GetCountByCategory(id);
                return Ok(count);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("brand/{alias}")]
        public async Task<IActionResult> GetByBrandAsync(String alias, [FromQuery] int limit, [FromQuery] int offset, [FromQuery] String sort)
        {
            try
            {
                var brand = await brandRepository.Get(alias);
                if (brand == null || brand.Id == null)
                {
                    return NoContent();
                }
                int id = (int)brand.Id;
                var products = await productRepository.GetsByBrand(id,limit,offset,sort);
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
        [Route("brand/count/{alias}")]
        public async Task<IActionResult> GetCountByBrandAsync(String alias)
        {
            try
            {
                var brand = await brandRepository.Get(alias);
                if (brand == null || brand.Id == null)
                {
                    return NoContent();
                }
                int id = (int)brand.Id;
                int count = await productRepository.GetCountByBrand(id);
                return Ok(count);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
