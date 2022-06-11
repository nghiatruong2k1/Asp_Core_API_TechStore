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
    public class BrandRepository : BaseRepository
    {
       
        public BrandRepository(TechStoreContext _db) : base(_db)
        {
            
        }
        public async Task<int> GetCount()
        {
            if (db != null)
            {
                return await db.ViewBrand0256s
                    .Where(b => b.IsPublic == true
                        && b.IsTrash == false
                    )
                    .CountAsync();
            }

            return 0;
        }
        public async Task<ViewBrand0256> Get(String alias)
        {
            if (db != null)
            {
                return await db.ViewBrand0256s
                    .FirstOrDefaultAsync(
                        b => b.Alias.Equals(alias)
                        && b.IsPublic == true
                        && b.IsTrash == false
                    );
            }

            return null;
        }
        public async Task<List<ViewBrand0256>> Gets(int limit, int offset)
        {
            if (db != null)
            {
                var getter = db.ViewBrand0256s
                    .Where(b => b.IsPublic == true
                        && b.IsTrash == false
                    );
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
        public async Task<List<ViewBrand0256>> GetsBySearch(string query, int limit, int offset)
        {
            string alias = convert.getAlias(query);
            if (db != null)
            {
                var getter = db.ViewBrand0256s
                    .Where(p =>
                        (
                            p.Name.ToLower().Contains(query.ToLower())
                            || p.Alias.Contains(alias)
                        )
                        && p.IsPublic == true
                        && p.IsTrash == false
                    );
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
            string alias = convert.getAlias(query);
            if (db != null)
            {
                return await db.ViewBrand0256s
                    .Where(p =>
                        p.Name.ToLower().Contains(query.ToLower())
                        || p.Alias.Contains(alias)
                        && p.IsPublic == true
                        && p.IsTrash == false
                     )
                    .CountAsync();
            }

            return 0;
        }
    }
}
