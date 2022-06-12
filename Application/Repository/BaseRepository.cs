using Application.Helper;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class BaseRepository
    {
        protected ConvertString convert = new ConvertString();
        protected TechStoreContext db;

        public BaseRepository(TechStoreContext db)
        {
            this.db = db;
        }

    }
}
