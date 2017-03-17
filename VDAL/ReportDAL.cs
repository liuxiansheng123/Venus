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
    /// 举报表
    /// </summary>
    public class ReportDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        /// <summary>
        ///举报表的显示
        /// </summary>
        /// <returns></returns>
        public List<ReportModel> ReportList()
        {
            List<ReportModel> list = new List<ReportModel>();
            string str = @"SELECT [Reportid]
              ,[ReportUserid]
              ,[Beiuserid]
              ,[Beireviewcontent]
              ,[Reviewid]
              ,[Reportstate]
               FROM [dbo].[Report]";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReportModel mm = new ReportModel();
                mm.Reportid = Convert.ToInt32(reader["Reportid"].ToString());
                mm.ReportUserid = Convert.ToInt32(reader["ReportUserid"].ToString());
                mm.Beiuserid = Convert.ToInt32(reader["Beiuserid"].ToString());
                mm.Beireviewcontent = reader["Beireviewcontent"].ToString();
                mm.Reviewid = Convert.ToInt32(reader["Reviewid"].ToString());
                mm.Reportstate = Convert.ToInt32(reader["Reportstate"].ToString());
                list.Add(mm);
            }
            con.Close();
            return list;
        }

        /// <summary>
        /// 举报表的添加
        /// </summary>
        /// <returns></returns>
        public int ReportADD(ReportModel mm)
        {
            string str = string.Format(@"INSERT INTO [dbo].[Report]
           ([ReportUserid]
           ,[Beiuserid]
           ,[Beireviewcontent]
           ,[Reviewid]
           ,[Reportstate])
     VALUES
           ('{0}','{1}','{2}','{3}','{4}')",mm.ReportUserid,mm.Beiuserid,mm.Beireviewcontent,mm.Reviewid,mm.Reportstate);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 举报表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReportDelete(ReportModel mm)
        {
            string str = string.Format(@"DELETE FROM [dbo].[Report]
      WHERE Reportid='{0}' ", mm.Reportid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 举报表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int ReportUpdate(ReportModel mm)
        {
            string str = string.Format(@"UPDATE [dbo].[Report]
   SET [ReportUserid] = '{0}'
      ,[Beiuserid] = '{1}'
      ,[Beireviewcontent] ='{2}' 
      ,[Reviewid] = '{3}'
      ,[Reportstate] ='{4}' 
 WHERE Reportid='{5}' ", mm.ReportUserid, mm.Beiuserid, mm.Beireviewcontent, mm.Reviewid, mm.Reportstate, mm.Reportid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
