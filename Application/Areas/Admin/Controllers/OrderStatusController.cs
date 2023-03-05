
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
    public class OrderStatusController : AdminController
    {
        OrderStatusMasterRepository orderStatusMasterRepository;
        public OrderStatusController(JwtService service) : base(service)
        {
            orderStatusMasterRepository = new OrderStatusMasterRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] Boolean isTrash, [FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {

                var orderStatuss = await orderStatusMasterRepository.Gets(isTrash,limit, offset);
                if (orderStatuss == null)
                {
                    return NoContent();
                }
                return Ok(orderStatuss);
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
                count = await orderStatusMasterRepository.GetCount(isTrash);
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
                var orderStatus = await orderStatusMasterRepository.Get(id);
                if (orderStatus == null)
                {
                    return NoContent();
                }
                return Ok(orderStatus);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(OrderStatus0256 orderStatus)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await orderStatusMasterRepository.Update(orderStatus);
                if (result > 0)
                {
                    listMes.Add(new { message = "Cập nhật trạng thái đơn hàng thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "cập nhật trạng thái đơn hàng không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(OrderStatus0256 orderStatus)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await orderStatusMasterRepository.Add(orderStatus);
                if (result > 0)
                {
                    listMes.Add(new { message = "Thêm trạng thái đơn hàng thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "Thêm trạng thái đơn hàng không thành công!", type = "warning" });
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
                int result = await orderStatusMasterRepository.Delete(id);
                if (result > 0)
                {
                    listMes.Add(new { message = "Xóa trạng thái đơn hàng thành công!", type = "success" });
                    return Ok(new { value = true, message = listMes });
                }
                else
                {
                    listMes.Add(new { message = "Xóa trạng thái đơn hàng không thành công!", type = "warning" });
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
