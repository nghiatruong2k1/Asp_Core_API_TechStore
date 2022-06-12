using Application.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Repository
{
    public class CategoryMasterRepository
    {
        TechStoreContext db;
        public CategoryMasterRepository(TechStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(Category0256 category)
        {
            if (db != null)
            {
                category.CreateDate = DateTime.Now;
                await db.Category0256s.AddAsync(category);
                return await db.SaveChangesAsync();
                
            }

            return 0;
        }
        public async Task<int> Update(Category0256 category)
        {
            if (db != null)
            {
                category.UpdateDate = DateTime.Now;
                db.Category0256s.Update(category);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            if (db != null)
            {
                Category0256 category = await db.Category0256s.FirstOrDefaultAsync(x => x.Id == id);
                if (category != null)
                {
                    db.Category0256s.Remove(category);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<List<ViewCategory0256>> Gets(int limit, int offset)
        {
            return await Gets(false, limit, offset);
        }
        public async Task<List<ViewCategory0256>> Gets(Boolean isTrash, int limit, int offset)
        {
            return await Gets(isTrash,"", limit, offset);
        }
        public async Task<List<ViewCategory0256>> Gets(Boolean isTrash,String sort, int limit, int offset)
        {
            if (db != null)
            {
                var getter = GetsWithSort(db.ViewCategory0256s.Where(p => p.IsTrash == isTrash), sort);
                if (limit > 0)
                {
                    return await getter.Skip(offset).Take(limit).ToListAsync();
                }
                else
                {
                    return await getter.ToListAsync();
                }
            }

            return null;
        }
        protected IQueryable<ViewCategory0256> GetsWithSort(IQueryable<ViewCategory0256> getter, String sort)
        {
            if(sort != null && !sort.Equals(""))
            {
                switch (sort)
                {
                    case "Name":
                        {
                            return getter.OrderBy(x => x.Name);
                        }
                    case "Name_Desc":
                        {
                            return getter.OrderByDescending(x => x.Name);
                        }
                    case "CreateDate":
                        {
                            return getter.OrderBy(x => x.CreateDate);
                        }
                    case "CreateDate_Desc":
                        {
                            return getter.OrderByDescending(x => x.CreateDate);
                        }
                    case "UpdateDate":
                        {
                            return getter.OrderBy(x => x.UpdateDate);
                        }
                    case "UpdateDate_Desc":
                        {
                            return getter.OrderByDescending(x => x.UpdateDate);
                        }
                    case "IsPopular":
                        {
                            return getter.OrderBy(x => x.IsPopular);
                        }
                    case "IsPopular_Desc":
                        {
                            return getter.OrderByDescending(x => x.IsPopular);
                        }
                    case "Id":
                        {
                            return getter.OrderBy(x => x.Id);
                        }
                }
            }
            return getter.OrderByDescending(x => x.Id);
        }
        public async Task<int> GetCount()
        {
            return await GetCount(true);
        }
        public async Task<int> GetCount(Boolean isTrash)
        {
            if (db != null)
            {
                return await db.ViewCategory0256s.Where(p => p.IsTrash == isTrash).CountAsync();
            }

            return 0;
        }

        public async Task<ViewCategory0256> Get(int id)
        {
            if (db != null)
            {
                if (id > 0)
                {
                    return await db.ViewCategory0256s.FirstOrDefaultAsync(p => p.Id == id);
                }
            }

            return null;
        }
    }
}
