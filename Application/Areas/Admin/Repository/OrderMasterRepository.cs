
using Application.Areas.Admin.Interface;
using Application.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Repository
{
    public class OrderMasterRepository
    {
        TechStoreContext db;
        public OrderMasterRepository(TechStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(Order0256 order)
        {
            if (db != null)
            {
                order.CreateDate = DateTime.Now;
                await db.Order0256s.AddAsync(order);
                return await db.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Update(Order0256 order)
        {
            if (db != null)
            {
                order.UpdateDate = DateTime.Now;
                db.Order0256s.Update(order);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            if (db != null)
            {
                Order0256 order = await db.Order0256s.FirstOrDefaultAsync(x => x.Id == id);
                if (order != null)
                {
                    db.Order0256s.Remove(order);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;
        }
        public async Task<List<ViewOrder0256>> Gets(int limit, int offset)
        {
            return await Gets(false, limit, offset);
        }
        public async Task<List<ViewOrder0256>> Gets(Boolean isTrash, int limit, int offset)
        {
            return await Gets(isTrash,"", limit, offset);
        }
        public async Task<List<ViewOrder0256>> Gets(Boolean isTrash,String sort, int limit, int offset)
        {
            if (db != null)
            {
                var getter = GetsWithSort(db.ViewOrder0256s.Where(p => p.IsTrash == isTrash), sort);
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
        protected IQueryable<ViewOrder0256> GetsWithSort(IQueryable<ViewOrder0256> getter, String sort)
        {
            if (sort != null && !sort.Equals(""))
            {
                switch (sort)
                {
                    case "Email":
                        {
                            return getter.OrderBy(x => x.Email);
                        }
                    case "Email_Desc":
                        {
                            return getter.OrderByDescending(x => x.Email);
                        }
                    case "FirstName":
                        {
                            return getter.OrderBy(x => x.FirstName);
                        }
                    case "FirstName_Desc":
                        {
                            return getter.OrderByDescending(x => x.FirstName);
                        }
                    case "LastName":
                        {
                            return getter.OrderBy(x => x.LastName);
                        }
                    case "LastName_Desc":
                        {
                            return getter.OrderByDescending(x => x.LastName);
                        }
                    case "StatusName":
                        {
                            return getter.OrderBy(x => x.StatusName);
                        }
                    case "StatusName_Desc":
                        {
                            return getter.OrderByDescending(x => x.StatusName);
                        }
                    case "Location":
                        {
                            return getter.OrderBy(x => x.Location);
                        }
                    case "Location_Desc":
                        {
                            return getter.OrderByDescending(x => x.Location);
                        }

                    case "CreateDate":
                        {
                            return getter.OrderBy(x => x.CreateDate);
                        }
                    case "CreateDate_Desc":
                        {
                            return getter.OrderByDescending(x => x.CreateDate);
                        }
                    case "Id":
                        {
                            return getter.OrderBy(x => x.Id);
                        }
                }
            }
            return getter.OrderByDescending(x => x.Id);
        }
        public async Task<List<ViewStatisOrder0256>> getStatistic()
        {
            if (db != null)
            {
                return await db.ViewStatisOrder0256s.OrderBy(o => o.CreateDate).ToListAsync();
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
                return await db.ViewOrder0256s.Where(p => p.IsTrash == isTrash).CountAsync();
            }

            return 0;
        }

        public async Task<ViewOrder0256> Get(int id)
        {
            if (db != null)
            {
                if (id > 0)
                {
                    return await db.ViewOrder0256s.FirstOrDefaultAsync(p => p.Id == id);
                }
            }

            return null;
        }
    }
}
