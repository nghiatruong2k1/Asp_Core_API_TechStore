using Application.Areas.Admin.Interface;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Repository
{
    public class OrderStatusMasterRepository
    {
        TechStoreContext db;
        public OrderStatusMasterRepository(TechStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(OrderStatus0256 category)
        {
            if (db != null)
            {
                await db.OrderStatus0256s.AddAsync(category);
                return await db.SaveChangesAsync();
                
            }

            return 0;
        }
        public async Task<int> Update(OrderStatus0256 category)
        {
            if (db != null)
            {
                db.OrderStatus0256s.Update(category);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            if (db != null)
            {
                OrderStatus0256 category = await db.OrderStatus0256s.FirstOrDefaultAsync(x => x.Id == id);
                if (category != null)
                {
                    db.OrderStatus0256s.Remove(category);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<List<OrderStatus0256>> Gets(int limit, int offset)
        {
            return await Gets(false, limit, offset);
        }
        public async Task<List<OrderStatus0256>> Gets(Boolean isTrash, int limit, int offset)
        {
            if (db != null)
            {
                var getter = db.OrderStatus0256s.Where(p => p.IsTrash == isTrash);
                if (limit > 0)
                {
                    return await getter.OrderByDescending(p => p.Id).Skip(offset).Take(limit).ToListAsync();
                }
                else
                {
                    return await getter.OrderByDescending(p => p.Id).ToListAsync();
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
                return await db.OrderStatus0256s.Where(p => p.IsTrash == isTrash).CountAsync();
            }

            return 0;
        }

        public async Task<OrderStatus0256> Get(int id)
        {
            if (db != null)
            {
                if (id > 0)
                {
                    return await db.OrderStatus0256s.FirstOrDefaultAsync(p => p.Id == id);
                }
            }

            return null;
        }
    }
}
