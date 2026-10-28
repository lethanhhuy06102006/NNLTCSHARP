namespace Bai04 {
    internal static class Program {
        [STAThread]
        static void Main() {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmBai04());
        }
    }
}