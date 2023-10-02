using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    internal class Thuoc
    {
        private string id, ten, id_DonVi, id_DieuChe, thanhPhan, chongChiDinh;
        private double giaNhap, giaBan;
        private int sl;
        private string nSX, hSD, id_NuocSX;

        public Thuoc(string id, string ten, string id_DonVi, string id_DieuChe, string thanhPhan, string chongChiDinh, double giaNhap, double giaBan, int sl, string nSX, string hSD, string id_NuocSX)
        {
            this.id = id;
            this.ten = ten;
            this.id_DonVi = id_DonVi;
            this.id_DieuChe = id_DieuChe;
            this.thanhPhan = thanhPhan;
            this.chongChiDinh = chongChiDinh;
            this.giaNhap = giaNhap;
            this.giaBan = giaBan;
            this.sl = sl;
            this.nSX = nSX;
            this.hSD = hSD;
            this.id_NuocSX = id_NuocSX;
        }

        public string Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Id_DonVi { get => id_DonVi; set => id_DonVi = value; }
        public string Id_DieuChe { get => id_DieuChe; set => id_DieuChe = value; }
        public string ThanhPhan { get => thanhPhan; set => thanhPhan = value; }
        public string ChongChiDinh { get => chongChiDinh; set => chongChiDinh = value; }
        public double GiaNhap { get => giaNhap; set => giaNhap = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public int Sl { get => sl; set => sl = value; }
        public string NSX { get => nSX; set => nSX = value; }
        public string HSD { get => hSD; set => hSD = value; }
        public string Id_NuocSX { get => id_NuocSX; set => id_NuocSX = value; }
    }
}
