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
    public class CollectDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        /// <summary>
        ///收藏表的显示
        /// </summary>
        /// <returns></returns>
        public List<CollectModel> CollectList()
        {
            List<CollectModel> list = new List<CollectModel>();
            string str = @"SELECT
	collectid,
	Worksid,
	Userid
    FROM
	Collect";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CollectModel mm = new CollectModel();
                mm.collectid = Convert.ToInt32(reader["collectid"].ToString());
                mm.Worksid = Convert.ToInt32(reader["Worksid"].ToString());
                mm.Userid = Convert.ToInt32(reader["Userid"].ToString());
                list.Add(mm);
            }
            con.Close();
            return list;
        }

        /// <summary>
        /// 收藏表的添加
        /// </summary>
        /// <returns></returns>
        public int CollectADD(CollectModel mm)
        {
            string str = string.Format(@"INSERT INTO [dbo].[Collect]
           ([Worksid]
           ,[Userid])
              VALUES
           ('{0}','{1}')", mm.Worksid, mm.Userid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 收藏表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int CollectDelete(CollectModel mm)
        {
            string str = string.Format(@"DELETE FROM [dbo].[Collect]
            WHERE  collectid='{0}'", mm.collectid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 收藏表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int CollectUpdate(CollectModel mm)
        {
            string str = string.Format(@"UPDATE [dbo].[Collect]
         SET [Worksid] = '{0}'
        ,[Userid] = '{1}'
         WHERE collectid='{2}' ", mm.Worksid, mm.Userid, mm.collectid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
        /// <summary>
        /// 根据作品id查询该作品被收藏人数
        /// </summary>
        /// <returns></returns>
        public int CollectCount(int worksid)
        {
            string str = "select COUNT(*) from Collect where Worksid="+worksid+"";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str,con);
            int i =Convert.ToInt32( command.ExecuteScalar());
            con.Close();
            return i;
        }
        
    }
}
