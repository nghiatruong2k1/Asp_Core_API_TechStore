using Application.Helper;
using Application.Models;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Application.Contexts
{
    public class Auth
    {
        private ConvertObject cvObj = new ConvertObject();
        public Auth(ViewUser0256 user)
        {
            cvObj.merge(this, user);
        }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
    }

    public class AuthLogin
    {
        protected ConvertObject cvObj = new ConvertObject();
        public AuthLogin(ViewUser0256 user)
        {
            cvObj.merge(this, user);
        }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class AuthRegister : AuthLogin
    {
        public AuthRegister(ViewUser0256 user):base(user)
        {
           
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }     
        public string Phone { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
    }
}
