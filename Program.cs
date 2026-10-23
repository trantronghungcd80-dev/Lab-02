using System;
using System.Text;

namespace Lab02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập hỗ trợ hiển thị tiếng Việt trên Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int[]? mang = null;
            bool dangChay = true;

            while (dangChay)
            {
                HienThiMenu();
                int luaChon = NhapLuaChonMenu();

                Console.WriteLine();
                switch (luaChon)
                {
                    case 1:
                        Console.WriteLine("--- 1. NHẬP MẢNG ---");
                        mang = NhapMang();
                        break;

                    case 2:
                        Console.WriteLine("--- 2. XUẤT MẢNG ---");
                        if (KiemTraMang(mang))
                        {
                            XuatMang(mang!);
                        }
                        break;

                    case 3:
                        Console.WriteLine("--- 3. TÍNH TỔNG ---");
                        if (KiemTraMang(mang))
                        {
                            int tong = TinhTong(mang!);
                            Console.WriteLine($"Tổng các phần tử trong mảng: {tong}");
                        }
                        break;

                    case 4:
                        Console.WriteLine("--- 4. TÌM MAX / MIN ---");
                        if (KiemTraMang(mang))
                        {
                            int max = TimMax(mang!);
                            int min = TimMin(mang!);
                            Console.WriteLine($"Giá trị lớn nhất (Max): {max}");
                            Console.WriteLine($"Giá trị nhỏ nhất (Min): {min}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("--- 5. ĐẾM CHẴN / LẺ ---");
                        if (KiemTraMang(mang))
                        {
                            int soChan = DemChan(mang!);
                            int soLe = DemLe(mang!);
                            Console.WriteLine($"Số lượng phần tử chẵn: {soChan}");
                            Console.WriteLine($"Số lượng phần tử lẻ: {soLe}");
                        }
                        break;

                    case 6:
                        Console.WriteLine("--- 6. SẮP XẾP TĂNG DẦN ---");
                        if (KiemTraMang(mang))
                        {
                            SapXepTangDan(mang!);
                            Console.WriteLine("Mảng sau khi sắp xếp tăng dần:");
                            XuatMang(mang!);
                        }
                        break;

                    case 7:
                        Console.WriteLine("--- 7. TÌM KIẾM PHẦN TỬ ---");
                        if (KiemTraMang(mang))
                        {
                            int x = NhapSoNguyen("Nhập giá trị x cần tìm: ");
                            int viTri = TimKiem(mang!, x);
                            if (viTri != -1)
                            {
                                Console.WriteLine($"Tìm thấy {x} tại vị trí đầu tiên: {viTri} (chỉ số index tính từ 0)");
                            }
                            else
                            {
                                Console.WriteLine($"Không tìm thấy {x} trong mảng.");
                            }
                        }
                        break;

                    case 0:
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình. Tạm biệt!");
                        dangChay = false;
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn từ 0 đến 7.");
                        break;
                }

                if (dangChay)
                {
                    if (!Console.IsInputRedirected)
                    {
                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Hiển thị danh sách các chức năng trong Menu
        /// </summary>
        static void HienThiMenu()
        {
            Console.WriteLine("================================");
            Console.WriteLine("           ===== MENU =====");
            Console.WriteLine("================================");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
            Console.WriteLine("================================");
            Console.Write("Chon chuc nang: ");
        }

        /// <summary>
        /// Nhập lựa chọn menu và kiểm tra tính hợp lệ
        /// </summary>
        static int NhapLuaChonMenu()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    return choice;
                }
                Console.Write("Lựa chọn không hợp lệ! Vui lòng nhập số tương ứng với chức năng: ");
            }
        }

        /// <summary>
        /// Kiểm tra mảng đã được khởi tạo hay chưa trước khi thực hiện các chức năng xử lý
        /// </summary>
        static bool KiemTraMang(int[]? a)
        {
            if (a == null || a.Length == 0)
            {
                Console.WriteLine("Cảnh báo: Mảng chưa được nhập! Vui lòng chọn chức năng 1 để nhập mảng trước.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Nhập một số nguyên từ bàn phím kèm kiểm tra lỗi
        /// </summary>
        static int NhapSoNguyen(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                Console.WriteLine("Lỗi: Dữ liệu nhập không phải số nguyên hợp lệ! Vui lòng nhập lại.");
            }
        }

        /// <summary>
        /// Nhập số nguyên dương (> 0) từ bàn phím kèm kiểm tra lỗi
        /// </summary>
        static int NhapSoNguyenDuong(string message)
        {
            while (true)
            {
                int n = NhapSoNguyen(message);
                if (n > 0)
                {
                    return n;
                }
                Console.WriteLine("Lỗi: Số lượng phần tử phải là số nguyên dương (> 0)! Vui lòng nhập lại.");
            }
        }

        /// <summary>
        /// Nhập số lượng phần tử n và n phần tử của mảng
        /// </summary>
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhập số lượng phần tử n (n > 0): ");
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen($"Nhập phần tử a[{i}]: ");
            }

            Console.WriteLine("=> Đã nhập mảng thành công!");
            return a;
        }

        /// <summary>
        /// In toàn bộ phần tử của mảng ra màn hình
        /// </summary>
        static void XuatMang(int[] a)
        {
            if (a == null || a.Length == 0)
            {
                Console.WriteLine("Mảng rỗng!");
                return;
            }

            Console.Write("Mảng hiện tại: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + (i < a.Length - 1 ? " " : ""));
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Tính tổng tất cả phần tử trong mảng
        /// </summary>
        static int TinhTong(int[] a)
        {
            int tong = 0;
            foreach (int x in a)
            {
                tong += x;
            }
            return tong;
        }

        /// <summary>
        /// Tìm phần tử có giá trị lớn nhất trong mảng
        /// </summary>
        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
        }

        /// <summary>
        /// Tìm phần tử có giá trị nhỏ nhất trong mảng
        /// </summary>
        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }
            return min;
        }

        /// <summary>
        /// Đếm số lượng phần tử chẵn trong mảng
        /// </summary>
        static int DemChan(int[] a)
        {
            int dem = 0;
            foreach (int x in a)
            {
                if (x % 2 == 0)
                {
                    dem++;
                }
            }
            return dem;
        }

        /// <summary>
        /// Đếm số lượng phần tử lẻ trong mảng
        /// </summary>
        static int DemLe(int[] a)
        {
            int dem = 0;
            foreach (int x in a)
            {
                if (x % 2 != 0)
                {
                    dem++;
                }
            }
            return dem;
        }

        /// <summary>
        /// Sắp xếp mảng theo thứ tự tăng dần (sử dụng thuật toán Interchange Sort)
        /// </summary>
        static void SapXepTangDan(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Tìm kiếm phần tử x trong mảng, trả về vị trí index đầu tiên tìm thấy hoặc -1 nếu không tìm thấy
        /// </summary>
        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
