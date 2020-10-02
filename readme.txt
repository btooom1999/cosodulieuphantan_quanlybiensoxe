Trước khi thực hiện chạy chương trình:
    * Kiểm tra sql có phải là sql hỗ trợ phân tán hay không? (Trừ phiên bản sql express thì tất cả phiên bản khác đều hỗ trợ phân tán).
    * Nếu sql có hỗ trợ thì bắt đầu phân tán dữ liệu (Hướng dẫn cách phân tán dữ liệu sẽ có trong word và dữ liệu cần phân tán cũng gửi theo).
    * Cài đặt Visual Studio 2012 trở lên.

Sau khi thực hiện các bước trên:
    * Mở phần mềm của nhóm, vào form DangNhap phần "public String nameserver()" sửa lại các giá trị return theo đúng tên server của thầy.
	+ "return của if" sẽ là tên server cơ sở dữ liệu chi nhánh TP. HCM (trung tâm).
	+ "return của else if" sẽ là tên server cơ sở dữ liệu của chi nhánh Long An.
	+ "return của else" sẽ là tên server cơ sở dữ liệu của chi nhánh còn lại.