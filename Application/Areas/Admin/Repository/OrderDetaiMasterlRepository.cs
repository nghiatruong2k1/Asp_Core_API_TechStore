
using Application.Areas.Admin.Interface;
using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Repository
{
    public class OrderDetailMasterRepository
    {
        TechStoreContext db;
        public OrderDetailMasterRepository(TechStoreContext _db)
        {
            db = _db;
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
        public async Task<int> Update(OrderDetail0256 order)
        {
            if (db != null)
            {
                db.OrderDetail0256s.Update(order);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            if (db != null)
            {
                OrderDetail0256 order = await db.OrderDetail0256s.FirstOrDefaultAsync(x => x.Id == id);
                if (order != null)
                {
                    db.OrderDetail0256s.Remove(order);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<int> DeleteByOrderId(int id)
        {
            if (db != null)
            {
                db.OrderDetail0256s.RemoveRange(
                    db.OrderDetail0256s.Where(o=>o.OrderId == id).ToArray()
                );
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<List<ViewOrderDetail0256>> Gets(int limit, int offset)
        {
            return await Gets(false, limit, offset);
        }
        public async Task<List<ViewOrderDetail0256>> Gets(Boolean isTrash, int limit, int offset)
        {
            if (db != null)
            {
                if (limit > 0)
                {
                    return await db.ViewOrderDetail0256s.Where(p => p.IsTrash == isTrash).OrderByDescending(p => p.Id).Skip(offset).Take(limit).ToListAsync();
                }
                else
                {
                    return await db.ViewOrderDetail0256s.Where(p => p.IsTrash == isTrash).OrderByDescending(p => p.Id).ToListAsync();
                }
            }

            return null;
        }
        public async Task<int> GetCount()
        {
            return await GetCount(true);
        }
        public async Task<int> GetCount(Boolean isTrash)
        {
            if (db != null)
            {
                return await db.ViewOrderDetail0256s.Where(p => p.IsTrash == isTrash).CountAsync();
            }

            return 0;
        }

        public async Task<ViewOrderDetail0256> Get(int id)
        {
            if (db != null)
            {
                if (id > 0)
                {
                    return await db.ViewOrderDetail0256s.FirstOrDefaultAsync(p => p.Id == id);
                }
            }

            return null;
        }
    }
}
