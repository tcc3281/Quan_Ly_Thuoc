using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thuoc.Model
{
    internal class HoaDonNhap : HoaDon
    {
        String id_NCC;
        public HoaDonNhap(string id, string ngayXuLy, string id_NV, double tongTien, string id_NCC) : 
            base(id, ngayXuLy, id_NV, tongTien)
        {
            this.id_NCC = id_NCC;
        }

        public string Id_NCC { get => id_NCC; set => id_NCC = value; }
    }
}
