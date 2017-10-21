using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Entity;

namespace TTN_QuanLyKhachSan
{
    public partial class frmQuanLyDV : Form
    {
        public frmQuanLyDV()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtTen.Enabled = true;
            txtGia.Enabled = true;
            dgvDanhSach.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                EC_DV.MaDV = txtMa.Text;
                EC_DV.TenDV = txtTen.Text;
                EC_DV.Gia = txtGia.Text;
                _them = false;
                DAL_DV.ThemThongTin(EC_DV);
                dgvDanhSach.DataSource = DAL_DV.GetAll();
            }
            else
            {
                EC_DV.MaDV = txtMa.Text;
                EC_DV.TenDV = txtTen.Text;
                EC_DV.Gia = txtGia.Text;
                DAL_DV.SuaThongTin(EC_DV);
                dgvDanhSach.DataSource = DAL_DV.GetAll();
            }
            btnLuu.Enabled = false;
            txtGia.Enabled = false;
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            dgvDanhSach.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            EC_DV.MaDV = txtMa.Text;
            if (DAL_DV.XoaTTDichVu(EC_DV) == 1)
            {
                MessageBox.Show("Xóa thành công");
                dgvDanhSach.DataSource = DAL_DV.GetAll();
            }
            else
            {
                MessageBox.Show("Xóa thất bại. Có đối tượng đang sử dụng dịch vụ");
            }
        }

        private void txtTimMa_TextChanged(object sender, EventArgs e)
        {
            string dk = "";
            dk = "MaDV like N'%" + txtTimMa.Text + "%'";
            if (txtTimTen.Text != null)
            {
                dk += " and TenDV like N'%" + txtTimTen.Text + "%'";
            }
            dgvDanhSach.DataSource = DAL_DV.GetAll(dk);
        }

        private void txtTimTen_TextChanged(object sender, EventArgs e)
        {
            string dk = "";
            dk = "TenDV like N'%" + txtTimTen.Text + "%'";
            if (txtTimMa.Text != null)
            {
                dk += " and MaDV like N'%" + txtTimMa.Text + "%'";
            }
            dgvDanhSach.DataSource = DAL_DV.GetAll(dk);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTimTen.Clear();
            txtTimMa.Clear();
        }
    }
}
