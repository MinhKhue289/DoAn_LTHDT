using Do_An;
using DTO_QuanLySpa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL_QuanLySpa
{
    public class QuanLySpaDAL
    {
        private List<KhachHangDTO> dsKH = new List<KhachHangDTO>();
        private List<DichVuDTO> dsDV = new List<DichVuDTO>();

        public List<KhachHangDTO> DsKH { get => dsKH; set => dsKH = value; }
        public List<DichVuDTO> DsDV { get => dsDV; set => dsDV = value; }

        public QuanLySpaDAL()
        {

        }
        public void DocFile(string file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNodeList nodeList_DSDV = doc.SelectNodes("/QuanLySpa/DSDV/DichVu");
            foreach (XmlNode node_dv in nodeList_DSDV)
            {
                DichVuDTO dv;
                string maDV = node_dv["MaDV"].InnerText;
                string tenDV = node_dv["LoaiDV"].InnerText;
                double gia = double.Parse(node_dv["Gia"].InnerText);
                if (node_dv.Attributes["Loai"].Value == "1")
                {
                    dv = new ChamSocSacDep(maDV, tenDV, gia);
                }
                else if (node_dv.Attributes["Loai"].Value == "2")
                {
                    dv = new ChamSocBody(maDV, tenDV, gia);
                }
                else
                {
                    dv = new DuongSinhTriLieu(maDV, tenDV, gia);
                }
                DsDV.Add(dv);
            }
            XmlNodeList nodeList_KH = doc.SelectNodes("/QuanLySpa/DSKH/KhachHang");
            foreach (XmlNode node_kh in nodeList_KH)
            {
                string maKH = node_kh["MaKH"].InnerText;
                string tenKH = node_kh["TenKH"].InnerText;
                string sdt = node_kh["SDT"].InnerText;
                List<DichVuDTO> dsDV_KH = new List<DichVuDTO>();
                XmlNodeList nodeList_DV = node_kh.SelectNodes("DichVus/DichVu");
                foreach (XmlNode node_dv in nodeList_DV)
                {
                    DichVuDTO dv;
                    string maDV = node_dv["MaDV"].InnerText;
                    string tenDV = node_dv["LoaiDV"].InnerText;
                    double gia = double.Parse(node_dv["Gia"].InnerText);
                    if (node_dv.Attributes["Loai"].Value == "1")
                    {
                        dv = new ChamSocSacDep(maDV, tenDV, gia);
                    }
                    else if (node_dv.Attributes["Loai"].Value == "2")
                    {
                        dv = new ChamSocBody(maDV, tenDV, gia);
                    }
                    else
                    {
                        dv = new DuongSinhTriLieu(maDV, tenDV, gia);
                    }
                    dsDV_KH.Add(dv);
                }
                KhachHangDTO kh = new KhachHangDTO(maKH, tenKH, sdt, dsDV_KH);
                this.DsKH.Add(kh);
            }
        }
    }
}
