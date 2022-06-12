using Application.Areas.Admin.Interface;
using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Repository
{
    public class ProductImageMasterRepository
    {
        TechStoreContext db;
        public ProductImageMasterRepository(TechStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(ProductImage0256 image)
        {
            if (db != null)
            {
                await db.ProductImage0256s.AddAsync(image);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Adds(List<ProductImage0256> images)
        {
            if (db != null)
            {
                await db.ProductImage0256s.AddRangeAsync(images);
                return await db.SaveChangesAsync();
               ;
            }

            return 0;
        }
        public async Task<int> Update(ProductImage0256 image)
        {
            if (db != null)
            {
                db.ProductImage0256s.Update(image);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            if (db != null)
            {
                ProductImage0256 image = await db.ProductImage0256s.FirstOrDefaultAsync(x => x.Id == id);
                if (image != null)
                {
                    db.ProductImage0256s.Remove(image);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<int> DeleteByProductId(int id)
        {
            if (db != null)
            {
                List<ProductImage0256> images = await db.ProductImage0256s.Where(x => x.ProductId == id).ToListAsync();
                if (images != null)
                {
                    db.ProductImage0256s.RemoveRange(images);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<int> DeleteByImageId(int id)
        {
            if (db != null)
            {
                List<ProductImage0256> images = await db.ProductImage0256s.Where(x => x.ImageId == id).ToListAsync();
                if (images != null)
                {
                    db.ProductImage0256s.RemoveRange(images);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<List<ViewProductImage0256>> Gets(int productId,int limit, int offset)
        {
            return await Gets(false,productId, limit, offset);
        }
        public async Task<List<ViewProductImage0256>> Gets(Boolean isTrash,int productId, int limit, int offset)
        {
            if (db != null)
            {
                var lst = db.ViewProductImage0256s.Where(p => p.IsTrash == isTrash && p.ProductId == productId).OrderByDescending(p => p.Id);
                if (limit > 0)
                {
                    return await db.ViewProductImage0256s.Where(p => p.IsTrash == isTrash && p.ProductId == productId).OrderByDescending(p => p.Id).Skip(offset).Take(limit).ToListAsync();
                }
                else
                {
                    return await db.ViewProductImage0256s.Where(p => p.IsTrash == isTrash && p.ProductId == productId).OrderByDescending(p => p.Id).ToListAsync();
                }
            }

            return null;
        }
        public async Task<int> GetCount(int productId)
        {
            return await GetCount(true,productId);
        }
        public async Task<int> GetCount(Boolean isTrash, int productId)
        {
            if (db != null)
            {
                return await db.ProductImage0256s.Where(p => p.IsTrash == isTrash && p.ProductId == productId).CountAsync();
            }

            return 0;
        }

        public async Task<ProductImage0256> Get(int id)
        {
            if (db != null)
            {
                if (id > 0)
                {
                    return await db.ProductImage0256s.FirstOrDefaultAsync(p => p.Id == id);
                }
            }

            return null;
        }
    }
}
