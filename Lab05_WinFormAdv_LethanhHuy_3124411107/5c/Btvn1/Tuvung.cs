namespace TuDien {
    //Một từ trong từ điển: từ tiếng Anh và nghĩa tiếng Việt
    public class TuVung {
        public string Anh { get; set; }
        public string Viet { get; set; }

        public TuVung(string anh, string viet) {
            Anh = anh;
            Viet = viet;
        }
    }
}