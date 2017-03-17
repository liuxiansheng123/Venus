using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMODEL
{
    /// <summary>
    /// 举报表
    /// </summary>
    public class ReportModel
    {
        public int Reportid { get; set; }
        public int ReportUserid { get; set; }
        public int Beiuserid { get; set; }
        public string Beireviewcontent { get; set; }
        public int Reviewid { get; set; }
        public int Reportstate { get; set; }

    }
}
