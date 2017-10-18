using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entity;
using DAL;
namespace TTN_QuanLyKhachSan
{
    public partial class frmQuanLyKhachHang : Form
    {
       
        public void SetNull()
        {
            cbMaKH.Text = "";
            txtName.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtCMND.Text = "";
        }
       
    }
}
