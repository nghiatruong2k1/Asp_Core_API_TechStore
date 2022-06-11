using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class OrderRepository : BaseRepository
    { 
        public OrderRepository(TechStoreContext _db) : base(_db)
        {
            
        }
        public async Task<List<ViewOrder0256>> Gets(int userId, int statusId, int limit, int offset)
        {
            if (db != null)
            {
                var getter = db.ViewOrder0256s
                    .Where(p => p.UserId == userId
                        && p.IsPublic == true
                        && p.IsTrash == false
                        && p.StatusId == statusId
                    )
                    .OrderByDescending(p => p.CreateDate);
                if (limit > 0)
                {
                    return await getter.Skip(offset).Take(limit).ToListAsync();
                }
                else
                {
                    return await getter.Skip(offset).ToListAsync();
                }
            }

            return null;
        }
        
        public async Task<int> GetCount(int userId, int statusId)
        {
            if (db != null)
            {
                return await db.ViewOrder0256s
                    .Where(p => p.UserId == userId
                        && p.IsPublic == true
                        && p.IsTrash == false
                        && p.StatusId == statusId
                    ).CountAsync();
            }
            return 0;
        }
        public async Task<Order0256> Get(int orderId)
        {
            if (db != null)
            {
                return await db.Order0256s.Where(p=>p.Id == orderId).FirstOrDefaultAsync();
            }

            return null;
        }
        public async Task<Order0256> Get(int userId, int orderId)
        {
            if (db != null)
            {
                return await db.Order0256s.Where(p => p.Id == orderId && p.UserId == userId).FirstOrDefaultAsync();
            }

            return null;
        }
        public async Task<int> Add(Order0256 order)
        {
            if (db != null)
            {

                order.CreateDate = DateTime.Now;
                await db.Order0256s.AddAsync(order);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Delete(Order0256 order)
        {
            if (db != null)
            {

                db.Order0256s.Remove(order);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Delete(List<Order0256> orders)
        {
            if (db != null)
            {

                db.Order0256s.RemoveRange(orders);
                return await db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<int> Update(Order0256 order)
        {
            if (db != null)
            {
                
                if(order != null)
                {
                    order.UpdateDate = DateTime.Now;
                    db.Order0256s.Update(order);
                    return await db.SaveChangesAsync();
                }
            }
            return 0;
        }
    }
}
