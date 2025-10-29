using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Do_An
{
    public class DuongSinhTriLieu:DichVu,IGiamGia
    {
        public DuongSinhTriLieu():base()
        {
            
        }
        public DuongSinhTriLieu(string maDV, string tenDV, double gia): base(maDV,tenDV,gia)
        {
            
        }
        public double TinhGiamGia()
        {
            return Gia * 0.1;
        }

        public override double TinhTongChiPhi()
        {
            return Gia - (TinhGiamGia());
        }
    }
}