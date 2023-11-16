using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thuoc.Model
{
    //test win
    internal class ChiTietHD
    {
        string id_HD, id_Thuoc;
        double sl;//so luong
        double thanhTien;

        public ChiTietHD(string id_HD, string id_Thuoc, double sl, double thanhTien)
        {
            this.id_HD = id_HD;
            this.id_Thuoc = id_Thuoc;
            this.sl = sl;
            this.thanhTien = thanhTien;
        }

        public string Id_HD { get => id_HD; set => id_HD = value; }
        public string Id_Thuoc { get => id_Thuoc; set => id_Thuoc = value; }
        public double Sl { get => sl; set => sl = value; }
        public double ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
