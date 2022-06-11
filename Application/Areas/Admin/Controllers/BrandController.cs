
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
    [EnableCors("default")]
    [ApiController]
    public class BrandController : AdminController
    {
        BrandMasterRepository brandMasterRepository;
        public BrandController(JwtService service) : base(service)
        {
            brandMasterRepository = new BrandMasterRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] Boolean isTrash, [FromQuery] String sort, [FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {

                var brands = await brandMasterRepository.Gets(isTrash,sort,limit, offset);
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
        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> GetCountAsync([FromQuery] Boolean isTrash)
        {
            try
            {
                int count = 0;
                count = await brandMasterRepository.GetCount(isTrash);
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
                var brand = await brandMasterRepository.Get(id);
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

        [HttpPut]
        public async Task<IActionResult> Put(Brand0256 brand)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await brandMasterRepository.Update(brand);
                if (result > 0)
                {
                    listMes.Add(new { message = "Cập nhật thương hiệu thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "cập nhật thương hiệu không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                //if (ModelState.IsValid)
                //{

                //}
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Brand0256 brand)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await brandMasterRepository.Add(brand);
                if (result > 0)
                {
                    listMes.Add(new { message = "Thêm thương hiệu thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "Thêm thương hiệu không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                //if (ModelState.IsValid)
                //{

                //}
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
                int result = await brandMasterRepository.Delete(id);
                if (result > 0)
                {
                    listMes.Add(new { message = "Xóa thương hiệu thành công!", type = "success" });
                    return Ok(new { value = true, message = listMes });
                }
                else
                {
                    listMes.Add(new { message = "Xóa thương hiệu không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes });
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
