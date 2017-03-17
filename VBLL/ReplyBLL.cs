using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMODEL;
using VDAL;

namespace VBLL
{
    public class ReplyBLL
    {
        ReplyDAL dal = new ReplyDAL();
        /// <summary>
        ///回复表的显示
        /// </summary>
        /// <returns></returns>
        public List<ReplyModel> ReplyList()
        {
            return dal.ReplyList();
        }

        /// <summary>
        /// 回复表的添加
        /// </summary>
        /// <returns></returns>
        public int ReplyADD(ReplyModel mm)
        {
            return dal.ReplyADD(mm);
        }

        /// <summary>
        ///回复表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReplyDelete(ReplyModel mm)
        {
            return dal.ReplyDelete(mm);
        }

        /// <summary>
        /// 回复表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReplyUpdate(ReplyModel mm)
        {
            return dal.ReplyUpdate(mm);
        }
    }
}
