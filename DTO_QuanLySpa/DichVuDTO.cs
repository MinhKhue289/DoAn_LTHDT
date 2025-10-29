//Console .OutputEncoding = Encoding.UTF8
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Do_An
{
    public abstract class DichVuDTO
    {
        protected string maDV;
        protected string tenDV;
        protected double gia;

        public string MaDV
        {
            get => maDV;
            set
            {
                if (value.StartsWith("DV") && value.Substring(2, 2).All(char.IsDigit))
                {
                    maDV = value;
                }
                else
                {
                    Console.WriteLine("Mã dịch vụ không hợp lệ!");
                    maDV = "DV000";
                }

            }
        }
        public string TenDV { get => tenDV; set => tenDV = value; }
        public double Gia
        {
            get { return gia; }
            set
            {
                if (value > 0)
                    gia = value;
                else
                {
                    Console.WriteLine("Giá không hợp lệ!");
                    gia = 0;
                }
            }
        }
        public DichVuDTO()
        {

        }
        public DichVuDTO(string maDV, string tenDV, double gia)
        {
            this.MaDV = maDV;
            this.TenDV = tenDV;
            this.Gia = gia;
        }
        public DichVuDTO(DichVuDTO dv)
        {
            this.MaDV = dv.maDV;
            this.TenDV = dv.tenDV;
            this.Gia = dv.gia;
        }

        public abstract double TinhTongChiPhi();

        public virtual void Xuat()
        {
            Console.WriteLine($"| {MaDV,-6} | {TenDV,-25} | {Gia.ToString("0.00"),-8} | {TinhTongChiPhi().ToString("0.00"),-11}|");
        }
    }
}