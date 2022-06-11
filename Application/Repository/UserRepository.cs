using Application.Interface;
using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class UserRepository : BaseRepository 
    { 

        public UserRepository(TechStoreContext _db) :base(_db)
        {
            
        }

        public async Task<ViewUser0256> Get(int id)
        {
            if (db != null)
            {
                return await db.ViewUser0256s
                    .FirstOrDefaultAsync(
                        p => p.Id == id
                    );
            }
            return null;
        }
    }
}
