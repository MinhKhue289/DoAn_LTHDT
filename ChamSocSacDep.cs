using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Do_An
{
    public class ChamSocSacDep : DichVuDTO
    {
        public ChamSocSacDep(string maDV, string tenDV, double gia)
            : base(maDV, tenDV, gia)
        {
        }

        public override double TinhTongChiPhi()
        {
            return this.gia;
        }
    }
}