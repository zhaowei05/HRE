using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace IDAL
{
    public interface ILeaveDAL:IBaseDAL<Leave>
    {
        List<Leave> GetPage(Leave entity,int PageIndex,int PageSize,out int count);
    }
}
