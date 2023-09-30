using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thuoc.Model
{
    internal class HoaDonBan : HoaDon
    {
        String id_KH;

        public HoaDonBan(string id, string ngayXuLy, string id_NV, double tongTien, string id_KH) : 
            base(id, ngayXuLy, id_NV, tongTien)
        {
            this.id_KH = id_KH;
        }

        public string Id_KH { get => id_KH; set => id_KH = value; }
    }
}
