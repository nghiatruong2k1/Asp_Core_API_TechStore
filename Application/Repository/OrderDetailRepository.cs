using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class OrderDetailRepository : BaseRepository
    {
        public OrderDetailRepository(TechStoreContext _db):base(_db)
        {
            
        }
        public async Task<List<ViewOrderDetail0256>> Gets(int orderId, int limit, int offset)
        {
            if (db != null)
            {
                var getter = db.ViewOrderDetail0256s
                        .Where(p => p.OrderId == orderId
                            && p.IsPublic == true
                            && p.IsTrash == false
                        );
               if (limit > 0)
                {
                    return await
                       getter.Skip(offset).Take(limit).ToListAsync();
                }
                else
                {
                    return await getter.Skip(offset).ToListAsync();
                }
            }

            return null;
        }
        public async Task<int> GetCount(int orderId)
        {
            if (db != null)
            {
                return await db.ViewOrderDetail0256s
                    .Where(p => p.OrderId == orderId
                        && p.IsPublic == true
                        && p.IsTrash == false
                    ).CountAsync();
            }

            return 0;
        }
        public async Task<int> Add(OrderDetail0256 order)
        {
            if (db != null)
            {
                await db.OrderDetail0256s.AddAsync(order);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Add(List<OrderDetail0256> orders)
        {
            if (db != null)
            {
                await db.OrderDetail0256s.AddRangeAsync(orders);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Delete(OrderDetail0256 order)
        {
            if (db != null)
            {
                db.OrderDetail0256s.Remove(order);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Delete(List<OrderDetail0256> orders)
        {
            if (db != null)
            {
                db.OrderDetail0256s.RemoveRange(orders);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
    }
}
