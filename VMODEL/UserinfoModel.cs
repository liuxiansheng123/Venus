using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMODEL
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserinfoModel
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Userpwd { get; set; }
        public int Userrole { get; set; }
        public string Usercheng { get; set; }
        public int Usersex { get; set; }
        public int Userstate { get; set; }
    }
}
