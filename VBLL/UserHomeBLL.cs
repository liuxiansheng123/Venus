using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMODEL;
using VDAL;
namespace VBLL
{
    public class UserHomeBLL
    {
        /// <summary>
        /// 用户界面显示
        /// </summary>

        UserHomeDAl UH_dal = new UserHomeDAl();
        public UserHomeMODEL<UserinfoModel> UserHomeList(int id)
        {
            return UH_dal.UserHomeList(id);
        }
        /// <summary>
        /// 根据用户ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<WorksModel> Review(int id)
        {
            return UH_dal.Review(id);
        }
        /// <summary>
        /// 根据用户id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<WorksModel> Collect(int id)
        {
            return UH_dal.Collect(id);
        }
    }
}
