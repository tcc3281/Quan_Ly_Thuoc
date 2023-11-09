using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thuoc.Model
{
    internal class ChiTietHDB : ChiTietHD
    {
        double giamGia;
        public ChiTietHDB(string id_HD, string id_Thuoc, double sl, double thanhTien, double giamGia) : 
            base(id_HD, id_Thuoc, sl, thanhTien)
        {
            this.giamGia = giamGia;
        }

        public double GiamGia { get => giamGia; set => giamGia = value; }
    }
}
