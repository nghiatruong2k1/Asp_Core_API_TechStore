using Application.Helper;
using Application.Models;
using Application.Repository;
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
    public class BaseController : ControllerBase
    {
        protected TechStoreContext context = new TechStoreContext();
        protected JwtService jwtService;
        protected IEmailService emailService;
        protected ConvertString convert = new ConvertString();
        protected Random random = new Random();

        public BaseController(JwtService service)
        {
            this.jwtService = service;

        }
        public BaseController(IEmailService service)
        {
            this.emailService = service;

        }
        public BaseController(JwtService jservice,IEmailService eservice)
        {
            this.jwtService = jservice;
            this.emailService = eservice;

        }
        protected int GetId(HttpRequest request)
        {
            try
            {
                var jwt = request.Headers["token"];
                if (jwt.Count == 0)
                {
                    return 0;
                }
                var token = this.jwtService.Verify(jwt[0]);
                return int.Parse(token.Issuer);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
