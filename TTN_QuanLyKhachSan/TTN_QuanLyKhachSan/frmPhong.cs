using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTN_QuanLyKhachSan;
using DAL;
using Entity;


namespace TTN_QuanLyKhachSan
{
    public partial class frmPhong : Form
    {
        
        private void SetNull()
        {
            txtMaPhong.Text = "";
            txtSoPhong.Text = "";
            txtTrangThai.Text = "";
        }

    }
}
