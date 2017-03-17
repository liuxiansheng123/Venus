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
    public class UserHomeDAl
    {
        string conString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        /// <summary>
        /// 用户界面显示
        /// </summary>
        public UserHomeMODEL<UserinfoModel> UserHomeList(int id)
        {
            /// <summary>
            ///用户信息的显示
            /// </summary>
            /// <returns></returns>
            string str = string.Format(@"SELECT [Userid]
      ,[Username]
      ,[Usercheng]
  FROM [dbo].[UserInfo] WHERE [Userid]='{0}'", id);
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


                mm.Usercheng = reader["Usercheng"].ToString();

                list.Add(mm);
            }
            con.Close();

            //用户作品数量

            SqlConnection workscountcon = new SqlConnection(conString);
            string workscountsql = string.Format(@"SELECT COUNT([Worksid]) FROM [Venus].[dbo].[Works] WHERE [Userid]='{0}'", id);
            SqlCommand workscountcommand = new SqlCommand(workscountsql, workscountcon);
            workscountcon.Open();
            int workscount = Convert.ToInt32(workscountcommand.ExecuteScalar());

            workscountcon.Close();



            ///用户未审核作品数量
            SqlConnection notworkscountcon = new SqlConnection(conString);
            string notworkscountsql = string.Format(@"SELECT COUNT([Worksid]) FROM [Venus].[dbo].[Works] WHERE [Userid]='{0}' and [Worksstate]=3", id);
            SqlCommand notworkscountcommand = new SqlCommand(notworkscountsql, notworkscountcon);
            notworkscountcon.Open();
            int notworkscount = Convert.ToInt32(notworkscountcommand.ExecuteScalar());
            notworkscountcon.Close();

            ///用户已审核作品数量
            SqlConnection auditworkscountcon = new SqlConnection(conString);
            string auditworkscountsql = string.Format(@"SELECT COUNT([Worksid]) FROM [Venus].[dbo].[Works] WHERE [Userid]='{0}' and [Worksstate]=4", id);
            SqlCommand auditworkscountcommand = new SqlCommand(auditworkscountsql, auditworkscountcon);
            auditworkscountcon.Open();
            int auditworkscount = Convert.ToInt32(auditworkscountcommand.ExecuteScalar());
            auditworkscountcon.Close();

            ///用户收藏数量
            SqlConnection collectcountcon = new SqlConnection(conString);
            string collectcountsql = string.Format(@"SELECT COUNT([collectid]) FROM [Venus].[dbo].[Collect] WHERE [Userid]='{0}'", id);
            SqlCommand collectcountcommand = new SqlCommand(collectcountsql, collectcountcon);
            collectcountcon.Open();
            int collectcount = Convert.ToInt32(collectcountcommand.ExecuteScalar());
            collectcountcon.Close();
            ///用户评论数量
            SqlConnection reviewcountcon = new SqlConnection(conString);
            string reviewcountsql = string.Format(@"SELECT COUNT([Reviewid]) FROM [Venus].[dbo].[Review] WHERE [Userid]='{0}'", id);
            SqlCommand reviewcountcommand = new SqlCommand(reviewcountsql, reviewcountcon);
            reviewcountcon.Open();
            int reviewcount = Convert.ToInt32(reviewcountcommand.ExecuteScalar());
            reviewcountcon.Close();



            UserHomeMODEL<UserinfoModel> Userhome = new UserHomeMODEL<UserinfoModel>();
            Userhome.datalist = list;
            Userhome.Workscount = workscount;
            Userhome.NotWorkscount = notworkscount;
            Userhome.auditWorkscount = auditworkscount;
            Userhome.Collectcount = collectcount;
            Userhome.Reviewcount = reviewcount;



            return Userhome;
        }
        /// <summary>
        /// 根据用户ID查询评论过的作品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<WorksModel> Review(int id)
        {
            string str = string.Format(@"
SELECT 
      [Worksid]
  FROM [dbo].[Review] WHERE [Userid]='{0}'", id);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            SqlDataReader reader = command.ExecuteReader();
            string stid = "";
            while (reader.Read())
            {
                stid += reader["Worksid"] + ",";
            }
            con.Close();
            stid = stid.Trim(',');
            List<WorksModel> list = new List<WorksModel>();
            list = UserWorkShow(stid);
            return list;
        }
        /// <summary>
        /// 根据用户id查询收藏表中作品
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        public List<WorksModel> Collect(int id)
        {
            string str = string.Format(@"SELECT
	Worksid
    FROM
	Collect WHERE Userid='{0}'", id);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            SqlDataReader reader = command.ExecuteReader();
            string stid = "";
            while (reader.Read())
            {
                stid += reader["Worksid"] + ",";
            }
            con.Close();
            stid = stid.Trim(',');
            List<WorksModel> list = new List<WorksModel>();
            list = UserWorkShow(stid);
            return list;
        }
        /// <summary>
        /// 用户收藏的作品
        /// </summary>
        /// <returns></returns>
        public List<WorksModel> UserWorkShow(string id)
        {
            List<WorksModel> list = new List<WorksModel>();
            string str = "select * from works a join dbo.UserInfo b on a.userid=b.userid where worksid in(" + id + ")";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                WorksModel a = new WorksModel();
                a.Worksid = Convert.ToInt32(reader["Worksid"].ToString());
                a.Worksname = reader["Worksname"].ToString();
                a.Bra = reader["Bra"].ToString();
                a.Size = Convert.ToInt32(reader["Size"].ToString());
                a.thickness = reader["thickness"].ToString();
                a.Worksdate = Convert.ToDateTime(reader["Worksdate"].ToString());
                a.Worksstate = Convert.ToInt32(reader["Worksstate"].ToString());
                a.Worksurl = reader["Worksurl"].ToString();
                a.WorksCount = Convert.ToInt32(reader["WorksCount"].ToString());
                a.Workcontent = reader["Workcontent"].ToString();
                a.Username = reader["Username"].ToString();
                list.Add(a);
            }
            con.Close();
            return list;
        }
    }
}
