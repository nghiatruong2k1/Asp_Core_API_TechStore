using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class OrderStatusRepository : BaseRepository
    {
        public OrderStatusRepository(TechStoreContext _db) : base(_db)
        {

        }
        public async Task<List<OrderStatus0256>> Gets()
        {
            if (db != null)
            {
                return await db.OrderStatus0256s
                    .Where(p=>p.IsPublic == true
                        && p.IsTrash == false
                     ).ToListAsync();
            }

            return null;
        }
        public async Task<OrderStatus0256> GetDefault()
        {
            if (db != null)
            {
                return await db.OrderStatus0256s
                    .Where(p => p.IsPublic == true
                        && p.IsTrash == false
                     ).FirstOrDefaultAsync();
            }

            return null;
        }
    }
}
