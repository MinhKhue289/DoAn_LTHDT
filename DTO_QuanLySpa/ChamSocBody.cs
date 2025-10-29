using DTO_QuanLySpa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Do_An
{
    public class ChamSocBody : DichVuDTO, IGiamGia
    {
        public ChamSocBody() : base()
        {

        }
        public ChamSocBody(string maDV, string loaiDV, double gia) : base(maDV, loaiDV, gia)
        {

        }
        public double TinhGiamGia()
        {
            return Gia * 0.07;
        }

        public override double TinhTongChiPhi()
        {
            return Gia - (TinhGiamGia());
        }
        public override void Xuat()
        {
            Console.OutputEncoding = Encoding.UTF8;
            base.Xuat();
            Console.Write($"Số tiền được giảm: {TinhGiamGia()}");
        }
    }
}