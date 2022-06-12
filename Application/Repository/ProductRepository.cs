using Application.Helper;
using Application.Interface;
using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(TechStoreContext _db) :base(_db)
        {
           
        }
        
        public async Task<ViewProduct0256> Get(String alias)
        {
            if (db != null)
            {
                return await db.ViewProduct0256s
                    .FirstOrDefaultAsync(
                        p => p.Alias.Equals(alias) 
                        && p.IsPublic == true
                        && p.IsTrash == false
                    );
            }

            return null;
        }
        public async Task<ViewProduct0256> Get(int id)
        {
            if (db != null)
            {
                return await db.ViewProduct0256s
                    .FirstOrDefaultAsync(
                        p => p.Id == id
                        && p.IsPublic == true
                        && p.IsTrash == false
                    );
            }

            return null;
        }
        public async Task<List<ViewProduct0256>> Gets(int limit, int offset)
        {
            return await Gets(limit, offset, "");
        }
        public async Task<List<ViewProduct0256>> Gets(int limit, int offset,String sort)
        {
            if (db != null)
            {
                var getter = GetsWithSort(db.ViewProduct0256s
                    .Where(p => p.IsPublic == true
                        && p.IsTrash == false
                    ),sort);
                if (limit > 0)
                {
                    return await getter .Skip(offset).Take(limit).ToListAsync();
                }
                else
                {
                    return await getter .Skip(offset).ToListAsync();
                }
            }

            return null;
        }
        public async Task<int> GetCount()
        {
            if (db != null)
            {
                var getter = db.ViewProduct0256s
                   .Where(p => p.IsPublic == true
                       && p.IsTrash == false
                   )
                   .OrderByDescending(p => p.CreateDate);
                return await getter.CountAsync();
            }

            return 0;
        }
        public async Task<List<ViewProduct0256>> GetsByBrand(int id, int limit,int offset)
        {
            return await GetsByBrand(id, limit, offset, "");
        }
        public async Task<List<ViewProduct0256>> GetsByBrand(int id, int limit, int offset, String sort)
        {
            if (db != null)
            {
                var getter = GetsWithSort(db.ViewProduct0256s
                   .Where(p => p.BrandId == id
                       && p.IsPublic == true
                       && p.IsTrash == false
                   ),sort);
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
        public async Task<int> GetCountByBrand(int id)
        {
            if (db != null)
            {
                return await db.ViewProduct0256s
                    .Where(p => p.BrandId == id 
                        && p.IsPublic == true 
                        && p.IsTrash == false
                    ).CountAsync();
            }

            return 0;
        }
        public async Task<List<ViewProduct0256>> GetsByCategory(int id, int limit, int offset)
        {
            return await GetsByCategory(id, limit, offset, "Id");
        }
        public async Task<List<ViewProduct0256>> GetsByCategory(int id, int limit, int offset,String sort)
        {
            if (db != null)
            {
                var getter = GetsWithSort(db.ViewProduct0256s
                   .Where(p => p.CategoryId == id
                       && p.IsPublic == true
                       && p.IsTrash == false
                   ),sort);
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
        public async Task<int> GetCountByCategory(int id)
        {
            if (db != null)
            {
                return await db.ViewProduct0256s
                    .Where(p => p.CategoryId == id 
                        && p.IsPublic == true 
                        && p.IsTrash == false
                    ).CountAsync();
            }

            return 0;
        }



        public async Task<List<ViewProduct0256>> GetsByType(int id, int limit, int offset)
        {
            if (db != null)
            {
                var getter = db.ViewProduct0256s
                    .Where(p => p.TypeId == id
                        && p.IsPublic == true
                        && p.IsTrash == false
                    ).OrderByDescending(p => p.CreateDate);
                if(limit > 0)
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

        public async Task<int> GetCountByType(int id)
        {
            if (db != null)
            {
                var getter = db.ViewProduct0256s
                   .Where(p => p.TypeId == id
                       && p.IsPublic == true
                       && p.IsTrash == false
                   ).OrderByDescending(p => p.CreateDate);
                return await getter.CountAsync();
            }

            return 0;
        }

        public async Task<List<ViewProduct0256>> GetsBySearch(String query, int limit, int offset)
        {
            return await GetsBySearch(query, limit, offset, "");
        }
        public async Task<List<ViewProduct0256>> GetsBySearch(String query, int limit, int offset, String sort)
        {
            string alias = convert.getAlias(query);
            string lowerQuery = query.ToLower();
            if (db != null)
            {
                var getter = GetsWithSort(db.ViewProduct0256s
                  .Where(p =>
                      (
                      p.Name.ToLower().Contains(lowerQuery)
                          || p.Alias.Contains(alias)
                          || p.ShortDes.ToLower().Contains(lowerQuery)
                          || p.CategoryName.ToLower().Contains(lowerQuery)
                          || p.BrandName.ToLower().Contains(lowerQuery)
                      )
                      && p.IsPublic == true
                      && p.IsTrash == false
                  ),sort);

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

        public async Task<int> GetCountBySearch(string query)
        {
            if (db != null)
            {
                string alias = convert.getAlias(query);
                string lowerQuery = query.ToLower();
                var getter = db.ViewProduct0256s
                     .Where(p =>
                         (
                         p.Name.ToLower().Contains(lowerQuery)
                             || p.Alias.Contains(alias)
                             || p.ShortDes.ToLower().Contains(lowerQuery)
                             || p.CategoryName.ToLower().Contains(lowerQuery)
                             || p.BrandName.ToLower().Contains(lowerQuery)
                         )
                         && p.IsPublic == true
                         && p.IsTrash == false
                     ).OrderByDescending(p => p.CreateDate);

                return await getter.CountAsync();
            }

            return 0;
        }
        protected IQueryable<ViewProduct0256> GetsWithSort(IQueryable<ViewProduct0256> getter, String sort)
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
                    case "Price":
                        {
                            return getter.OrderBy(x => x.SalePrice);
                        }
                    case "Price_Desc":
                        {
                            return getter.OrderByDescending(x => x.SalePrice);
                        }
                    case "Rating":
                        {
                            return getter.OrderBy(x => x.Rating);
                        }
                    case "Rating_Desc":
                        {
                            return getter.OrderByDescending(x => x.Rating);
                        }
                    case "Id":
                        {
                            return getter.OrderBy(x => x.Id);
                        }
                }
            }
            return getter.OrderByDescending(x => x.Id);
        }
    }
}
