using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL
{
    internal class KhachHang
    {
        string id, ten, diachi, sdt;

        public KhachHang(string id, string ten, string diachi, string sdt)
        {
            this.id = id;
            this.ten = ten;
            this.diachi = diachi;
            this.sdt = sdt;
        }

        public string Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
