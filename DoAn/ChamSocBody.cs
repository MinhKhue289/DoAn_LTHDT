using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Do_An
{
    public class ChamSocBody:DichVu,IGiamGia
    {

        public ChamSocBody():base()
        {
            
        }
        public ChamSocBody(string maDV, string tenDV, double gia):base(maDV,tenDV,gia)
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
    }
}