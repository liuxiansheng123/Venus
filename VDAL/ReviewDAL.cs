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
    public class ReviewDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        /// <summary>
        ///评论表的显示
        /// </summary>
        /// <returns></returns>
        public List<ReviewModel> ReviewList()
        {
            List<ReviewModel> list = new List<ReviewModel>();
            string str = @"
SELECT [Reviewid]
      ,[Worksid]
      ,[Userid]
      ,[Reviewcontent]
      ,[Reviewstate]
  FROM [dbo].[Review]";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReviewModel mm = new ReviewModel();
                mm.Reviewid = Convert.ToInt32(reader["Reviewid"].ToString());
                mm.Worksid = Convert.ToInt32(reader["Worksid"].ToString());
                mm.Userid = Convert.ToInt32(reader["Userid"].ToString());
                mm.Reviewcontent = reader["Reviewcontent"].ToString();
                mm.Reviewstate = Convert.ToDateTime(reader["Reviewstate"].ToString());
                list.Add(mm);
            }
            con.Close();
            return list;
        }

        /// <summary>
        /// 评论表的添加
        /// </summary>
        /// <returns></returns>
        public int ReviewADD(ReviewModel mm)
        {
            string str = string.Format(@"INSERT INTO [dbo].[Review]
           ([Worksid]
           ,[Userid]
           ,[Reviewcontent]
           ,[Reviewstate])
     VALUES
           ('{0}','{1}','{2}','{3}')", mm.Worksid, mm.Userid, mm.Reviewcontent, mm.Reviewstate);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 评论表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReviewDelete(ReviewModel mm)
        {
            string str = string.Format(@"DELETE FROM [dbo].[Review]
      WHERE Reviewid='{0}'", mm.Reviewid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 评论表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReviewUpdate(ReviewModel mm)
        {
            string str = string.Format(@"UPDATE [dbo].[Review]
     SET [Worksid] = '{0}'
      ,[Userid] =  '{1}'
      ,[Reviewcontent] ='{2}' 
      ,[Reviewstate] =  '{3}'
 WHERE Reviewid='{4}'", mm.Worksid, mm.Userid, mm.Reviewcontent, mm.Reviewstate, mm.Reviewid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
       
    }
}
