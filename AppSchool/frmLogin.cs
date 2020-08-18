using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using DevExpress.XtraEditors;
using MySql.Data;
using MySql.Data.MySqlClient;
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
            var student = new GenericRepository<Student>();
            student.Add(new Student()
            {
                
            });

            
        }
    }
}
