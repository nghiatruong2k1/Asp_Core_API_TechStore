using Application.Interface;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Areas.Admin.Interface
{
    interface IBaseMasterRepository<V,R>
    {
        Task<int> Add(R item);

        Task<int> Delete(int id);

        Task<int> Update(R item);
        Task<V> Get(int id);
        Task<List<V>> Gets(int limit, int offset);
        Task<List<V>> Gets(Boolean isTrash, int limit, int offset);
        Task<int> GetCount();
        Task<int> GetCount(Boolean isTrash);
    }
}
