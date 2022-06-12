using Application.Interface;
using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class AuthRepository : BaseRepository
    {
        public AuthRepository(TechStoreContext _db):base(_db)
        {
            
        }

        public async Task<ViewUser0256> Login(string Email, string Password)
        {
            if (db != null)
            {
                return await db.ViewUser0256s
                    .Where(p => p.Email.Equals(Email)
                        && p.Password.Equals(Password)
                    ).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<Boolean> Register(User0256 user)
        {
            var check = await db.User0256s
                    .Where(p => p.Email.Equals(user.Email))
                    .FirstOrDefaultAsync();
            if(check == null)
            {
                user.CreateDate = DateTime.Now;
                db.User0256s.Add(user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
