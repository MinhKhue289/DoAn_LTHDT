using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Do_An
{
    public abstract class LoaiDichVu
    {
        protected string maLoai;

        public string MaLoai { get => maLoai; set => maLoai = value; }

        public LoaiDichVu()
        {

        }

        public LoaiDichVu(string maLoai)
        {
            MaLoai = maLoai;
        }
        public abstract double TinhTongChiPhi();

        public abstract void Xuat();
    }
}