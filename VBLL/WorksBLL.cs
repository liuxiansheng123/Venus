using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMODEL;
using VDAL;

namespace VBLL
{
    public class WorksBLL
    {
        WorksDAL dal = new WorksDAL();
        /// <summary>
        ///作品表的显示
        /// </summary>
        /// <returns></returns>
        public List<WorksModel> WorksList()
        {
            return dal.WorksList();
        }
        /// <summary>
        /// 作品表的添加
        /// </summary>
        /// <returns></returns>
        public int WorksADD(WorksModel mm)
        {
            return dal.WorksADD(mm);
        }

        /// <summary>
        /// 作品表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int WorksDelete(WorksModel mm)
        {
            return dal.WorksDelete(mm);
        }

        /// <summary>
        /// 作品表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int WorksUpdate(WorksModel mm)
        {
            return dal.WorksUpdate(mm);
        }
        /// <summary>
        /// 根据作品id显示详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WorksModel idlist(int id)
        {
            return dal.idlist(id);
        }
        /// <summary>
        /// 最热
        /// </summary>
        /// <returns></returns>
        public List<WorksModel> WorkHot()
        {
            return dal.WorkHot();
        }
        /// <summary>
        ///作品表的显示
        /// </summary>
        /// <returns></returns>
        public List<WorksModel> Workshow(int i)
        {
            return dal.Workshow(i);
        }
    }
}
