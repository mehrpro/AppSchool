using System;
using System.Windows.Forms;
using AppSchool.Repository;
using DevExpress.XtraEditors;

namespace AppSchool.UserForm.School
{
    public partial class FrmSchool : DevExpress.XtraEditors.XtraForm
    {
        private ISchoolClass SchoolClass;
        public FrmSchool()
        {
            InitializeComponent();
            SchoolClass = new SchoolClass(new MyDataClass());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            var register = SchoolClass.RegisterSchool(txtSchoolName.Text.Trim());
            if (register)
            {
                XtraMessageBox.Show("مشخصات مدرسه با موفقیت ثبت شد", Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("ثبت نشد", Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            
        }
    }
}
