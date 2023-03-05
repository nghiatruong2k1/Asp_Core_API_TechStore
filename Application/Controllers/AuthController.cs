
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        AuthRepository authRepository;
        
        public AuthController(JwtService service) : base(service) 
        {
            authRepository = new AuthRepository(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {          
            return Ok(Response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> PostLogin(AuthLogin user)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                user.Email = user.Email.ToLower();
                var account = await authRepository.Login(user.Email, convert.getMd5(user.Password));
                if (account == null || account.Id == null)
                {
                    listMes.Add(new { message = "Email hoặc mật khẩu không chính xác!", type = "warning" });
                    listMes.Add(new { message = "Đăng nhập không thành công!", type = "warning" });
                    return Ok(new {message = listMes });
                 
                }
                if(account.IsTrash == true)
                {
                    listMes.Add(new { message = "Tài khoản đã bị tạm xóa!", type = "warning" });
                    listMes.Add(new { message = "Đăng nhập không thành công!", type = "warning" });
                    return Ok(new { message = listMes });
                }
                if(account.IsPublic == false)
                {
                    listMes.Add(new { message = "Tài khoản đã bị chặn quyền truy cập!", type = "warning" });
                    listMes.Add(new { message = "Đăng nhập không thành công!", type = "warning" });
                    return Ok(new {message = listMes });
                }


                var jwt = jwtService.Generate((int)account.Id);
                Response.Cookies.Append("token", jwt, new CookieOptions {});
                //Response.Headers.Append("token",jwt);

                listMes.Add(new { message = "Đăng nhập thành công!", type = "success" });
                switch (account.TypeId)
                {
                    case 4:
                        {
                            listMes.Add(new { message = "Chào mừng quản trị viên "+(account.FirstName != "" ? account.FirstName+" " : "")+(account.LastName ?? ""), type = "bell" });
                            break;
                        }
                    default:
                        {
                            listMes.Add(new { message = "Chào mừng " + (account.FirstName != "" ? account.FirstName + " " : "") + (account.LastName ?? ""), type = "bell" });
                            break;
                        }
                }
                return Ok(new {token = jwt, message = listMes });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> PostRegister(AuthRegister user)
        {
            List<Object> listMes = new List<Object>();
            try
            {
                User0256 nuser = new User0256();
                user.Email = user.Email.ToLower();
                nuser.CreateDate = DateTime.Now;
                nuser.Email = user.Email;
                nuser.Password = convert.getMd5(user.Password);
                nuser.FirstName = "User";
                nuser.LastName = convert.getMd5(DateTime.Now.ToString());
                nuser.TypeId = 1;
                nuser.IsPublic = true;
                nuser.IsTrash = false;
                var check = await authRepository.Register(nuser);

                if (check == false)
                {
                    listMes.Add(new { message = "Email đã tồn tại!", type = "warning" });
                    listMes.Add(new { message = "Đăng ký không thành công!", type = "warning" });
                    return Ok(new { value = false, message = listMes });
                }
                return await PostLogin(user as AuthLogin);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> PostLogout()
        {
            try
            {
                Response.Cookies.Delete("token");
                //Response.Headers.Remove("token");
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        
    }
}
