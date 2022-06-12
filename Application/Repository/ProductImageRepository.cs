using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ProductImageRepository : BaseRepository
    {
        public ProductImageRepository(TechStoreContext _db) : base(_db)
        {

        }
        public async Task<List<ViewProductImage0256>> GetsByProduct(int id)
        {
            if (db != null)
            {
                return await db.ViewProductImage0256s
                    .Where(i => i.ProductId == id && i.IsTrash == false && i.IsPublic == true)
                    .ToListAsync();
            }

            return null;
        }
    }
}
