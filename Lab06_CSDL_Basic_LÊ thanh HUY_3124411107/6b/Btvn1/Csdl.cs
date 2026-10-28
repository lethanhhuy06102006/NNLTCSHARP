namespace QuanLyCuaHang {
    //Chứa chuỗi kết nối dùng chung cho tất cả các form
    internal static class CSDL {
        //Sửa Server cho đúng máy của bạn, ví dụ: .\SQLEXPRESS, (localdb)\MSSQLLocalDB, localhost
        public const string CHUOI_KET_NOI =
            @"Server=.\SQLEXPRESS;Database=QLCuaHang;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}