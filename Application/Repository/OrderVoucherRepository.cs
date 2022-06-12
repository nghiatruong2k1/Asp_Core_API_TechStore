using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class OrderVoucherRepository : BaseRepository
    {
      
        public OrderVoucherRepository(TechStoreContext _db):base(_db)
        {
           
        }

        public async Task<OrderVoucher0256> Gets(string code)
        {
            if (db != null)
            {
                return await db.OrderVoucher0256s
                    .FirstOrDefaultAsync(
                        p => p.Code.Equals(code)
                        && p.IsPublic == true
                        && p.IsTrash == false
                    );
            }

            return null;
        }
    }
}
