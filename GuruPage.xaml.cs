using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.IO;
using uas_pogdas_rev;

namespace uas_pogdas_rev
{
    public partial class GuruPage : Window
    {
        private int selectedId = -1;
        public GuruPage()
        {
            InitializeComponent();  // Pastikan ini ada
            DebugDatabasePath();
            LoadData();
        }

        private void LoadData()
        {
            DataGridGuru.ItemsSource = DatabaseHelper.GetGuruData().DefaultView;
        }

        private void DebugDatabasePath()
        {
            // Pastikan path ini sesuai dengan lokasi database Anda
            string fullPath = Path.GetFullPath(@"C:\Users\Thinkpad\source\repos\PraktikumDatabase\data_sekolah.db");
           
        }

        private void AddGuru(object sender, RoutedEventArgs e)
        {
            try
            {
                // Menambahkan data baru
                string ttl = TTL_txt.SelectedDate.HasValue ? TTL_txt.SelectedDate.Value.ToString("yyyy-MM-dd") : "";

                DatabaseHelper.InsertGuru(
                name_txt.Text,
                ttl,
                alamat_txt.Text,
                email_txt.Text,
                Convert.ToInt32(gaji_txt.Text) // Pastikan gaji_txt hanya berisi angka
);


                MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearData();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataGridGuru_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Mengisi input field berdasarkan baris yang dipilih
            if (DataGridGuru.SelectedItem is DataRowView row)
            {
                selectedId = Convert.ToInt32(row["Id"]);
                name_txt.Text = row["Nama"].ToString();

                // Parsing tanggal untuk DatePicker
                if (DateTime.TryParse(row["TTL"].ToString(), out DateTime ttl))
                {
                    TTL_txt.SelectedDate = ttl;
                }
                else
                {
                    TTL_txt.SelectedDate = null;
                }

                alamat_txt.Text = row["Alamat"].ToString();
                email_txt.Text = row["Email"].ToString();
                gaji_txt.Text = row["Gaji"].ToString();
            }
        }

        private void EditGuru(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedId == -1)
                {
                    MessageBox.Show("Pilih data yang ingin diperbarui.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!TTL_txt.SelectedDate.HasValue)
                {
                    MessageBox.Show("Harap pilih tanggal lahir!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Konversi DateTime ke string
                string ttl = TTL_txt.SelectedDate.Value.ToString("yyyy-MM-dd");

                // Memperbarui data berdasarkan ID
                DatabaseHelper.UpdateGuru(
                    selectedId,
                    name_txt.Text,
                    ttl, // Nilai TTL dalam format string
                    alamat_txt.Text,
                    email_txt.Text,
                    Convert.ToInt32(gaji_txt.Text)
                );

                MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearData();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ClearData()
        {
            // Mengosongkan input field
            name_txt.Clear();
            TTL_txt.SelectedDate = null;
            alamat_txt.Clear();
            email_txt.Clear();
            gaji_txt.Clear();
            selectedId = -1;
        }
        private void DeleteGuru(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void GoToMainPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Clearguru(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedId == -1)
                {
                    MessageBox.Show("Pilih data yang ingin dihapus.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Menghapus data berdasarkan ID
                DatabaseHelper.DeleteGuru(selectedId);

                MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearData();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    
    
    }
}
