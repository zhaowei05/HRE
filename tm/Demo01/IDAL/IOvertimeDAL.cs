using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace IDAL
{
    public interface IOvertimeDAL:IBaseDAL<Overtime>
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSiez"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<UserInfo> GetPage(UserInfo entity, int PageIndex, int PageSize, out int count);
    }
}
