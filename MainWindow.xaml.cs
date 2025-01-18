using System.Windows;

namespace uas_pogdas_rev
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Membuka GuruPage
        private void OpenGuruPage(object sender, RoutedEventArgs e)
        {
            GuruPage guruPage = new GuruPage();
            guruPage.Show();
            this.Close();  // Menutup MainWindow setelah membuka GuruPage
        }

        // Membuka MuridPage
        private void OpenMuridPage(object sender, RoutedEventArgs e)
        {
            MuridPage muridPage = new MuridPage();
            muridPage.Show();
            this.Close();  // Menutup MainWindow setelah membuka MuridPage
        }

        // Membuka MataPelajaranPage
        private void OpenMataPelajaranPage(object sender, RoutedEventArgs e)
        {
            MataPelajaranPage mataPelajaranPage = new MataPelajaranPage();
            mataPelajaranPage.Show();
            this.Close();  // Menutup MainWindow setelah membuka MataPelajaranPage
        }

        // Membuka InputPage
        private void OpenInputPage(object sender, RoutedEventArgs e)
        {
            InputPage inputPage = new InputPage();
            inputPage.Show();
            this.Close();  // Menutup MainWindow setelah membuka InputPage
        }

        // Menangani Logout
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
