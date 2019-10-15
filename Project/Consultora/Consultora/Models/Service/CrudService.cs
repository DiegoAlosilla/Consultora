using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultoraAPI.Models.Service
{
    public interface CrudService<T>
    {
        bool Save(T t);
        bool Update(T t);
        bool Delete(int? id);
        List<T> FindAll();
        T FindById(int? id);
    }
}
