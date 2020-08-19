using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSchool.Repository;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using SchoolDataAccess;
using DevExpress.XtraEditors;
using MySql.Data;
using MySql.Data.MySqlClient;
using SchoolDataAccess;
using SchoolEntity;

namespace AppSchool
{
    public partial class frmLogin : XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var conn = new MyDataClass();
            var connString = conn.ConnectionString();
            var studens = new GenericRepository<Student>(connString);
            studens.Add(new Student()
            {
                Name = "farshid",
                BrithDate = DateTime.Now,
                NatinalCode = 4545,
                Family = "محمدی",
                Code = 7455,
                
                
            });



        }
    }
}
