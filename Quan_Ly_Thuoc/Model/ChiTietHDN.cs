using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thuoc.Model
{
    internal class ChiTietHDN : ChiTietHD
    {
        double donGia, khuyenMai;

        public ChiTietHDN(string id_HD, string id_Thuoc, double sl, double thanhTien, double donGia, double khuyenMai) : 
            base(id_HD, id_Thuoc, sl, thanhTien)
        {
            this.donGia = donGia;
            this.khuyenMai = khuyenMai;
        }

        public double DonGia { get => donGia; set => donGia = value; }
        public double KhuyenMai { get => khuyenMai; set => khuyenMai = value; }
    }
}
