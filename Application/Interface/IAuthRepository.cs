using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interface
{
    interface IAuthRepository
    {
        Task<User0256> Login(string Email,string Password);
        Task<Boolean> Register(User0256 user);
    }
}
