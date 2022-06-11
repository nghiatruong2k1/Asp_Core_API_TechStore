using Application.Controllers;
using Application.Helper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [EnableCors("default")]
    public class AdminController : BaseController
    {
        public AdminController(JwtService service) : base(service) { }
        //protected IDictionary<string, List<String>> ListValidate()
        //{
        //    IDictionary<string, List<String>> lstValidate = new Dictionary<string, List<String>>();
        //    foreach (var item in ModelState)
        //    {
        //        List<String> lstMsg = new List<string>();

        //        foreach (var error in item.Value.Errors)
        //        {
        //            lstMsg.Add(error.ErrorMessage);
        //        }
        //        lstValidate.Add(item.Key, lstMsg);
        //    }
        //    return lstValidate;
        //}
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //int id = GetId();
        //    //filterContext.Result = Ok(id);

        //    //if((Session["id"] == null) || (Session["typeId"] == null))
        //    //{
        //    //    this.lstToast.Add(new Toast() { message = "Vui lòng đăng nhập tài khoản quản trị", type = "warning" });
        //    //    EndAction();
        //    //    filterContext.Result = new RedirectToRouteResult(
        //    //        new RouteValueDictionary(
        //    //            new { controller = "user", action = "login", area = "" }
        //    //        )
        //    //    );
        //    //}
        //    //else
        //    //{
        //    //    if((Session["typeId"] != null && !Session["typeId"].Equals(4)))
        //    //    {
        //    //        this.lstToast.Add(new Toast() { message = "Bạn không có quyền truy cập trang quản trị", type = "warning" });
        //    //        EndAction();
        //    //        filterContext.Result = new RedirectToRouteResult(
        //    //            new RouteValueDictionary(
        //    //                new { controller = "", action = "", area = "" }
        //    //            )
        //    //        );
        //    //    }
        //    //}
        //}
    }
}
