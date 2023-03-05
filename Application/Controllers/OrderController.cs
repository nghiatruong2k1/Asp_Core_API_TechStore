using Application.Contexts;
using Application.Helper;
using Application.Models;

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
    public class OrderController : BaseController
    {
        OrderRepository orderRepository;
        OrderDetailRepository orderDetailRepository;
        OrderStatusRepository orderStatusRepository;
        UserRepository userRepository;
        public OrderController(JwtService service) : base(service)
        {
            orderRepository = new OrderRepository(this.context);
            orderDetailRepository = new OrderDetailRepository(this.context);
            userRepository = new UserRepository(this.context);
            orderStatusRepository = new OrderStatusRepository(this.context);

        }
        [HttpGet]
        public async Task<IActionResult> GetsAsync([FromQuery] int statusId, [FromQuery] int limit, [FromQuery] int offset)
        {
            List<Object> listMes = new List<Object>();
            try
            {

                int id = GetId(Request);
                if (id == 0)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                var user = await userRepository.Get(id);
                if (user == null)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                var orders = await orderRepository.Gets(id, statusId, limit, offset);
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
        public async Task<IActionResult> GetCountAsync([FromQuery] int statusId)
        {
            List<Object> listMes = new List<Object>();
            try
            {

                int id = GetId(Request);
                if (id == 0)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                var user = await userRepository.Get(id);
                if (user == null)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                int count = await orderRepository.GetCount(id, statusId);
                return Ok(count);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("Confirm/{id}")]
        public async Task<IActionResult> Put(String id)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int uid = GetId(Request);
                if (uid == 0)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                var user = await userRepository.Get(uid);
                if (user == null)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                var jwtId = this.jwtService.Verify(id);
                int orderId = int.Parse(jwtId.Issuer);

                var order = await orderRepository.Get(uid, orderId);
                if (order != null)
                {
                    if(order.StatusId == 2)
                    {
                        listMes.Add(new { message = "Đơn hàng đã được xác nhận!", type = "bell" });
                        return Ok(new { value = order, message = listMes });
                    }
                    order.StatusId = 2;
                    int result = await orderRepository.Update(order);
                    if (result > 0)
                    {
                        listMes.Add(new { message = "Xác nhận đơn hàng thành công!", type = "success" });
                        return Ok(new { value = order, message = listMes});
                    }
                    else
                    {
                        listMes.Add(new { message = "Xác nhận đơn hàng không thành công!", type = "warning" });
                        return Ok(new { message = listMes });
                    }
                }
                else
                {
                    listMes.Add(new { message = "Đơn hàng không tồn tại!", type = "warning" });
                    return Ok(new { message = listMes });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Carts cart)
        {
            List<Object> listMes = new List<Object>();
            Order0256 order = null;
            List<OrderDetail0256> details = null;
            try
            {

                int id = GetId(Request);
                if (id == 0)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                var user = await userRepository.Get(id);
                if (user == null)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }  

                order = new Order0256();
                order.UserId = id;
                if (cart.Voucher != null)
                {
                    order.VoucherSale = cart.Voucher.Value;
                }

                order.StatusId = 1;

                var result = await orderRepository.Add(order);
                if (result == 0)
                {
                    listMes.Add(new { message = "Đặt hàng không thành công!", type = "warning" });
                    return Ok(new { message = listMes });
                }
                details = new List<OrderDetail0256>();
                foreach (ProductCart product in cart.Products)
                {
                    OrderDetail0256 orderDetail = new OrderDetail0256();
                    orderDetail.ProductId = product.Id;
                    orderDetail.OrderId = order.Id;

                    orderDetail.Price = product.Price;
                    orderDetail.Quantity = product.Quantity;
                    orderDetail.IsPublic = true;
                    orderDetail.IsTrash = false;

                    details.Add(orderDetail);
                }
                int res = await orderDetailRepository.Add(details);
                if(res == 0)
                {
                    listMes.Add(new { message = "Có lỗi khi đặt hàng!", type = "success" });
                    return Ok(new { value = false, message = listMes });
                }
                else
                {
                    String jwt = jwtService.Generate(order.Id);
                    listMes.Add(new { message = "Đơn hàng đã đặt thành công!", type = "success" });
                    return Ok(new { value = jwt, message = listMes });
                }
                
            }
            catch (Exception e)
            {
                if(order != null)
                {
                    orderRepository.Delete(order);
                }
                if(details != null)
                {
                    orderDetailRepository.Delete(details);
                }
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("cancel/{orderId:int}")]
        public async Task<IActionResult> PutCancel(int orderId)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int id = GetId(Request);
                if (id == 0)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                var user = await userRepository.Get(id);
                if (user == null)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new {value=false, message = listMes, validate = new { } });
                }

                var order = await orderRepository.Get(id,orderId);
                if(order == null)
                {
                    listMes.Add(new { message = "Đơn hàng không tồn tại!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                order.StatusId = 4;
                int result = await orderRepository.Update(order);
                if (result > 0)
                {
                    listMes.Add(new { message = "Hủy đơn hàng thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "Hủy đơn hàng không thành công!", type = "warning" });
                    return Ok(new { message = listMes, validate = new { } });
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("recancel/{orderId:int}")]
        public async Task<IActionResult> PutReCancel(int orderId)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int id = GetId(Request);
                if (id == 0)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                var user = await userRepository.Get(id);
                if (user == null)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }

                var order = await orderRepository.Get(id, orderId);
                if (order == null)
                {
                    listMes.Add(new { message = "Đơn hàng không tồn tại!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                order.StatusId = 1;
                int result = await orderRepository.Update(order);
                if (result > 0)
                {
                    listMes.Add(new { message = "Đặt lại đơn hàng thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "Đặt lại đơn hàng không thành công!", type = "warning" });
                    return Ok(new { message = listMes, validate = new { } });
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("delete/{orderId:int}")]
        public async Task<IActionResult> PutDelete(int orderId)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                int id = GetId(Request);
                if (id == 0)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                var user = await userRepository.Get(id);
                if (user == null)
                {
                    listMes.Add(new { message = "Vui lòng đăng nhập!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }

                var order = await orderRepository.Get(id, orderId);
                if (order == null)
                {
                    listMes.Add(new { message = "Đơn hàng không tồn tại!", type = "warning" });
                    return Ok(new { value = false, message = listMes, validate = new { } });
                }
                order.IsTrash = true;
                int result = await orderRepository.Update(order);
                if (result > 0)
                {
                    listMes.Add(new { message = "Xóa đơn hàng thành công!", type = "success" });

                    return Ok(new { value = true, message = listMes, validate = new { } });
                }
                else
                {
                    listMes.Add(new { message = "Xóa đơn hàng không thành công!", type = "warning" });
                    return Ok(new { message = listMes, validate = new { } });
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
