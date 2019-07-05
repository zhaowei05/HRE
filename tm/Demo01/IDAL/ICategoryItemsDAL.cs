using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace IDAL
{
    public interface ICategoryItemsDAL:IBaseDAL<CategoryItems>
    {
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="TablName"></param>
        /// <returns></returns>
        List<CategoryItems> GetTable(string TablName);
    }
}
