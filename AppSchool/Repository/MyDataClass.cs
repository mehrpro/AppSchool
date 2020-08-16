using System;
using System.Configuration;
using System.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AppSchool.Repository
{
    public interface IMyDataClass
    {
        string ConnectionString();
       // bool VertifyUserNameAndPassword(string uname, string pass);
    }

    public class MyDataClass : IMyDataClass
    {
        public string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["mySQL"].ConnectionString;
        }

        //public bool VertifyUserNameAndPassword(string uname, string pass)
        //{
        //    using (var connection = new MySqlConnection(ConnectionString()))
        //    {
        //       connection.Open();
        //       MySqlCommand command = new MySqlCommand();
        //    }
        //}
    }
}