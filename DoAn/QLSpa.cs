using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Do_An
{
    public class QLSpa
    {
        private QuanLySpaDAL qlDAL = new QuanLySpaDAL();
        private List<KhachHangDTO> dsKH = new List<KhachHangDTO>();
        private List<DichVuDTO> dsDV = new List<DichVuDTO>();


        public void ThemDichVuMoi()
        {
            DichVu dv_new;
            Console.WriteLine(new string(' ',15) + new string('-',31));
            Console.WriteLine(new string (' ',15) + "| 1. Dịch vụ chăm sóc sắc đẹp |\n" + new string(' ', 15) + "| 2. Dịch vụ chăm sóc body    |\n" + new string(' ', 15) + "| 3. Dưỡng sinh trị liệu      |");
            Console.WriteLine(new string(' ', 15) + new string('-', 31));
            Console.Write(new string (' ',15) + "Chọn loại dịch vụ muốn thêm: ");
            int choice = int.Parse(Console.ReadLine());
            Console.Write($"{"Nhập mã dịch vụ: ",32}");
            string maDV = Console.ReadLine();
            Console.Write($"{"Nhập tên dịch vụ: ",33}");
            string tenDV = Console.ReadLine();
            Console.Write($"{"Nhập giá dịch vụ: ",33}");
            double gia = double.Parse(Console.ReadLine());
            Console.WriteLine();
            if (choice == 1)
            {
                dv_new = new ChamSocSacDep(maDV, tenDV, gia);
            }
            else if (choice == 2)
            {
                dv_new = new ChamSocBody(maDV, tenDV, gia);
            }
            else
            {
                dv_new = new DuongSinhTriLieu(maDV, tenDV, gia);
            }
            DsDV.Add(dv_new);
            XuatDSCacDV();
        }

        public void XuatDSCacDV()
        {
            Console.WriteLine("Danh sách dịch vụ của spa là: \n");
            Console.WriteLine(new string('-', 62));
            Console.WriteLine($"| {"Mã DV:",-3} | {"Tên dịch vụ:",-25} | {"Giá:",-8} | {"Thành tiền:",-5}|");
            Console.WriteLine(new string('-', 62));
            foreach (DichVu dv in this.DsDV)
            {
                dv.Xuat();
            }
            Console.WriteLine(new string('-', 62));
            Console.WriteLine();
        }

        public void XuatDSKH()
        {
            Console.WriteLine("Danh sách khách hàng của spa: \n");
            foreach (KhachHang kh in DsKH)
            {
                kh.XuatTTKH();
            }
            Console.WriteLine();
        }

        public DichVu TimDVBangTen(string tenDV)
        {
            return DsDV.FirstOrDefault(x => x.TenDV == tenDV);
        }
        public void XuatMotDV(DichVu dv)
        {
            if (dv != null)
            {
                Console.WriteLine(new string('-', 62));
                Console.WriteLine($"| {"Mã DV:",-3} | {"Tên dịch vụ:",-25} | {"Giá:",-8} | {"Thành tiền:",-5}|");
                Console.WriteLine(new string('-', 62));
                dv.Xuat();
                Console.WriteLine(new string('-', 62));
            }
            else
            {
                Console.WriteLine("Dịch vụ không tồn tại!");
            } 
        }    
        public void XuatDSDV(List<DichVu> ds)
        {
            if(ds.Any())
            { 
                Console.WriteLine(new string('-', 62));
                Console.WriteLine($"| {"Mã DV:",-3} | {"Tên dịch vụ:",-25} | {"Giá:",-8} | {"Thành tiền:",-5}|");
                Console.WriteLine(new string('-', 62));
                foreach (DichVu dv in ds)
                    dv.Xuat();
                Console.WriteLine(new string('-', 62));
            }
            else
            {
                Console.WriteLine("Không tồn tại dịch vụ nào trong danh sách!");
            }
        }
        public void XuatDSKH(List<KhachHang> ds)
        {
            if (ds.Any())
            {
                foreach (KhachHang kh in ds)
                    kh.XuatTTKH();
            }
            else
            {
                Console.WriteLine("Không tồn tại khách hàng nào trong danh sách!");
            }
        }
        public List<DichVu> TimDSDV_ChamSocSacDep()
        {
            return DsDV.Where(t => t is ChamSocSacDep).ToList();
        }
        public List<KhachHang> XuatDSKH_LonHon3DV()
        {
            return DsKH.Where(t => t.DsDV.Count() > 3).ToList();
        }
        public List<DichVu> XuatDSDV_DuongSinh()
        {
             return DsDV.Where(t => t is DuongSinhTriLieu).ToList();
            
        }
        public List<DichVu> TimDSDVKHX(string tenKH)
        {
            KhachHang kh = DsKH.FirstOrDefault<KhachHang>(x => x.TenKH == tenKH);  
            if (kh != null)
            {
                return kh.DsDV;
            }
            else
            {
                return new List<DichVu>();
            }    
        }

        public void UpdateKinhPhiDVCSSD()
        {
            foreach(DichVu dv in DsDV)
            {
                if (dv.GetType().Name == "ChamSocSacDep")
                {
                    dv.Gia += (dv.Gia * 0.03);
                }                    
            }
            Console.WriteLine("Danh sách dịch vụ sau khi update kinh phí là: ");
            XuatDSCacDV();
        }
        public List<DichVu> TimDSDVGiaTren500()
        {
            return DsDV.Where(x => x.Gia > 500).ToList();
        }
    }
}