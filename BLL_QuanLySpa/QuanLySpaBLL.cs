using DAL_QuanLySpa;
using Do_An;
using DTO_QuanLySpa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace BLL_QuanLySpa
{
    public class QuanLySpaBLL
    {
        private QuanLySpaDAL qlDAL = new QuanLySpaDAL();
        private List<KhachHangDTO> dsKH = new List<KhachHangDTO>();
        private List<DichVuDTO> dsDV = new List<DichVuDTO>();

        public List<KhachHangDTO> DsKH { get => dsKH; set => dsKH = value; }
        public List<DichVuDTO> DsDV { get => dsDV; set => dsDV = value; }
        public QuanLySpaDAL QlDAL { get => qlDAL; set => qlDAL = value; }
        public QuanLySpaBLL()
        {
            qlDAL = new QuanLySpaDAL();
            dsDV = new List<DichVuDTO>();
            dsKH = new List<KhachHangDTO>();
        }

        public void getAll()
        {
            string file = "../../../QuanLySpa.xml";
            qlDAL.DocFile(file);
            this.dsDV = qlDAL.DsDV;
            this.dsKH = qlDAL.DsKH;
        }
        public void GhiFile(DichVuDTO dv)
        {
            DsDV.Add(dv);
            string pathfile = @"..\..\..\QuanLySpa.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(pathfile);
            XmlNode root = xml.SelectSingleNode("/QuanLySpa/DSDV");
            XmlNode nodeDV = xml.CreateNode(XmlNodeType.Element, "DichVu", null);

            XmlAttribute attrLoai = xml.CreateAttribute("Loai");
            string loai = "3";
            if (dv is ChamSocSacDep) loai = "1";
            else if (dv is ChamSocBody) loai = "2";
            attrLoai.Value = loai;
            nodeDV.Attributes.Append(attrLoai);

            XmlElement eMa = xml.CreateElement("MaDV");
            eMa.InnerText = dv.MaDV;
            XmlElement eLoaiDV = xml.CreateElement("LoaiDV");
            eLoaiDV.InnerText = dv.TenDV;
            XmlElement eGia = xml.CreateElement("Gia");
            eGia.InnerText = dv.Gia.ToString();

            nodeDV.AppendChild(eMa);
            nodeDV.AppendChild(eLoaiDV);
            nodeDV.AppendChild(eGia);

            root.AppendChild(nodeDV);

            xml.Save(pathfile);
            Console.WriteLine($"Ghi dịch vụ mới vào file thành công");
        }
        public void ThemDichVuMoi()
        {
            DichVuDTO dv_new;
            Console.WriteLine(new string(' ', 15) + new string('-', 31));
            Console.WriteLine(new string(' ', 15) + "| 1. Dịch vụ chăm sóc sắc đẹp |\n" + new string(' ', 15) + "| 2. Dịch vụ chăm sóc body    |\n" + new string(' ', 15) + "| 3. Dưỡng sinh trị liệu      |");
            Console.WriteLine(new string(' ', 15) + new string('-', 31));
            Console.Write(new string(' ', 15) + "Chọn loại dịch vụ muốn thêm: ");
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
            GhiFile(dv_new);
            XuatDSCacDV();
        }

        public void XuatDSCacDV()
        {
            Console.WriteLine("Danh sách dịch vụ của spa là: \n");
            Console.WriteLine(new string('-', 62));
            Console.WriteLine($"| {"Mã DV:",-3} | {"Tên dịch vụ:",-25} | {"Giá:",-8} | {"Thành tiền:",-5}|");
            Console.WriteLine(new string('-', 62));
            foreach (DichVuDTO dv in this.DsDV)
            {
                dv.Xuat();
            }
            Console.WriteLine(new string('-', 62));
            Console.WriteLine();
        }

        public void XuatDSKH()
        {
            Console.WriteLine("Danh sách khách hàng của spa: \n");
            foreach (KhachHangDTO kh in DsKH)
            {
                kh.XuatTTKH();
            }
            Console.WriteLine();
        }

            public DichVuDTO TimDVBangTen(string tenDV)
            {
                return DsDV.FirstOrDefault(x => x.TenDV == tenDV);
            }
        public void XuatMotDV(DichVuDTO dv)
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
        public void XuatDSDV(List<DichVuDTO> ds)
        {
            if (ds.Any())
            {
                Console.WriteLine(new string('-', 62));
                Console.WriteLine($"| {"Mã DV:",-3} | {"Tên dịch vụ:",-25} | {"Giá:",-8} | {"Thành tiền:",-5}|");
                Console.WriteLine(new string('-', 62));
                foreach (DichVuDTO dv in ds)
                    dv.Xuat();
                Console.WriteLine(new string('-', 62));
            }
            else
            {
                Console.WriteLine("Không tồn tại dịch vụ nào trong danh sách!");
            }
        }
        public void XuatDSKH(List<KhachHangDTO> ds)
        {
            if (ds.Any())
            {
                foreach (KhachHangDTO kh in ds)
                    kh.XuatTTKH();
            }
            else
            {
                Console.WriteLine("Không tồn tại khách hàng nào trong danh sách!");
            }
        }
        public List<DichVuDTO> TimDSDV_ChamSocSacDep()
        {
            return DsDV.Where(t => t is ChamSocSacDep).ToList();
        }
        public List<KhachHangDTO> XuatDSKH_LonHon3DV()
        {
            return DsKH.Where(t => t.DsDV.Count() > 3).ToList();
        }
        public List<DichVuDTO> XuatDSDV_DuongSinh()
        {
            return DsDV.Where(t => t is DuongSinhTriLieu).ToList();

        }
        public List<DichVuDTO> TimDSDVKHX(string tenKH)
        {
            KhachHangDTO kh = DsKH.FirstOrDefault<KhachHangDTO>(x => x.TenKH == tenKH);
            if (kh != null)
            {
                return kh.DsDV;
            }
            else
            {
                return new List<DichVuDTO>();
            }
        }

        public void UpdateKinhPhiDVCSSD()
        {
            foreach (DichVuDTO dv in DsDV)
            {
                if (dv.GetType().Name == "ChamSocSacDep")
                {
                    dv.Gia += (dv.Gia * 0.03);
                }
            }
            Console.WriteLine("Danh sách dịch vụ sau khi update kinh phí là: ");
            XuatDSCacDV();
        }
        public List<DichVuDTO> TimDSDVGiaTren500()
        {
            return DsDV.Where(x => x.Gia > 500).ToList();
        }
    }
}

