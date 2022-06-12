using Application.Areas.Admin.Interface;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Repository
{
    public class ProductTypeMasterRepository
    {
        TechStoreContext db;
        public ProductTypeMasterRepository(TechStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(ProductType0256 productType)
        {
            if (db != null)
            {
                await db.ProductType0256s.AddAsync(productType);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Update(ProductType0256 productType)
        {
            if (db != null)
            {
                db.ProductType0256s.Update(productType);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            if (db != null)
            {
                ProductType0256 productType = await db.ProductType0256s.FirstOrDefaultAsync(x => x.Id == id);
                if (productType != null)
                {
                    db.ProductType0256s.Remove(productType);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<List<ProductType0256>> Gets(int limit, int offset)
        {
            return await Gets(false, limit, offset);
        }
        public async Task<List<ProductType0256>> Gets(Boolean isTrash, int limit, int offset)
        {
            if (db != null)
            {
                if (limit > 0)
                {
                    return await db.ProductType0256s.Where(p => p.IsTrash == isTrash).OrderByDescending(p => p.Id).Skip(offset).Take(limit).ToListAsync();
                }
                else
                {
                    return await db.ProductType0256s.Where(p => p.IsTrash == isTrash).OrderByDescending(p => p.Id).ToListAsync();
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
                return await db.ProductType0256s.Where(p => p.IsTrash == isTrash).CountAsync();
            }

            return 0;
        }

        public async Task<ProductType0256> Get(int id)
        {
            if (db != null)
            {
                if (id > 0)
                {
                    return await db.ProductType0256s.FirstOrDefaultAsync(p => p.Id == id);
                }
            }

            return null;
        }
    }
}
