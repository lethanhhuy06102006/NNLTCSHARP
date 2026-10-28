namespace Bai02 {
    internal static class Program {
        [STAThread]
        static void Main() {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmBai02());
        }
    }
}