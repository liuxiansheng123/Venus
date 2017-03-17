using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMODEL;
using VDAL;

namespace VBLL
{
    public class ReportBLL
    {
        ReportDAL dal = new ReportDAL();
        /// <summary>
        ///举报表的显示
        /// </summary>
        /// <returns></returns>
        public List<ReportModel> ReportList()
        {
            return dal.ReportList();
        }

        /// <summary>
        /// 举报表的添加
        /// </summary>
        /// <returns></returns>
        public int ReportADD(ReportModel mm)
        {
            return dal.ReportADD(mm);
        }

        /// <summary>
        /// 举报表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReportDelete(ReportModel mm)
        {
            return dal.ReportDelete(mm);
        }

        /// <summary>
        /// 举报表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReportUpdate(ReportModel mm)
        {
            return dal.ReportUpdate(mm);
        }
    }
}
