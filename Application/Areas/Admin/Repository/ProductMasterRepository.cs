using Application.Areas.Admin.Interface;
using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Repository
{
    public class ProductMasterRepository
    {
        TechStoreContext db;
        public ProductMasterRepository(TechStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(Product0256 product)
        {
            if (db != null)
            {
                product.CreateDate = DateTime.Now;
                await db.Product0256s.AddAsync(product);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Adds(List<Product0256> products)
        {
            if (db != null)
            {
                foreach(var product in products)
                {
                    product.CreateDate = DateTime.Now;
                }
                await db.Product0256s.AddRangeAsync(products);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Update(Product0256 product)
        {
            if (db != null)
            {
                product.UpdateDate = DateTime.Now;
                db.Product0256s.Update(product);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Updates(List<Product0256> products)
        {
            if (db != null)
            {
               
                foreach (var product in products)
                {
                    product.UpdateDate = DateTime.Now;
                }
                db.Product0256s.UpdateRange(products);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            if (db != null)
            {
                Product0256 product = await db.Product0256s.FirstOrDefaultAsync(x => x.Id == id);
                if (product != null)
                {
                    db.Product0256s.Remove(product);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<List<ViewProduct0256>> Gets(int limit, int offset)
        {
            return await Gets(false, limit, offset);
        }
        public async Task<List<ViewProduct0256>> Gets(Boolean isTrash, int limit, int offset)
        {
            return await Gets(isTrash,"", limit, offset);
        }
        public async Task<List<ViewProduct0256>> Gets(Boolean isTrash,String sort, int limit, int offset)
        {
            if (db != null)
            {
                var getter = GetsWithSort(db.ViewProduct0256s.Where(p => p.IsTrash == isTrash), sort);
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
                    case "SalePrice":
                        {
                            return getter.OrderBy(x => x.SalePrice);
                        }
                    case "SalePrice_Desc":
                        {
                            return getter.OrderByDescending(x => x.SalePrice);
                        }
                    case "Price":
                        {
                            return getter.OrderBy(x => x.Price);
                        }
                    case "Price_Desc":
                        {
                            return getter.OrderByDescending(x => x.Price);
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
        public async Task<int> GetCount()
        {
            return await GetCount(true);
        }
        public async Task<int> GetCount(Boolean isTrash)
        {
            if (db != null)
            {
                return await db.ViewProduct0256s.Where(p => p.IsTrash == isTrash).CountAsync();
            }

            return 0;
        }

        public async Task<ViewProduct0256> Get(int id)
        {
            if (db != null)
            {
                if (id > 0)
                {
                    return await db.ViewProduct0256s.FirstOrDefaultAsync(p => p.Id == id);
                }
            }

            return null;
        }
    }
}
