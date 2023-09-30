using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thuoc.Model
{
    internal class HoaDon
    {
        String id, ngayXuLy, id_NV;
        double tongTien;

        public HoaDon(string id, string ngayXuLy, string id_NV, double tongTien)
        {
            this.id = id;
            this.ngayXuLy = ngayXuLy;
            this.id_NV = id_NV;
            this.tongTien = tongTien;
        }

        public string Id { get => id; set => id = value; }
        public string NgayXuLy { get => ngayXuLy; set => ngayXuLy = value; }
        public string Id_NV { get => id_NV; set => id_NV = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
    }
}
