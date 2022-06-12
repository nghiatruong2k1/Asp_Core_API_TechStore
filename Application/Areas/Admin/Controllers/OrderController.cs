
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
    public class OrderController : AdminController
    {
        OrderMasterRepository orderMasterRepository;
        OrderDetailMasterRepository orderDetailMasterRepository;
        public OrderController(JwtService service) : base(service)
        {
            orderMasterRepository = new OrderMasterRepository(this.context);
            orderDetailMasterRepository = new OrderDetailMasterRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] Boolean isTrash, [FromQuery] String sort, [FromQuery] int limit, [FromQuery] int offset)
        {
            try
            {
                var orders = await orderMasterRepository.Gets(isTrash,sort, limit, offset);
                if (orders == null)
                {
                    return NoContent();
                }
                return Ok(orders);
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
                count = await orderMasterRepository.GetCount(isTrash);
                return Ok(count);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("statistic")]
        public async Task<IActionResult> GetStatisticAsync()
        {
            try
            {
                var statis = await orderMasterRepository.getStatistic();
                if(statis == null)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return Ok(new ViewOrder0256());
                }
                else
                {
                    var order = await orderMasterRepository.Get(id);
                    if (order == null)
                    {
                        return NoContent();
                    }
                    return Ok(order);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Order0256 order)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await orderMasterRepository.Update(order);
                if (result > 0)
                {
                    listMes.Add(new { message = "Cập nhật đơn hàng thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "cập nhật đơn hàng không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Order0256 order)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int result = await orderMasterRepository.Add(order);

                if (result > 0)
                {
                    listMes.Add(new { message = "Thêm đơn hàng thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "Thêm đơn hàng không thành công!", type = "success" });

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
                int result = await orderMasterRepository.Delete(id);
                int res = await orderDetailMasterRepository.DeleteByOrderId(id);
                if (result > 0)
                {
                    listMes.Add(new { message = "Xóa đơn hàng thành công!", type = "success" });
                    return Ok(new { value = true, message = listMes });
                }
                else
                {
                    listMes.Add(new { message = "Xóa đơn hàng không thành công!", type = "warning" });
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
