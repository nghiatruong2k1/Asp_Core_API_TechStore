using Application.Areas.Admin.Interface;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Repository
{
    public class ImageMasterRepository
    {
        TechStoreContext db;
        public ImageMasterRepository(TechStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(Image0256 image)
        {
            if (db != null)
            {
                image.CreateDate = DateTime.Now;
                await db.Image0256s.AddAsync(image);
                return await db.SaveChangesAsync();
                
            }

            return 0;
        }
        public async Task<int> Update(Image0256 image)
        {
            if (db != null)
            {
                image.UpdateDate = DateTime.Now;
                db.Image0256s.Update(image);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            if (db != null)
            {
                Image0256 image = await db.Image0256s.FirstOrDefaultAsync(x => x.Id == id);
                if (image != null)
                {
                    db.Image0256s.Remove(image);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<List<Image0256>> Gets(int limit, int offset)
        {
            return await Gets(false, limit, offset);
        }
        public async Task<List<Image0256>> Gets(Boolean isTrash, int limit, int offset)
        {
            if (db != null)
            {
                if (limit > 0)
                {
                    return await db.Image0256s.Where(p => p.IsTrash == isTrash && p.IsPublic == true).OrderByDescending(p => p.Id).Skip(offset).Take(limit).ToListAsync();
                }
                else
                {
                    return await db.Image0256s.Where(p => p.IsTrash == isTrash && p.IsPublic == true).OrderByDescending(p => p.Id).ToListAsync();
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
                return await db.Image0256s.Where(p => p.IsTrash == isTrash).CountAsync();
            }

            return 0;
        }

        public async Task<Image0256> Get(int id)
        {
            if (db != null)
            {
                if (id > 0)
                {
                    return await db.Image0256s.FirstOrDefaultAsync(p => p.Id == id);
                }
            }

            return null;
        }
    }
}
