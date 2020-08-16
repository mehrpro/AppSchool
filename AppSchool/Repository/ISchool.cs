using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AppSchool.Repository
{
    public interface ISchoolClass
    {
        /// <summary>
        /// ثبت نام آموزشگاه
        /// </summary>
        /// <param name="schoolName">نام آموزشگاه</param>
        /// <returns></returns>
        bool RegisterSchool(string schoolName);
    }

    public class SchoolClass : ISchoolClass
    {
        private IMyDataClass _myDataClass;
        public SchoolClass(IMyDataClass myDataClass)
        {
            _myDataClass = myDataClass;
        }
        public bool RegisterSchool(string schoolName)
        {
            int returnResult = 0;
            using (var connect = new MySqlConnection(_myDataClass.ConnectionString()))
            {
                connect.Open();

                var countStatment = "Select count(*) FROM tbl_school WHERE Enabled = true";
                using (var countCommand = new MySqlCommand(countStatment, connect))
                {
                    var result =  countCommand.ExecuteScalar();
                    if (Convert.ToInt32(result) > 0)
                    {
                        var updateStatment = "UPDATE tbl_School SET Enabled = FALSE ";
                        using (var cmd = new MySqlCommand(updateStatment, connect))
                        {
                            var resultUpdate = (int) cmd.ExecuteNonQuery();
                            if (resultUpdate > 0)
                            {
                                var qryStatment = "INSERT INTO tbl_School(SchoolName,Enabled) Values(@schoolName,@enabled)";
                                using (var command = new MySqlCommand(qryStatment, connect))
                                {
                                    command.Parameters.Add(new MySqlParameter("schoolName", schoolName));
                                    command.Parameters.Add(new MySqlParameter("enabled", true));
                                    returnResult = (int) command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    else
                    {
                        var qryStatment = "INSERT INTO tbl_School(SchoolName,Enabled) Values(@schoolName,@enabled)";
                        using (var command = new MySqlCommand(qryStatment, connect))
                        {
                            command.Parameters.Add(new MySqlParameter("schoolName", schoolName));
                            command.Parameters.Add(new MySqlParameter("enabled", true));
                            returnResult = (int) command.ExecuteNonQuery();

                        }
                    }
                }

            }

            return Convert.ToBoolean(returnResult);
        }
    }
}