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
    public class ReplyDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        /// <summary>
        ///回复表的显示
        /// </summary>
        /// <returns></returns>
        public List<ReplyModel> ReplyList()
        {
            List<ReplyModel> list = new List<ReplyModel>();
            string str = @"SELECT [ReplyID]
      ,[Replycontent]
      ,[Reviewid]
      ,[Replydate]
  FROM [dbo].[Reply]";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReplyModel mm = new ReplyModel();
                mm.ReplyID = Convert.ToInt32(reader["ReplyID"].ToString());
                mm.Replycontent = reader["Replycontent"].ToString();
                mm.Reviewid = Convert.ToInt32(reader["Reviewid"].ToString());
                mm.Replydate = Convert.ToDateTime(reader["Replydate"].ToString());
                list.Add(mm);
            }
            con.Close();
            return list;
        }

        /// <summary>
        /// 回复表的添加
        /// </summary>
        /// <returns></returns>
        public int ReplyADD(ReplyModel mm)
        {
            string str = string.Format(@"INSERT INTO [dbo].[Reply]
           ([Replycontent]
           ,[Reviewid]
           ,[Replydate])
     VALUES
           ('{0}','{1}','{2}')", mm.Replycontent, mm.Reviewid,mm.Replydate);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        ///回复表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReplyDelete(ReplyModel mm)
        {
            string str = string.Format(@"DELETE FROM [dbo].[Reply]
      WHERE Reviewid='{0}' ", mm.Reviewid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 回复表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReplyUpdate(ReplyModel mm)
        {
            string str = string.Format(@"UPDATE [dbo].[Reply]
   SET [Replycontent] ='{0}'
      ,[Reviewid] = '{1}'
      ,[Replydate] = '{2}'
 WHERE ReplyID='{3}'", mm.Replycontent, mm.Reviewid, mm.Replydate, mm.ReplyID);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
