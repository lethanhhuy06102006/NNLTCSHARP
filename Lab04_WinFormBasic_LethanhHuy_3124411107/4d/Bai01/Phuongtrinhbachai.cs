using System;
using System.Globalization;

namespace GiaiPhuongTrinh {
    //Class giải phương trình bậc nhất ax + b = 0 và bậc hai ax^2 + bx + c = 0
    public class PhuongTrinhBacHai {
        private double _a, _b, _c;

        //Property get/set
        public double a {
            get { return _a; }
            set { _a = value; }
        }
        public double b {
            get { return _b; }
            set { _b = value; }
        }
        public double c {
            get { return _c; }
            set { _c = value; }
        }

        //Phương thức khởi tạo
        public PhuongTrinhBacHai() {
            _a = _b = _c = 0;
        }

        public PhuongTrinhBacHai(double a, double b) { //dùng cho bậc nhất
            _a = a;
            _b = b;
            _c = 0;
        }

        public PhuongTrinhBacHai(double a, double b, double c) { //dùng cho bậc hai
            _a = a;
            _b = b;
            _c = c;
        }

        //Định dạng số có 2 chữ số thập phân, vd: 2.00
        private string Dang(double x) {
            if (x == 0) x = 0; //tránh hiện -0.00
            return x.ToString("0.00", CultureInfo.InvariantCulture);
        }

        //Giải ax + b = 0
        public string GiaiBacNhat() {
            if (_a == 0) {
                if (_b == 0)
                    return "Phương trình vô số nghiệm";
                return "Phương trình vô nghiệm";
            }
            return "Phương trình có nghiệm x = " + Dang(-_b / _a);
        }

        //Giải ax^2 + bx + c = 0
        public string GiaiBacHai() {
            if (_a == 0) { //a = 0 thì trở thành bậc nhất bx + c = 0
                PhuongTrinhBacHai pt = new PhuongTrinhBacHai(_b, _c);
                return "a = 0, trở thành phương trình bậc nhất.\r\n" + pt.GiaiBacNhat();
            }

            double delta = _b * _b - 4 * _a * _c;

            if (delta < 0)
                return "Phương trình vô nghiệm";

            if (delta == 0)
                return "Phương trình có nghiệm kép x1 = x2 = " + Dang(-_b / (2 * _a));

            double x1 = (-_b + Math.Sqrt(delta)) / (2 * _a);
            double x2 = (-_b - Math.Sqrt(delta)) / (2 * _a);
            return "Phương trình có 2 nghiệm phân biệt:\r\nx1 = " + Dang(x1) + ", x2 = " + Dang(x2);
        }
    }
}