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
    public partial class frmThanhToan : Form
    {
        DAL_Phong dalPh = new DAL_Phong();
        KetNoiData cn = new KetNoiData();
        EC_HoaDon ecHD = new EC_HoaDon();
        DAL_HoaDon dalHD = new DAL_HoaDon();
        private int _Gia;
        public frmThanhToan()
        {
            InitializeComponent();
        }

        public static int getCost(DateTime dateIn, DateTime dateOut, int cost)
        {
            TimeSpan Time = dateOut - dateIn;
            int sum = Time.Days;
            return sum * cost;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            //load combobox
            DataTable tb = cn.GetDataTable("Select distinct MaKH, tenKH from tblKhachHang");
            cmbKhachhang.DataSource = tb;
            cmbKhachhang.ValueMember = "MaKH";
            cmbKhachhang.DisplayMember = "tenKH";

        }

        

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dgvThongtin.Rows.Count; i++)
            {
                sum += int.Parse(dgvThongtin.Rows[i].Cells["Gia"].Value.ToString());
            }
            _Gia = int.Parse(cn.GetValue(@"select DonGiaHT from tblHoaDon where MaHD = '" + cmbMahd.Text + "'"));
            sum += getCost(dtpNgayVao.Value, dtpNgayra.Value, _Gia);
            MessageBox.Show("Tổng số tiền thanh toán: " + sum.ToString());
            //update hoa don
            ecHD.ThanhTien = sum.ToString();
            ecHD.MaHD = cmbMahd.Text;
            dalHD.ThanhToan(ecHD);
            //thay doi thong tin phong
            EC_Phong ph = new EC_Phong();
            ph.MaPh = cn.GetValue(@"select MaPh from tblPhieuThue where MaPhieu = '" + cmbMahd.Text + "'");
            ph.TrangThai = "Tốt";
            dalPh.TraPhong(ph);
            cmbKhachhang.ResetText();
            cmbMahd.ResetText();
            dgvThongtin.DataSource = null;
        }
    }
}
