# Giới thiệu về Dự án Pharmacy Management System

**Pharmacy Management System** là một ứng dụng quản lý thuốc hiện đại, được thiết kế để tối ưu hóa quy trình quản lý trong các hiệu thuốc. Dự án này tích hợp nhiều chức năng chính như quản lý thuốc, quản lý kho, quản lý nhân sự, quản lý tài chính, cùng với nhiều tính năng tiện ích khác. Mục tiêu của phần mềm là đơn giản hóa công tác quản lý, giảm thiểu thời gian và công sức, đồng thời nâng cao hiệu quả so với các phương pháp quản lý truyền thống như sổ sách.

## Công nghệ Sử dụng

Hệ thống được phát triển trên nền tảng **WinForms C#** và sử dụng **MySQL** làm cơ sở dữ liệu để quản lý và điều phối thông tin toàn diện. Việc lựa chọn WinForms C# và MySQL dựa trên tính linh hoạt và hiệu suất mạnh mẽ của MySQL, kết hợp với khả năng phát triển nhanh và hệ sinh thái phong phú của WinForms.

## Cấu trúc Tổ chức Dự án

Dự án được tổ chức theo mô hình **MVP Pattern** (Model-View-Presenter), một kiến trúc phần mềm hiệu quả cho phép tách biệt rõ ràng giữa phần logic và giao diện người dùng. Mô hình này đặc biệt hiệu quả với công nghệ Winform C#. Mô hình MVP giúp dễ dàng phát triển và duy trì mã nguồn mà không bị phụ thuộc vào giao diện cụ thể. Các thành phần chính trong mô hình MVP bao gồm:

1. **Model**: Chịu trách nhiệm quản lý dữ liệu và logic ứng dụng, bao gồm xử lý thông tin và quản lý trạng thái.
2. **View**: Phần giao diện người dùng, nơi hiển thị dữ liệu và nhận tương tác từ người dùng.
3. **Presenter**: Kết nối giữa Model và View, xử lý các yêu cầu từ View và cập nhật Model, đảm bảo logic ứng dụng hoạt động một cách chính xác.

Để nâng cao khả năng bảo trì và mở rộng cho dự án, Model được chia thành hai phần:
1. **Service**: Chứa các phương thức xử lý logic nghiệp vụ và tương tác với cơ sở dữ liệu thông qua các repository.
2. **Repositories**: Cung cấp các phương thức truy xuất dữ liệu từ cơ sở dữ liệu.

![MVP Pattern](https://i.ibb.co/G0ZFkcB/mvp-pattern.png)  <!-- Chèn URL ảnh minh họa MVP Pattern tại đây -->

## Các Chức năng Chính

### Đăng nhập, Đăng ký, và Phân quyền
- **Đăng nhập**: Người dùng có thể đăng nhập vào hệ thống bằng tài khoản và mật khẩu đã đăng ký.
- **Đăng ký**: Hỗ trợ đăng ký tài khoản mới cho người dùng chưa có.
- **Phân quyền**: Quản lý quyền truy cập của người dùng theo vai trò cụ thể.
- **Chức năng quên mật khẩu**: Chức năng cập nhật đang được phát triển.
- **Đăng xuất**: Cho phép người dùng thoát khỏi hệ thống.

### Quản lý Thuốc
- **Thêm thuốc**: Cung cấp tính năng thêm mới thuốc và tải hình ảnh liên quan.
- **Cập nhật thông tin**: Hỗ trợ cập nhật thông tin thuốc hiện có.
- **Xóa thuốc**: Cho phép xóa thuốc khỏi danh sách quản lý.

### Quản lý Bán Thuốc
- **Lựa chọn sản phẩm**: Người dùng chọn sản phẩm khi khách hàng mua thuốc.
- **Tính tiền tự động**: Hệ thống tự động tính toán tiền và in hóa đơn cho khách hàng.
- **Lưu thông tin hóa đơn**: Cập nhật số lượng thuốc sau mỗi giao dịch bán hàng.
- **Thống kê doanh thu**: Cung cấp khả năng thống kê doanh thu và tìm kiếm thuốc theo loại, tên, mã thuốc, v.v.

### Quản lý Kho Thuốc
- **Thêm hóa đơn nhập thuốc**: Cho phép nhập thông tin hóa đơn nhập thuốc và theo dõi tình hình tồn kho.
- **Theo dõi thuốc**: Quản lý tình trạng thuốc hết hạn, số lượng còn lại trong kho, phân loại theo loại thuốc, nhà sản xuất và giá cả.

### Cập nhật Thêm
Dự án đang trong quá trình phát triển và cập nhật thêm nhiều chức năng mới, nhằm nâng cao hiệu quả và tiện ích cho người dùng.
