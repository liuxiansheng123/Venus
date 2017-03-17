using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMODEL;
using VDAL;

namespace VBLL
{
    public class ReviewBLL
    {

        ReviewDAL dal = new ReviewDAL();
        /// <summary>
        ///评论表的显示
        /// </summary>
        /// <returns></returns>
        public List<ReviewModel> ReviewList()
        {
            return dal.ReviewList();
        }

        /// <summary>
        /// 评论表的添加
        /// </summary>
        /// <returns></returns>
        public int ReviewADD(ReviewModel mm)
        {
            return dal.ReviewADD(mm);
        }

        /// <summary>
        /// 评论表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReviewDelete(ReviewModel mm)
        {
            return dal.ReviewDelete(mm);
        }

        /// <summary>
        /// 评论表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReviewUpdate(ReviewModel mm)
        {
            return dal.ReviewUpdate(mm);
        }
        
    }
}
