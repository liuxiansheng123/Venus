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
    /// <summary>
    /// 点赞表
    /// </summary>
    public class LikesDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        /// <summary>
        ///点赞表的显示
        /// </summary>
        /// <returns></returns>
        public List<LikesModel> LikesList()
        {
            string str = @"SELECT [LikeId]
      ,[UserId]
      ,[Worksid]
       FROM [dbo].[likes]";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            List<LikesModel> list = new List<LikesModel>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LikesModel mm = new LikesModel();
                mm.LikeId = Convert.ToInt32(reader["LikeId"].ToString());
                mm.UserId = Convert.ToInt32(reader["UserId"].ToString());
                mm.Worksid = Convert.ToInt32(reader["Worksid"].ToString());
                list.Add(mm);
            }
            con.Close();
            return list;
        }

       

        /// <summary>
        /// 收藏表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int LikesUpdate(LikesModel mm)
        {
            string str = string.Format(@"UPDATE [dbo].[likes]
         SET [UserId] = '{0}'
        ,[Worksid] = '{1}'
        WHERE LikeId='{2}'", mm.UserId, mm.Worksid, mm.LikeId);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }







        /// <summary>
        ///点赞
        /// </summary>
        /// <returns></returns>
        public int LikesADD(LikesModel mm)
        {
            string str = string.Format(@"INSERT INTO [dbo].[likes]
           ([UserId]
           ,[Worksid])
     VALUES
           ('{0}','{1}')", mm.UserId, mm.Worksid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 消赞
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int LikesDelete(int workid, int userid)
        {
            string str = string.Format(@"delete from likes where Worksid=" + workid + " and UserId=" + userid + "");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }


    }
}
