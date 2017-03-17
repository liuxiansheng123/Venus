using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDAL;
using VMODEL;

namespace VBLL
{
    public class CollectBLL
    {
        CollectDAL dal = new CollectDAL();
        public List<CollectModel> CollectList()
        {
            return dal.CollectList();
        }

        /// <summary>
        /// 收藏表的添加
        /// </summary>
        /// <returns></returns>
        public int CollectADD(CollectModel mm)
        {
            return dal.CollectADD(mm);
        }

        /// <summary>
        /// 收藏表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int CollectDelete(CollectModel mm)
        {
            return dal.CollectDelete(mm);
        }

        /// <summary>
        /// 收藏表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int CollectUpdate(CollectModel mm)
        {
            return dal.CollectUpdate(mm);
        }
        /// <summary>
        /// 根据作品id查询该作品被收藏人数
        /// </summary>
        /// <returns></returns>
        public int CollectCount(int worksid)
        {
            return dal.CollectCount(worksid);
        }
        
    }
}
