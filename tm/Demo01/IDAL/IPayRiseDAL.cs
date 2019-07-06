using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IPayRiseDAL:IBaseDAL<PayRise>
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
