using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Venus.Interface;
using Venus.Model;
using System.Reflection;
namespace Venus.SqlDB
{
    public class SqlDB : SqlInterface
    {
        // private  readonly string connString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
        private readonly string connString = "";

        public bool Insert<T>(T model) where T : BaseModel
        {
            string sqlText = "insert into [{0}]({1}) values ({2})";
            Type type = typeof(T);

            sqlText = string.Format(sqlText, type.Name,
                string.Join(",", type.GetProperties().Where(p => p.Name != "Id").Select(x => string.Format("[{0}]", x.Name))),
                string.Join(",", type.GetProperties().Where(p => p.Name != "Id").Select(x => string.Format("@{0}", x.Name))));

            using (SqlConnection connection = new SqlConnection("server=118.89.241.53;uid=sa;pwd=zhongshao;database=Venus"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlText, connection);
                SqlParameter[] sqlParameter = type.GetProperties()
                    .Where(p => !"Id".Equals(p.Name))
                    .Select(p => new SqlParameter(string.Format("@{0}", p.Name), p.GetValue(model) ?? DBNull.Value))
                    .ToArray();
                command.Parameters.AddRange(sqlParameter);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IEnumerable<T> QueryList<T>() where T : BaseModel
        {
            string sqlText = "Select {0} from [{1}] order by id desc";
            Type type = typeof(T);

            var selectField = string.Join(",", type.GetProperties().Select(p => string.Format("[{0}]", p.Name)));
            sqlText = string.Format(sqlText, selectField, type.Name);

            List<T> modelList = new List<T>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlText, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var oObject = (T)Activator.CreateInstance(type);
                    foreach (var pop in type.GetProperties())
                    {
                        object oValue = reader[pop.Name];
                        if (oValue is DBNull)
                        {
                            pop.SetValue(oObject, null);
                        }
                        else
                        {
                            pop.SetValue(oObject, oValue);
                        }
                    }
                    modelList.Add(oObject);
                }
                return modelList;
            }
        }

        public T GetSinge<T>(string ID) where T : BaseModel
        {
            string sqlText = "select {0} from [{1}] where id=@id ";
            Type type = typeof(T);
            var selectField = string.Join(",", type.GetProperties().Select(p => string.Format("[{0}]", p.Name)));
            var selectFields = string.Join(",", type.GetProperties().Select(p => p.Name));
            sqlText = string.Format(sqlText, selectField, type.Name);
            var oObject = (T)Activator.CreateInstance(type);
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlText, connection);
                command.Parameters.Add(new SqlParameter("id", ID));
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foreach (var pop in type.GetProperties())
                    {
                        object oValue = reader[pop.Name];
                        if (oValue is DBNull)
                        {
                            pop.SetValue(oObject, null);
                        }
                        else
                        {
                            pop.SetValue(oObject, oValue);
                        }
                    }
                }
            }
            return oObject;
        }



        public virtual bool TestInsert<T>(T model)
        {
            string sqlText = "insert into [{0}]({1}) values ({2})";
            Type type = typeof(T);

            sqlText = string.Format(sqlText, type.Name,
                string.Join(",", type.GetProperties().Where(p => p.Name != "Id").Select(x => string.Format("[{0}]", x.Name))),
                string.Join(",", type.GetProperties().Where(p => p.Name != "Id").Select(x => string.Format("@{0}", x.Name))));

            using (SqlConnection connection = new SqlConnection("server=118.89.241.53;uid=sa;pwd=zhongshao;database=Venus"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlText, connection);
                SqlParameter[] sqlParameter = type.GetProperties()
                    .Where(p => !"Id".Equals(p.Name))
                    .Select(p => new SqlParameter(string.Format("@{0}", p.Name), p.GetValue(model) ?? DBNull.Value))
                    .ToArray();
                command.Parameters.AddRange(sqlParameter);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual T TestGetSinge<T>(string ID)
        {
            string sqlText = "select {0} from [{1}] where id=@id ";
            Type type = typeof(T);
            var selectField = string.Join(",", type.GetProperties().Select(p => string.Format("[{0}]", p.Name)));
            var selectFields = string.Join(",", type.GetProperties().Select(p => p.Name));
            sqlText = string.Format(sqlText, selectField, type.Name);
            var oObject = (T)Activator.CreateInstance(type);
            using (SqlConnection connection = new SqlConnection("server=118.89.241.53;uid=sa;pwd=zhongshao;database=Venus"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlText, connection);
                command.Parameters.Add(new SqlParameter("id", ID));
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foreach (var pop in type.GetProperties())
                    {
                        object oValue = reader[pop.Name];
                        if (oValue is DBNull)
                        {
                            pop.SetValue(oObject, null);
                        }
                        else
                        {
                            pop.SetValue(oObject, oValue);
                        }
                    }
                }
            }
            return oObject;
        }
    }
}
