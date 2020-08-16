using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSchool.UserForm.School;

namespace AppSchool.UserForm
{
    public partial class FrmMainPanel : DevExpress.XtraEditors.XtraForm
    {
        public FrmMainPanel()
        {
            InitializeComponent();
        }

        private void btnSchool_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmSchool();
            frm.ShowDialog();
        }
    }
}
