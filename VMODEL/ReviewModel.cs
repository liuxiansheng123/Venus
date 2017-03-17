using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMODEL
{
    /// <summary>
    /// 评论表
    /// </summary>
    public class ReviewModel
    {
        public int Reviewid { get; set; }
        public int Worksid { get; set; }
        public int Userid { get; set; }
        public string Reviewcontent { get; set; }
        public DateTime Reviewstate { get; set; }
    }
}
