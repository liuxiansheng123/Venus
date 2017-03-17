using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMODEL;
using VDAL;

namespace VBLL
{
    public class UserinfoBLL
    {
        UserinfoDAL dal = new UserinfoDAL();
        /// <summary>
        /// 用户表的显示
        /// </summary>
        /// <returns></returns>
        public List<UserinfoModel> UserinfoList()
        {
            return dal.UserinfoList();
        }

        /// <summary>
        /// 用户表的注册
        /// </summary>
        /// <returns></returns>
        public int UserinfoADD(UserinfoModel mm)
        {
            return dal.UserinfoADD(mm);
        }

        /// <summary>
        /// 用户表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int UserinfoDelete(UserinfoModel mm)
        {
            return dal.UserinfoDelete(mm);
        }

        /// <summary>
        /// 用户表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int UserinfoUpdate(UserinfoModel mm)
        {
            return dal.UserinfoUpdate(mm);
        }

        /// <summary>
        /// 判断用户名是否已存在
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int UserinfoCount(UserinfoModel mm)
        {
            return dal.UserinfoCount(mm);
        }

        /// <summary>
        ///用户登录时判断是否存在该用户
        /// </summary>
        /// <returns></returns>
        public int UserinfoLogin(UserinfoModel mm)
        {
            return dal.UserinfoLogin(mm);
        }
    }
}
