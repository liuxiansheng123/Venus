using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMODEL
{
    /// <summary>
    /// 回复表
    /// </summary>
    public class ReplyModel
    {
        public int ReplyID { get; set; }
        public string Replycontent { get; set; }
        public int Reviewid { get; set; }
        public DateTime Replydate { get; set; }
    }
}
