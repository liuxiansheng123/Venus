using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMODEL
{
    /// <summary>
    /// 点赞表
    /// </summary>
    public class LikesModel
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int Worksid { get; set; }
    }
}
