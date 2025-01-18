using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.IO;
using uas_pogdas_rev;

namespace uas_pogdas_rev
{
    public partial class MataPelajaranPage : Window
    {
        private int selectedId = -1;
        public MataPelajaranPage()
        {
            InitializeComponent();  // Pastikan ini ada
            DebugDatabasePath();
            LoadData();
        }

        private void LoadData()
        {
            DataGridMataPelajaran.ItemsSource = DatabaseHelper.GetMataPelajaranData().DefaultView;
        }

        private void DebugDatabasePath()
        {
            // Pastikan path ini sesuai dengan lokasi database Anda
            string fullPath = Path.GetFullPath(@"C:\Users\Thinkpad\source\repos\PraktikumDatabase\data_sekolah.db");

        }

        private void AddMataPelajaran(object sender, RoutedEventArgs e)
        {
            try
            {
               

                DatabaseHelper.InsertMataPelajaran(
                name_txt.Text,
                guru_txt.Text,
                jumlahjam_txt.Text
        
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

        private void DataGridMataPelajaran_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Mengisi input field berdasarkan baris yang dipilih
            if (DataGridMataPelajaran.SelectedItem is DataRowView row)
            {
                selectedId = Convert.ToInt32(row["Id"]);
                name_txt.Text = row["namaMapel"].ToString();
                guru_txt.Text = row["guruPengampu"].ToString();
                jumlahjam_txt.Text = row["JumlahJam"].ToString();
                
            }
        }

        private void EditMataPelajaran(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedId == -1)
                {
                    MessageBox.Show("Pilih data yang ingin diperbarui.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                         
                
                DatabaseHelper.UpdateMataPelajaran(
                    selectedId,
                    name_txt.Text,
                    guru_txt.Text,
                    jumlahjam_txt.Text
                 
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
            guru_txt.Clear();
            jumlahjam_txt.Clear();
            selectedId = -1;
        }
        private void DeleteMataPelajaran(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void GoToMainPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ClearMataPelajaran(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedId == -1)
                {
                    MessageBox.Show("Pilih data yang ingin dihapus.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Menghapus data berdasarkan ID
                DatabaseHelper.DeleteMataPelajaran(selectedId);

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
