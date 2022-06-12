
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
    public class UserController : AdminController
    {
        UserMasterRepository userMasterRepository;
        public UserController(JwtService service) : base(service)
        {
            userMasterRepository = new UserMasterRepository(this.context);
        }
        [HttpGet]
        [Route("statistic")]
        public async Task<IActionResult> GetStatisticAsync()
        {
            try
            {
                var statis = await userMasterRepository.getStatistic();
                if (statis == null)
                {
                    return NoContent();
                }
                return Ok(statis);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] Boolean isTrash,[FromQuery] String sort, [FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {
                var users = await userMasterRepository.Gets(isTrash, limit, offset);
                if (users == null)
                {
                    return NoContent();
                }
                return Ok(users);
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
                count = await userMasterRepository.GetCount(isTrash);
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
                if (id == 0)
                {
                    return Ok(new ViewUser0256());
                }
                else
                {
                    var user = await userMasterRepository.Get(id);
                    if (user == null)
                    {
                        return NoContent();
                    }
                    return Ok(user);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(User0256 user)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await userMasterRepository.Update(user);
                if (result > 0)
                {
                    listMes.Add(new { message = "Cập nhật tài khoản thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "cập nhật tài khoản không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(User0256 user)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await userMasterRepository.Add(user);

                if (result > 0)
                {
                    listMes.Add(new { message = "Thêm tài khoản thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "Thêm tài khoản không thành công!", type = "success" });

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
                int result = await userMasterRepository.Delete(id);
                if (result > 0)
                {
                    listMes.Add(new { message = "Xóa tài khoản thành công!", type = "success" });
                    return Ok(new { value = true, message = listMes });
                }
                else
                {
                    listMes.Add(new { message = "Xóa tài khoản không thành công!", type = "warning" });
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
