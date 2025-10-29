using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Do_An
{
    public class KhachHang
    {
        private string maKH;
        private string tenKH;
        private string soDT;
        private List<DichVu> dsDV = new List<DichVu>();

        public string MaKH { get => maKH; 
            set
            {
                if (value.StartsWith("KH") && value.Substring(2).All(char.IsDigit))
                {
                    maKH = value;
                }
                else
                    throw new Exception("Mã khách hàng không hợp lệ");
            }
        }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public List<DichVu> DsDV { get => dsDV; set => dsDV = value; }

        public KhachHang()
        {
            
        }
        public KhachHang(string maKH, string tenKH, string soDT, List<DichVu> dichVus)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.soDT = soDT;
            this.DsDV = dichVus;
        }
        public void XuatTTKH()
        {
            Console.WriteLine($"  Mã KH: {MaKH} | Tên KH: {TenKH} | SĐT: {SoDT}");
            Console.WriteLine(new string('-',62));
            Console.WriteLine("|" + new string (' ',15) +"Danh sách dịch vụ thực hiện: " + new string(' ', 16) + "|");
            Console.WriteLine(new string('-', 62));
            Console.WriteLine($"| {"Mã DV:",-3} | {"Tên dịch vụ:",-25} | {"Giá:",-8} | {"Thành tiền:",-5}|");
            foreach (DichVu dv in DsDV)
            {
                dv.Xuat();
            }
            Console.WriteLine(new string('-', 62));
            Console.WriteLine();
        }
    }
}