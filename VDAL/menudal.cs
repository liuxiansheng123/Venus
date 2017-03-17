using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using VMODEL;
namespace VDAL
{
    public class menudal
    {
        string conString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        public List<menuview> parentlist()
        {
            string str = "select mname from menuview";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand(str,con);
            List<menuview> list = new List<menuview>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                menuview x = new menuview();
                x.mname = reader["mname"].ToString();
                list.Add(x);  
            }
            con.Close();
            return list;
        }
    }
}
