using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Do_An
{
    public class ChamSocSacDep:DichVu
    {
        public ChamSocSacDep():base()
        {

        }
        public ChamSocSacDep(string maDV, string tenDV, double gia) : base(maDV, tenDV, gia)
        {

        }
        public override double TinhTongChiPhi()
        {
            return Gia;
        }
    }
}