using Do_An;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLySpa
{
    public class DuongSinhTriLieu : DichVuDTO, IGiamGia
    {
        public DuongSinhTriLieu() : base()
        {

        }
        public DuongSinhTriLieu(string maDV, string loaiDV, double gia) : base(maDV, loaiDV, gia)
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
        public override void Xuat()
        {
            Console.OutputEncoding = Encoding.UTF8;
            base.Xuat();
            Console.WriteLine($"Số tiền được giảm: {TinhGiamGia()}");
        }
    }
}
