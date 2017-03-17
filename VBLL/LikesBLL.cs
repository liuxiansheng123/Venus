using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDAL;
using VMODEL;
namespace VBLL
{
    public class LikesBLL
    {
        LikesDAL dal = new LikesDAL();
        /// <summary>
        ///点赞表的显示
        /// </summary>
        /// <returns></returns>
        public List<LikesModel> LikesList()
        {
            return dal.LikesList();
        }
         /// <summary>
        ///点赞
        /// </summary>
        /// <returns></returns>
        public int LikesADD(LikesModel mm)
        {
            return dal.LikesADD(mm);
        }
        /// <summary>
        /// 消赞
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int LikesDelete(int workid, int userid)
        {
            return dal.LikesDelete(workid,userid);
        }
        /// <summary>
        /// 点赞表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int LikesUpdate(LikesModel mm)
        {
            return dal.LikesUpdate(mm);
        }
    }
}
