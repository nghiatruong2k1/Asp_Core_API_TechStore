using Application.Areas.Admin.Interface;
using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Repository
{
    public class UserMasterRepository
    {
        TechStoreContext db;
        public UserMasterRepository(TechStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(User0256 user)
        {
            if (db != null)
            {
                user.CreateDate = DateTime.Now;
                await db.User0256s.AddAsync(user);
                await db.SaveChangesAsync();
                return user.Id;
            }

            return 0;
        }
        public async Task<int> Update(User0256 user)
        {
            if (db != null)
            {
                user.UpdateDate = DateTime.Now;
                db.User0256s.Update(user);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            if (db != null)
            {
                User0256 user = await db.User0256s.FirstOrDefaultAsync(x => x.Id == id);
                if (user != null)
                {
                    db.User0256s.Remove(user);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<List<ViewUser0256>> Gets(int limit, int offset)
        {
            return await Gets(false, limit, offset);
        }
        public async Task<List<ViewUser0256>> Gets(Boolean isTrash, int limit, int offset)
        {
            if (db != null)
            {
                if (limit > 0)
                {
                    return await db.ViewUser0256s.Where(p => p.IsTrash == isTrash).OrderByDescending(p => p.Id).Skip(offset).Take(limit).ToListAsync();
                }
                else
                {
                    return await db.ViewUser0256s.Where(p => p.IsTrash == isTrash).OrderByDescending(p => p.Id).ToListAsync();
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
                return await db.ViewUser0256s.Where(p => p.IsTrash == isTrash).CountAsync();
            }

            return 0;
        }

        public async Task<ViewUser0256> Get(int id)
        {
            if (db != null)
            {
                if (id > 0)
                {
                    return await db.ViewUser0256s.FirstOrDefaultAsync(p => p.Id == id);
                }
            }

            return null;
        }

        public async Task<List<ViewStatisUser0256>> getStatistic()
        {
            if (db != null)
            {
                return await db.ViewStatisUser0256s.OrderBy(p=>p.CreateDate).ToListAsync();
            }

            return null;
        }
    }
}
