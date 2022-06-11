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
    public class OrderVoucherController : BaseController
    {
        OrderVoucherRepository orderVoucherRepository;
        public OrderVoucherController(JwtService service) : base(service)
        {
            orderVoucherRepository = new OrderVoucherRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] string code)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                var voucher = await orderVoucherRepository.Gets(code);
                if (voucher == null)
                {
                    listMes.Add(new { message = "Mã giảm giá không hợp lệ!" });
                    return Ok(new { message = listMes });
                }

                listMes.Add(new { message = "Áp dụng mã giảm giá thành công!" });
                return Ok( new {value = voucher, message = listMes });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
