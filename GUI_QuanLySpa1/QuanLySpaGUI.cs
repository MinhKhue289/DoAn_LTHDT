using BLL_QuanLySpa;
using Do_An; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUI_QuanLySpa 
{
    internal class QuanLySpaGUI
    {
        static QuanLySpaBLL spa = new QuanLySpaBLL();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            int choice;

            do
            {
                Console.WriteLine(new string('-', 30) + "MENU" + new string('-', 31));
                Console.WriteLine("| 0. Thoát chương trình" + new string(' ', 41) + "|");
                Console.WriteLine("| 1. Đọc/Tải lại dữ liệu từ file XML." + new string(' ', 27) + "|");
                Console.WriteLine("| 2. Thêm mới một dịch vụ từ bàn phím." + new string(' ', 26) + "|");
                Console.WriteLine("| 3. Xuất danh sách các dịch vụ." + new string(' ', 32) + "|");
                Console.WriteLine("| 4. Tìm kiếm dịch vụ khi biết tên dịch vụ." + new string(' ', 21) + "|");
                Console.WriteLine("| 5. Xuất danh sách các dịch vụ khi biết tên khách hàng." + new string(' ', 8) + "|");
                Console.WriteLine("| 6. Cập nhật kinh phí các dịch vụ chăm sóc sắc đẹp tăng lên 3%.|");
                Console.WriteLine("| 7. Xuất danh sách các dịch vụ có giá thành trên 500." + new string(' ', 10) + "|");
                Console.WriteLine("| 8. Xuất danh sách các dịch vụ thuộc dịch vụ chăm sóc sắc đẹp. |");
                Console.WriteLine("| 9. Xuất danh sách khách hàng thực hiện nhiều hơn 3 dịch vụ." + new string(' ', 3) + "|");
                Console.WriteLine("| 10. Xuất danh sách các dịch vụ dưỡng sinh trị liệu." + new string(' ', 11) + "|");
                Console.WriteLine(new string('-', 65));
                Console.Write(new string(' ', 20) + "Mời nhập yêu cầu: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1;
                }

                Console.WriteLine();
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Đã thoát chương trình");
                        break;
                    case 1:
                        spa.getAll();
                        Console.WriteLine("--- Đã tải dữ liệu thành công! ---");
                        spa.XuatDSCacDV();
                        spa.XuatDSKH();
                        break;
                    case 2:
                        spa.ThemDichVuMoi();
                        break;
                    case 3:
                        spa.XuatDSCacDV();
                        break;
                    case 4:
                        Console.Write("Nhập tên dịch vụ cần tìm: ");
                        string tenDV = Console.ReadLine();
                        spa.XuatMotDV(spa.TimDVBangTen(tenDV));
                        break;
                    case 5:
                        Console.Write("Nhập tên khách hàng cần tìm: ");
                        string tenKH = Console.ReadLine();
                        List<DichVuDTO> dsdv = spa.TimDSDVKHX(tenKH); if (dsdv.Any())
                        {
                            Console.WriteLine($"Danh sách dịch vụ khánh hàng {tenKH} đã sử dụng là: ");
                            spa.XuatDSDV(dsdv);
                        }
                        else
                        {
                            Console.WriteLine("Khách hàng không tồn tại!");
                        }
                        break;
                    case 6:
                        spa.UpdateKinhPhiDVCSSD();
                        break;
                    case 7:
                        Console.WriteLine("Danh sách dịch vụ có giá trên 500: \n");
                        spa.XuatDSDV(spa.TimDSDVGiaTren500());
                        break;
                    case 8:
                        Console.WriteLine("Danh sách dịch vụ chăm sóc sắc đẹp: \n");
                        spa.XuatDSDV(spa.TimDSDV_ChamSocSacDep());
                        break;
                    case 9:
                        Console.WriteLine("Danh sách khách hàng làm hơn 3 dịch vụ: \n");
                        spa.XuatDSKH(spa.XuatDSKH_LonHon3DV());
                        break;
                    case 10:
                        Console.WriteLine("Danh sách dịch vụ dưỡng sinh trị liệu: \n");
                        spa.XuatDSDV(spa.XuatDSDV_DuongSinh());
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại!");
                        break;
                }

                if (choice != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để quay về Menu...");
                    Console.ReadKey();
                }

            } while (choice != 0);
        }
    }
}