using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL
{
    internal class NhanVien
    {
        private string id, ten, dob, diaChi, id_TrinhDo, id_ChuyenMon;
        private bool phai;//gioi tinh
        private string sdt;//so dien thoai

        public NhanVien(string id, string ten, string dob, string diaChi, string id_TrinhDo, string id_ChuyenMon, bool phai, string sdt)
        {
            this.id = id;
            this.ten = ten;
            this.dob = dob;
            this.diaChi = diaChi;
            this.id_TrinhDo = id_TrinhDo;
            this.id_ChuyenMon = id_ChuyenMon;
            this.phai = phai;
            this.sdt = sdt;
        }

        public string Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Dob { get => dob; set => dob = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Id_TrinhDo { get => id_TrinhDo; set => id_TrinhDo = value; }
        public string Id_ChuyenMon { get => id_ChuyenMon; set => id_ChuyenMon = value; }
        public bool Phai { get => phai; set => phai = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
