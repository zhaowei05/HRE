using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    interface IBaseBLL<T>
         where T : class, new()
    {
        List<T> GetList();
        T GetListyi(int id);
        int Add(T entity);
        int Delete(int id);
        int Update(T entity);
    }
}
