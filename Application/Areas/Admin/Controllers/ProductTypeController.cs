
using Application.Areas.Admin.Repository;
using Application.Helper;
using Application.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ProductTypeController : AdminController
    {
        ProductTypeMasterRepository productTypeMasterRepository;
        public ProductTypeController(JwtService service) : base(service)
        {
            productTypeMasterRepository = new ProductTypeMasterRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] Boolean isTrash, [FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {
                var productTypes = await productTypeMasterRepository.Gets(isTrash,limit, offset);
                if (productTypes == null)
                {
                    return NoContent();
                }
                return Ok(productTypes);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> GetCountAsync([FromQuery] Boolean isTrash)
        {
            try
            {
                int count = 0;
                count = await productTypeMasterRepository.GetCount(isTrash);
                return Ok(count);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if(id == 0)
                {
                    return Ok(new ProductType0256());
                }
                var productType = await productTypeMasterRepository.Get(id);
                if (productType == null)
                {
                    return NoContent();
                }
                return Ok(productType);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductType0256 productType)
        {
            try
            {
                int result =  await productTypeMasterRepository.Update(productType);
                return Ok(result);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductType0256 productType)
        {
            try
            {
                int result = await productTypeMasterRepository.Add(productType);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int result = await productTypeMasterRepository.Delete(id);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
