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
    public class WorksDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        /// <summary>
        ///最新作品的显示
        /// </summary>
        /// <returns></returns>
        public List<WorksModel> WorksList()
        {
            string str = @"SELECT top(5) [Worksid]
      ,[Worksname]
      ,[Bra]
      ,[Size]
      ,[thickness]
      ,[Worksdate]
      ,[Worksstate]
      ,[Worksurl]
      ,[WorksCount]
      ,[Workcontent]
      ,[Userid]
  FROM [Venus].[dbo].[Works] order by worksdate desc";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            List<WorksModel> list = new List<WorksModel>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                WorksModel mm = new WorksModel();
                mm.Worksid = Convert.ToInt32(reader["Worksid"].ToString());
                mm.Worksname = reader["Worksname"].ToString();
                mm.Bra = reader["Bra"].ToString();
                mm.Size = Convert.ToInt32(reader["Size"].ToString());
                mm.thickness = reader["thickness"].ToString();
                mm.Worksdate = Convert.ToDateTime(reader["Worksdate"].ToString());
                mm.Worksstate = Convert.ToInt32(reader["Worksstate"].ToString());
                mm.Worksurl = reader["Worksurl"].ToString();
                mm.WorksCount = Convert.ToInt32(reader["WorksCount"].ToString());
                mm.Workcontent = reader["Workcontent"].ToString();
                mm.Userid = Convert.ToInt32(reader["Userid"].ToString());
                list.Add(mm);
            }
            con.Close();
            return list;
        }
        /// <summary>
        /// 最热作品显示
        /// </summary>
        /// <returns></returns>
        public List<WorksModel> WorkHot()
        {

            string str = @"SELECT top(5) [Worksid]
      ,[Worksname]
      ,[Bra]
      ,[Size]
      ,[thickness]
      ,[Worksdate]
      ,[Worksstate]
      ,[Worksurl]
      ,[WorksCount]
      ,[Workcontent]
      ,[Userid]
  FROM [Venus].[dbo].[Works] order by workscount desc";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            List<WorksModel> list = new List<WorksModel>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                WorksModel mm = new WorksModel();
                mm.Worksid = Convert.ToInt32(reader["Worksid"].ToString());
                mm.Worksname = reader["Worksname"].ToString();
                mm.Bra = reader["Bra"].ToString();
                mm.Size = Convert.ToInt32(reader["Size"].ToString());
                mm.thickness = reader["thickness"].ToString();
                mm.Worksdate = Convert.ToDateTime(reader["Worksdate"].ToString());
                mm.Worksstate = Convert.ToInt32(reader["Worksstate"].ToString());
                mm.Worksurl = reader["Worksurl"].ToString();
                mm.WorksCount = Convert.ToInt32(reader["WorksCount"].ToString());
                mm.Workcontent = reader["Workcontent"].ToString();
                mm.Userid = Convert.ToInt32(reader["Userid"].ToString());
                list.Add(mm);
            }
            con.Close();
            return list;
        }
        /// <summary>
        /// 作品表的添加
        /// </summary>
        /// <returns></returns>
        public int WorksADD(WorksModel mm)
        {
            string str = string.Format(@"INSERT INTO [dbo].[Works]
           ([Worksname]
           ,[Bra]
           ,[Size]
           ,[thickness]
           ,[Worksdate]
           ,[Worksstate]
           ,[Worksurl]
           ,[WorksCount]
           ,[Workcontent]
           ,[Userid])
     VALUES
           ('{0}','{1}',{2}'','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", mm.Worksname, mm.Bra, mm.Size, mm.thickness, mm.Worksdate, mm.Worksstate, mm.Worksurl, mm.WorksCount, mm.Workcontent, mm.Userid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 作品表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int WorksDelete(WorksModel mm)
        {
            string str = string.Format(@"DELETE FROM [dbo].[Works]
      WHERE  Worksid='{0}'", mm.Worksid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 作品表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int WorksUpdate(WorksModel mm)
        {
            string str = string.Format(@"UPDATE [dbo].[Works]
        SET [Worksname] = '{0}',
         [Bra] = '{1}',
         [Size] = '{2}',
         [thickness] = '{3}',
         [Worksdate] = '{4}',
         [Worksstate] = '{5}',
         [Worksurl] = '{6}',
         [WorksCount] = '{7}',
         [Workcontent] = '{8}',
         [Userid] = '{9}'
        WHERE
	        Worksid = '{10}'", mm.Worksname, mm.Bra, mm.Size, mm.thickness, mm.Worksdate, mm.Worksstate, mm.Worksurl, mm.WorksCount, mm.Workcontent, mm.Userid, mm.Worksid);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
        /// <summary>
        /// 根据作品id显示详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WorksModel idlist(int id)
        {
            string str = @"SELECT [Worksid]
            ,[Worksname]
            ,[Bra]
            ,[Size]
            ,[thickness]
            ,[Worksdate]
            ,[Worksstate]
            ,[Worksurl]
            ,[WorksCount]
            ,[Workcontent]
            ,b.Username,b.Usercheng
            FROM Works as a join userinfo as b on a.Userid=b.Userid where Worksid=" + id + "";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            SqlDataReader reader = command.ExecuteReader();
            WorksModel mm = new WorksModel();
            while (reader.Read())
            {
                mm.Worksid = Convert.ToInt32(reader["Worksid"].ToString());
                mm.Worksname = reader["Worksname"].ToString();
                mm.Bra = reader["Bra"].ToString();
                mm.Size = Convert.ToInt32(reader["Size"].ToString());
                mm.thickness = reader["thickness"].ToString();
                mm.Worksdate = Convert.ToDateTime(reader["Worksdate"].ToString());
                mm.Worksstate = Convert.ToInt32(reader["Worksstate"].ToString());
                mm.Worksurl = reader["Worksurl"].ToString();
                mm.WorksCount = Convert.ToInt32(reader["WorksCount"].ToString());
                mm.Workcontent = reader["Workcontent"].ToString();
                mm.Username = reader["Username"].ToString();
                mm.Usercheng = reader["Usercheng"].ToString();
            }
            con.Close();
            return mm;
        }


        /// <summary>
        ///作品表的显示
        /// </summary>
        /// <returns></returns>
        public List<WorksModel> Workshow(int i)
        {
            string str = @"SELECT  [Worksid]
      ,[Worksname]
      ,[Bra]
      ,[Size]
      ,[thickness]
      ,[Worksdate]
      ,[Worksstate]
      ,[Worksurl]
      ,[WorksCount]
      ,[Workcontent]
      ,[Userid]
  FROM [Venus].[dbo].[Works] order by ";
            if (i == 1)
            {
                str += " [Worksdate] ";
            }
            if (i == 2)
            {
                str += " [WorksCount] ";
            }
            if (i == 0)
            {
                str += "  [Worksid] ";
            }
            str += "desc";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            List<WorksModel> list = new List<WorksModel>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                WorksModel mm = new WorksModel();
                mm.Worksid = Convert.ToInt32(reader["Worksid"].ToString());
                mm.Worksname = reader["Worksname"].ToString();
                mm.Bra = reader["Bra"].ToString();
                mm.Size = Convert.ToInt32(reader["Size"].ToString());
                mm.thickness = reader["thickness"].ToString();
                mm.Worksdate = Convert.ToDateTime(reader["Worksdate"].ToString());
                mm.Worksstate = Convert.ToInt32(reader["Worksstate"].ToString());
                mm.Worksurl = reader["Worksurl"].ToString();
                mm.WorksCount = Convert.ToInt32(reader["WorksCount"].ToString());
                mm.Workcontent = reader["Workcontent"].ToString();
                mm.Userid = Convert.ToInt32(reader["Userid"].ToString());
                list.Add(mm);
            }
            con.Close();
            return list;
        }



    }
}
