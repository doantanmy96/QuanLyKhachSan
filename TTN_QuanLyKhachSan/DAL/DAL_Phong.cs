using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL
{
    public class DAL_Phong
    {
        private KetNoiData connect = new KetNoiData();
        public DataTable ThongTinPhong(string dk)
        {
            DataTable tb = connect.GetDataTable("select * from tblPhong " + dk);
            return tb;
        }

        public int ThemThongTin(EC_Phong EC_Ph)
        {
            return connect.ThucHienLenh("insert into tblPhong(MaPh,SoPhong,TrangThai) values(N'" + EC_Ph.MaPh + "', N'" + EC_Ph.SoPhong + "', N'" + EC_Ph.TrangThai + "') ");
        }


    }
}
