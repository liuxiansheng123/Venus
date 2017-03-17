using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMODEL;

namespace VDAL
{
    public class UserinfoDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        /// <summary>
        ///用户表的显示
        /// </summary>
        /// <returns></returns>
        public List<UserinfoModel> UserinfoList()
        {
            string str = @"SELECT [Userid]
      ,[Username]
      ,[Userpwd]
      ,[Userrole]
      ,[Usercheng]
      ,[Usersex]
      ,[Userstate]
  FROM [dbo].[UserInfo]";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            List<UserinfoModel> list = new List<UserinfoModel>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserinfoModel mm = new UserinfoModel();
                mm.Userid = Convert.ToInt32(reader["Userid"].ToString());
                mm.Username = reader["Username"].ToString();
                mm.Userpwd = reader["Userpwd"].ToString();
                mm.Userrole = Convert.ToInt32(reader["Userrole"].ToString());
                mm.Usercheng = reader["Usercheng"].ToString();
                mm.Usersex = Convert.ToInt32(reader["Usersex"].ToString());
                mm.Userstate = Convert.ToInt32(reader["Userstate"].ToString());
                list.Add(mm);
            }
            con.Close();
            return list;
        }

        /// <summary>
        /// 用户表的注册
        /// </summary>
        /// <returns></returns>
        public int UserinfoADD(UserinfoModel mm)
        {
            string str = string.Format(@"INSERT INTO [dbo].[UserInfo]
           ([Username]
           ,[Userpwd]
           ,[Userrole]
           ,[Usercheng]
           ,[Usersex]
           ,[Userstate])
     VALUES
           ('{0}','{1}','{2}','{3}','{4}','{5}')", mm.Username, mm.Userpwd, mm.Userrole, mm.Usercheng, mm.Usersex, mm.Userstate);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 用户表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int UserinfoDelete(UserinfoModel mm)
        {
            string str = string.Format(@"
DELETE FROM [dbo].[UserInfo]
      WHERE  Userid='{0}'", mm.Userid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 用户表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int UserinfoUpdate(UserinfoModel mm)
        {
            string str = string.Format(@"UPDATE [dbo].[UserInfo]
   SET [Userpwd] = '{0}'
      ,[Usercheng] = '{1}'
      ,[Usersex] = '{2}'
 WHERE Userid='{3}' ",mm.Userpwd, mm.Usercheng, mm.Usersex, mm.Userid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 判断用户名是否已存在
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int UserinfoCount(UserinfoModel mm)
        {
            string str = string.Format(@"SELECT count(1) [Username]  FROM [dbo].[UserInfo] where Username='{0}'", mm.Username);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            return i;
        }


        /// <summary>
        ///用户登录时判断是否存在该用户
        /// </summary>
        /// <returns></returns>
        public int UserinfoLogin(UserinfoModel mm)
        {
            string str = string.Format(@"SELECT   [Userid] ,[Username] ,[Userpwd]  FROM [dbo].[UserInfo] 
            where [Username]='{0}' and [Userpwd]='{1}'", mm.Username, mm.Userpwd);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            int i = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            return i;
        }
    }
}
