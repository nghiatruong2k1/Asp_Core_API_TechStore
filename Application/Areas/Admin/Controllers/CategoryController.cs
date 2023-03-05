
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
    public class CategoryController : AdminController
    {
        CategoryMasterRepository categoryMasterRepository;
        public CategoryController(JwtService service) : base(service)
        {
            categoryMasterRepository = new CategoryMasterRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] Boolean isTrash, [FromQuery] String sort, [FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {

                var categorys = await categoryMasterRepository.Gets(isTrash, sort, limit, offset);
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
        [Route("count")]
        public async Task<IActionResult> GetCountAsync([FromQuery] Boolean isTrash)
        {
            try
            {
                int count = 0;
                count = await categoryMasterRepository.GetCount(isTrash);
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
                var category = await categoryMasterRepository.Get(id);
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

        [HttpPut]
        public async Task<IActionResult> Put(Category0256 category)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await categoryMasterRepository.Update(category);
                if (result > 0)
                {
                    listMes.Add(new { message = "Cập nhật danh mục thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "cập nhật danh mục không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Category0256 category)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await categoryMasterRepository.Add(category);
                if (result > 0)
                {
                    listMes.Add(new { message = "Thêm danh mục thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "Thêm danh mục không thành công!", type = "warning" });
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
                int result = await categoryMasterRepository.Delete(id);
                if (result > 0)
                {
                    listMes.Add(new { message = "Xóa danh mục thành công!", type = "success" });
                    return Ok(new { value = true, message = listMes });
                }
                else
                {
                    listMes.Add(new { message = "Xóa danh mục không thành công!", type = "warning" });
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
