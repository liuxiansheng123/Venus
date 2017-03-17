using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMODEL
{
    public class UserHomeMODEL<T>
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public List<T> datalist { get; set; }
        /// <summary>
        /// 作品数量
        /// </summary>
        public int Workscount { get; set; }
        /// <summary>
        /// 未审核数量
        /// </summary>
        public int NotWorkscount { get; set; }
        /// <summary>
        /// 已审核作品
        /// </summary>
        public int auditWorkscount { get; set; }
        /// <summary>
        /// 收藏数量
        /// </summary>
        public int Collectcount { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
        public int Reviewcount { get; set; }
    }
}
