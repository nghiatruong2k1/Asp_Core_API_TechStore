using Application.Contexts;
using Application.Helper;
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
    public class EmailController : BaseController
    {
        public EmailController(IEmailService service) : base(service)
        {
            
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailData emailData)
        {
            try
            {
                Boolean res = await emailService.SendEmail(emailData);
                return Ok(res);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
