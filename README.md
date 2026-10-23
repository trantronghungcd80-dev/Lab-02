# COMP1019 - Lập trình trên Windows
## BUỔI 2 - LAB 02: C# cơ bản - Quản lý mảng số nguyên bằng Console

### 1. Mục tiêu bài lab
- Ôn lại cấu trúc chương trình C# Console App.
- Sử dụng biến, kiểu dữ liệu, toán tử, điều kiện (`if-else`, `switch-case`) và vòng lặp (`while`, `for`, `foreach`).
- Thao tác xử lý trên mảng một chiều các số nguyên.
- Tách chương trình thành các phương thức (hàm) rõ ràng, dễ bảo trì và dễ giải thích.
- Kiểm tra tính hợp lệ của dữ liệu nhập (validation) và phòng tránh lỗi ngoại lệ khi người dùng nhập sai.

---

### 2. Danh sách các chức năng (Menu)
Chương trình cung cấp menu tương tác liên tục:
```text
================================
           ===== MENU =====
================================
1. Nhap mang
2. Xuat mang
3. Tinh tong
4. Tim max/min
5. Dem chan/le
6. Sap xep tang dan
7. Tim kiem
0. Thoat
================================
Chon chuc nang: 
```

- **1. Nhập mảng**: Nhập số lượng phần tử $n$ ($n > 0$), kiểm tra nếu $n \le 0$ hoặc sai định dạng thì yêu cầu nhập lại; sau đó nhập từng phần tử $a[i]$.
- **2. Xuất mảng**: In toàn bộ phần tử của mảng ra màn hình.
- **3. Tính tổng**: Tính và in ra tổng các phần tử trong mảng.
- **4. Tìm max/min**: Tìm và in giá trị lớn nhất và nhỏ nhất trong mảng.
- **5. Đếm chẵn/lẻ**: Đếm số lượng phần tử chẵn và lẻ (hỗ trợ cả số âm và số 0).
- **6. Sắp xếp tăng dần**: Sắp xếp các phần tử của mảng theo thứ tự tăng dần bằng thuật toán Interchange Sort và in mảng sau sắp xếp.
- **7. Tìm kiếm**: Nhập giá trị $x$, thông báo có tồn tại $x$ trong mảng hay không và in vị trí xuất hiện đầu tiên (chỉ số index tính từ 0).
- **0. Thoát**: Dừng và kết thúc chương trình.

*Lưu ý kỹ thuật*: Các chức năng từ 2 đến 7 đều có kiểm tra xem mảng đã được nhập hay chưa; nếu chưa, chương trình sẽ cảnh báo và yêu cầu người dùng chọn chức năng 1 trước.

---

### 3. Cấu trúc các phương thức trong chương trình
- `static int NhapSoNguyen(string message)`: Nhập số nguyên an toàn, có vòng lặp kiểm tra lỗi với `int.TryParse`.
- `static int NhapSoNguyenDuong(string message)`: Nhập số nguyên dương ($> 0$), yêu cầu nhập lại nếu $\le 0$.
- `static int[] NhapMang()`: Nhập số lượng phần tử $n$ và từng phần tử của mảng.
- `static void XuatMang(int[] a)`: Hiển thị mảng ra màn hình.
- `static int TinhTong(int[] a)`: Tính tổng các phần tử của mảng.
- `static int TimMax(int[] a)`: Tìm giá trị lớn nhất trong mảng.
- `static int TimMin(int[] a)`: Tìm giá trị nhỏ nhất trong mảng.
- `static int DemChan(int[] a)`: Đếm số lượng phần tử chẵn (`x % 2 == 0`).
- `static int DemLe(int[] a)`: Đếm số lượng phần tử lẻ (`x % 2 != 0`).
- `static void SapXepTangDan(int[] a)`: Sắp xếp mảng tăng dần.
- `static int TimKiem(int[] a, int x)`: Tìm kiếm vị trí đầu tiên của phần tử $x$ trong mảng (trả về -1 nếu không thấy).
- `static bool KiemTraMang(int[]? a)`: Kiểm tra mảng đã được nhập trước khi xử lý.

---

### 4. Hướng dẫn chạy chương trình

#### Cách 1: Sử dụng .NET CLI (Command Prompt / PowerShell / Terminal)
1. Mở thư mục dự án:
   ```bash
   cd Lab-02
   ```
2. Chạy ứng dụng:
   ```bash
   dotnet run
   ```

#### Cách 2: Sử dụng Visual Studio (2019 / 2022 trở lên)
1. Mở file `Lab02.sln` hoặc `Lab02.csproj`.
2. Nhấn phím `F5` hoặc nút **Start** để biên dịch và chạy chương trình.

---

### 5. Kết quả kiểm thử mẫu (Test Cases)

| STT | Dữ liệu kiểm thử | Kết quả mong đợi |
| :---: | :--- | :--- |
| **1** | Mảng 5 phần tử: `4 1 9 2 7` | Tổng = 23, Max = 9, Min = 1, Chẵn = 2, Lẻ = 3 |
| **2** | Mảng 4 phần tử: `-3 0 8 -1` | Tổng = 4, Max = 8, Min = -3, Chẵn = 2, Lẻ = 2 |
| **3** | Tìm $x = 9$ trong mảng `4 1 9 2 7` | Tìm thấy tại vị trí index đầu tiên: 2 |
| **4** | Tìm $x = 5$ trong mảng `4 1 9 2 7` | Không tìm thấy trong mảng |
| **5** | Nhập $n = 0$ hoặc $n < 0$ | Thông báo lỗi và yêu cầu nhập lại |
| **6** | Chọn chức năng khi chưa nhập mảng | Cảnh báo yêu cầu nhập mảng trước |
| **7** | Nhập menu sai (chữ cái hoặc số ngoài 0-7) | Thông báo lựa chọn không hợp lệ, không bị dừng chương trình |
