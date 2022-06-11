
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
    [EnableCors("default")]
    public class ProductController : AdminController
    {
        ProductMasterRepository productMasterRepository;
        ProductImageMasterRepository imageMasterRepository;
        public ProductController(JwtService service) : base(service)
        {
            productMasterRepository = new ProductMasterRepository(this.context);
            imageMasterRepository = new ProductImageMasterRepository(this.context);

        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] Boolean isTrash, [FromQuery] String sort, [FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {

                var products = await productMasterRepository.Gets(isTrash,sort,limit, offset);
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
        public async Task<IActionResult> GetCountAsync([FromQuery] Boolean isTrash)
        {
            try
            {
                int count = 0;
                count = await productMasterRepository.GetCount(isTrash);
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
                    return Ok(new ViewProduct0256());
                }
                else
                {
                    var product = await productMasterRepository.Get(id);
                    if (product == null)
                    {
                        return NoContent();
                    }
                    return Ok(product);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product0256 product)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result =  await productMasterRepository.Update(product);
                if(result > 0)
                {
                    listMes.Add(new { message = "Cập nhật sản phẩm thành công!", type = "success" });

                    return Ok(new { value = product, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "cập nhật sản phẩm không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Product0256 product) 
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await productMasterRepository.Add(product);

                if(result > 0)
                {
                    listMes.Add(new { message = "Thêm sản phẩm thành công!", type = "success" });

                    return Ok(new {value=product, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "Thêm sản phẩm không thành công!", type = "success" });

                    return Ok(new {value = false, message = listMes, validate = new { } });
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        [Route("multiple")]
        public async Task<IActionResult> PostMultiple(List<Product0256> products)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await productMasterRepository.Adds(products);

                if (result > 0)
                {
                    listMes.Add(new { message = "Thêm sản phẩm thành công!", type = "success" });

                    return Ok(new { value = products, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "Thêm sản phẩm không thành công!", type = "success" });

                    return Ok(new { value = false, message = listMes, validate = new { } });
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            List<Object> listMes = new List<Object>();
            try
            {
               int result = await productMasterRepository.Delete(id);
               if(result > 0)
                {
                    imageMasterRepository.DeleteByProductId(id);
                    listMes.Add(new { message = "Xóa sản phẩm thành công!", type = "success" });
                    return Ok(new {value=result, message = listMes });
                }
                else
                {
                    listMes.Add(new { message = "Xóa sản phẩm không thành công!", type = "warning" });
                    return Ok(new {value=false, message = listMes });
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
