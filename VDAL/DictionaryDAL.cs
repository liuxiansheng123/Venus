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
    public class DictionaryDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        /// <summary>
        ///字典表的显示
        /// </summary>
        /// <returns></returns>
        public List<DictionaryModel> DictionaryList()
        {
            string str = @"SELECT [DicId]
      ,[DicName]
       FROM [dbo].[dictionary]";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str, con);
            List<DictionaryModel> list = new List<DictionaryModel>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DictionaryModel mm = new DictionaryModel();
                mm.DicId = Convert.ToInt32(reader["DicId"].ToString());
                mm.DicName = reader["DicName"].ToString();
                list.Add(mm);
            }
            con.Close();
            return list;
        }

        /// <summary>
        /// 字典表的添加
        /// </summary>
        /// <returns></returns>
        public int DictionaryADD(DictionaryModel mm)
        {
            string str = string.Format(@"INSERT INTO [dbo].[dictionary]
           ([DicName])
           VALUES
           ('{0}')", mm.DicName);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 字典表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int DictionaryDelete(DictionaryModel mm)
        {
            string str = string.Format(@"DELETE FROM [dbo].[dictionary]
            WHERE DicId='{0}'", mm.DicId);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        /// <summary>
        /// 字典表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int DictionaryUpdate(DictionaryModel mm)
        {
            string str = string.Format(@"UPDATE [dbo].[dictionary]
              SET [DicName] ='{0}'
          WHERE  DicId='{1}'", mm.DicName, mm.DicId);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}
