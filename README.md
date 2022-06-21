# :lab_coat: :jeans: Hệ thống website thương mại điện tử bán quần áo
## :computer: Các công nghệ, kĩ thuật áp dụng:
- Web server: Asp.Net MVC (.Net Core 5.0), Razor engine
- Hệ quản trị CSDL: MS SQL server
- Kỹ thuật được áp dụng: Bundle, minify, caching,...
- Framework hỗ trợ: Entity Framework, Bootstrap template


### :watch: Thời gian: 13/06/2022 ➡️ 17/07/2022 (TRONG 5 TUẦN)
# 💸 HỆ THỐNG ĐẤU GIÁ TỰ ĐỘNG - AUCTION MWG
# 🧑‍💻 CÔNG NGHỆ VÀ KỸ THUẬT ÁP DỤNG TRONG DỰ ÁN
- Web server: .NET CORE (5.0), Razor engine
- Hệ quản trị CSDL: MS SQL server
- Kỹ thuật được áp dụng: AJAX, Bundle, minify, caching...
- Framework hỗ trợ: Entity Framework, administrator bootstrap template
# ⏰ TIMELINE CHI TIẾT CHO DỰ ÁN
| Thời gian | Công việc| Ghi chú |
| :---:| :---| :--- |
| 13-19/6 | - Tìm hiểu các chức năng dự án. <br> - Xây dựng database. <br> - Nghiên cứu Entity framework. <br> - Xây đựng kế hoạch, phân chia thời gian công việc cho dự án. | Gần như đã hoàn thành |
| 20-26/6 <br> và <br> 27/6-3/7 | - Xây dựng trang đăng nhập hệ thống. <br> <br> - Quản lí sản phẩm: <br> + Hiển thị danh sách sản phẩm ra bảng dữ liệu. <br> + Thêm/sửa sản phẩm. <br>  + Xóa: nhấp vào nút Xóa của sản phẩm cần xóa trên bảng dữ liệu. <br> <br> - Quản lý đơn hàng: <br> + Hiển thị danh sách đơn hàng. <br> + Duyệt đơn: Duyệt những đơn đang chờ duyệt <br> + Hủy đơn: Hủy những đơn đang chờ duyệt. <br> <br> - Quản lí tài khoản: <br> + Hiển thị danh sách sản phẩm ra bảng dữ liệu. <br> + Tạo thêm tài khoản mới. <br> + Xóa: nhấp vào nút Xóa tài khoản cần xóa trên bảng dữ liệu. <br> + Xem lịch sử đăng nhập của tài khoản. <br> <br> - Quản lý các khuyến mãi: <br> + Hiển thị danh sách khuyến mãi. <br> + Thêm/sửa khuyến mãi. <br> + Xóa khuyến mãi. <br> <br> - Quản lí nhà cung cấp, loại sản phẩm: <br> + Hiển thị danh sách nhà cung cấp, loại sản phẩm. <br> + Thêm/sửa nhà cung cấp, loại sản phẩm. <br> + Xóa nhà cung cấp, loại sản phẩm. <br> <br> - Quản lí màu sắc, size sản phẩm (optinal): <br> + Hiển thị danh sách màu sắc, size sản phẩm. <br> + Thêm/sửa màu sắc, size sản phẩm. <br> + Xóa màu sắc, size sản phẩm. <br> <br> - Thống kê doanh thu: <br> +  Tổng doanh thu trung bình/năm, trung bình/tháng, trung bình/tuần. <br> + Tổng số đơn đặt. <br> + Tổng số người dùng. | |
| 4-10/7 <br> và <br> 11-17/7 | - Xây dựng trang chủ có header: Tìm tài khoản, xem sản phẩm, chức năng cho người mua, chức năng cho người bán. đăng nhập ( nếu chưa đăng nhập), đăng xuất (nếu chưa đăng xuất). Đăng kí tài khoản ( Nếu chưa có tài khoản). <br> - Về tài khoản: <br> • Xây dựng trang đăng nhập (nếu đang trong quá trình **ĐẤU GIÁ** thì bắt buộc phải đăng nhập để xác định danh tính). <br> • Xây dựng trang đăng kí tài khoản (nếu chưa có tài khoản). <br> • Chỉnh sửa thông tin tài khoản. <br> • Xem chi tiết thông tin cá nhân. <br><br> - Xây dụng chức năng cho người bán: <br> • Đang sản phẩm (Đăng sản phẩm mình muốn bán và chờ hệ thống phê duyệt). <br> • Hiển thị danh sách sản phẩm: ds được duyệt, đã có người mua, đã thanh toán. <br> • Thay đổi thông tin sản phẩm (**chỉ được thay đổi khi chưa đấu giá, chưa bán**). <br> • Tạo phiên đấu giá (nếu sản phẩm đã dc duyệt, bắt buộc phải tạo phiên đấu giá để sản phẩm mới có thể bán được, bên cạnh đó có thể thêm nút **mua ngay**). <br> • Hiển thị thời gian thực của sản phẩm đấu giá (**sử dụng AJAX**). <br> • Hủy phiên đấu giá (**chỉ được hủy khi time còn lại lớn hơn 15p**). <br><br> - Chức năng cho người mua: <br> • Tạo chức năng đấu giá tự động cho sản phẩm. <br> • Mua ngay: thêm vào danh sách mua ngay, sau khi sản phẩm được mua ngay thì phiên đấu giá sẽ dc hủy, người mua tiến hành thanh toán. <br> • Hủy đấu giá: Chỉ được hủy khi thời gian còn lại lớn hơn **5p** hoặc số tiền sản phẩm đã tăng khi đấu giá. <br> • Hiển thị sản phẩm dã mua: Tiến hành thanh toán và báo cáo vi phạm nếu sản phẩm gian dối. <br> - Chức năng khác: <br> • Hiển thị danh sách tìm kiếm. <br> • Hiển thị danh sách yêu thích. <br> • Hiển thị lịch sử tìm kiếm.  | |
