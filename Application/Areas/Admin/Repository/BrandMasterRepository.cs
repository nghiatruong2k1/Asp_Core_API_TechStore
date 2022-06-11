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
    public class BrandMasterRepository
    {
        TechStoreContext db;
        public BrandMasterRepository(TechStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(Brand0256 brand)
        {
            if (db != null)
            {
                brand.CreateDate = DateTime.Now;
                await db.Brand0256s.AddAsync(brand);
                return await db.SaveChangesAsync();

            }

            return 0;
        }
        public async Task<int> Update(Brand0256 brand)
        {
            if (db != null)
            {
                brand.UpdateDate = DateTime.Now;
                db.Brand0256s.Update(brand);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            if (db != null)
            {
                Brand0256 brand = await db.Brand0256s.FirstOrDefaultAsync(x => x.Id == id);
                if (brand != null)
                {
                    db.Brand0256s.Remove(brand);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<List<ViewBrand0256>> Gets(int limit, int offset)
        {
            return await Gets(false, limit, offset);
        }
        public async Task<List<ViewBrand0256>> Gets(Boolean isTrash, int limit, int offset)
        {
            return await Gets(isTrash, "", limit, offset);
        }
        public async Task<List<ViewBrand0256>> Gets(Boolean isTrash, String sort, int limit, int offset)
        {
            if (db != null)
            {
                var getter = GetsWithSort(db.ViewBrand0256s.Where(p => p.IsTrash == isTrash), sort);
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
        protected IQueryable<ViewBrand0256> GetsWithSort(IQueryable<ViewBrand0256> getter, String sort)
        {
            if (sort != null && !sort.Equals(""))
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
                return await db.ViewBrand0256s.Where(p => p.IsTrash == isTrash).CountAsync();
            }

            return 0;
        }

        public async Task<ViewBrand0256> Get(int id)
        {
            if (db != null)
            {
                if (id > 0)
                {
                    return await db.ViewBrand0256s.FirstOrDefaultAsync(p => p.Id == id);
                }
            }

            return null;
        }
    }
}
