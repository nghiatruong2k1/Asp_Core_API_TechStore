
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
    public class ImageController : AdminController
    {
        ImageMasterRepository imageMasterRepository;
        ProductImageMasterRepository imageProductMasterRepository;
        public ImageController(JwtService service) : base(service)
        {
            imageMasterRepository = new ImageMasterRepository(this.context);
            imageProductMasterRepository = new ProductImageMasterRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] Boolean isTrash, [FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {

                var images = await imageMasterRepository.Gets(isTrash,limit, offset);
                if (images == null)
                {
                    return NoContent();
                }
                return Ok(images);
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
                count = await imageMasterRepository.GetCount(isTrash);
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
                var image = await imageMasterRepository.Get(id);
                if (image == null)
                {
                    return NoContent();
                }
                return Ok(image);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Image0256 image)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await imageMasterRepository.Update(image);
                if (result > 0)
                {
                    listMes.Add(new { message = "Cập nhật hình ảnh thành công!", type = "success" });
                    return Ok(new { value = true, message = listMes });
                }
                else
                {
                    listMes.Add(new { message = "Cập nhật hình ảnh không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes });
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Image0256 image)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await imageMasterRepository.Add(image);
                if (result > 0)
                {
                    listMes.Add(new { message = "Thêm hình ảnh thành công!", type = "success" });
                    return Ok(new { value = true, message = listMes });
                }
                else
                {
                    listMes.Add(new { message = "Thêm hình ảnh không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes });
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
                int result = await imageMasterRepository.Delete(id);
                if (result > 0)
                {
                    imageProductMasterRepository.DeleteByImageId(id);
                    listMes.Add(new { message = "Xóa hình ảnh thành công!", type = "success" });
                    return Ok(new { value = true, message = listMes });
                }
                else
                {
                    listMes.Add(new { message = "Xóa hình ảnh không thành công!", type = "warning" });
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
