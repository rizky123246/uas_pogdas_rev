using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace uas_pogdas_rev
{
    public partial class InputPage : Window
    {
        public InputPage()
        {
            InitializeComponent();
        }

        private void TableSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TableSelector.SelectedItem is ComboBoxItem selectedItem)
            {
                string tableName = selectedItem.Content.ToString();
                GenerateInputFields(tableName);
            }
        }

        private void GenerateInputFields(string table)
        {
            if (string.IsNullOrEmpty(table)) return;

            InputFields.Children.Clear();

            switch (table)
            {
                case "Guru":
                    InputFields.Children.Add(CreateLabeledTextBox("Nama"));
                    InputFields.Children.Add(CreateLabeledTextBox("TTL"));
                    InputFields.Children.Add(CreateLabeledTextBox("Alamat"));
                    InputFields.Children.Add(CreateLabeledTextBox("Email"));
                    InputFields.Children.Add(CreateLabeledTextBox("Gaji"));
                    break;

                case "Murid":
                    InputFields.Children.Add(CreateLabeledTextBox("Nama"));
                    InputFields.Children.Add(CreateLabeledTextBox("TTL"));
                    InputFields.Children.Add(CreateLabeledTextBox("Alamat"));
                    InputFields.Children.Add(CreateLabeledTextBox("Email"));
                    InputFields.Children.Add(CreateLabeledTextBox("Kelas"));
                    break;

                case "MataPelajaran":
                    InputFields.Children.Add(CreateLabeledTextBox("NamaMapel"));
                    InputFields.Children.Add(CreateLabeledTextBox("GuruPengampu"));
                    InputFields.Children.Add(CreateLabeledTextBox("JumlahJam"));
                    break;
            }
        }

        private StackPanel CreateLabeledTextBox(string placeholder)
        {
            StackPanel stackPanel = new StackPanel { Margin = new Thickness(5) };

            TextBlock placeholderLabel = new TextBlock
            {
                Text = placeholder,
                FontStyle = FontStyles.Italic,
                Foreground = new SolidColorBrush(Colors.Gray),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 5)
            };

            TextBox textBox = new TextBox
            {
                Width = 300,
                Tag = placeholder 
            };

            stackPanel.Children.Add(placeholderLabel);
            stackPanel.Children.Add(textBox);

            return stackPanel;
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            string table = (TableSelector.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (string.IsNullOrEmpty(table))
            {
                MessageBox.Show("Silakan pilih tabel terlebih dahulu.");
                return;
            }

           
            var inputData = new System.Collections.Generic.Dictionary<string, string>();
            foreach (var child in InputFields.Children)
            {
                if (child is StackPanel panel && panel.Children[1] is TextBox textBox)
                {
                    string key = textBox.Tag.ToString();
                    string value = textBox.Text;
                    inputData[key] = value;
                }
            }

       
            string connectionString = @"Data Source=C:\Users\Thinkpad\source\repos\PraktikumDatabase\data_sekolah.db;Version=3;"; 
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = string.Empty;

                    switch (table)
                    {
                        case "Guru":
                            sql = "INSERT INTO Guru (Nama, TTL, Alamat, Email, Gaji) VALUES (@Nama, @TTL, @Alamat, @Email, @Gaji)";
                            break;

                        case "Murid":
                            sql = "INSERT INTO Murid (Nama, TTL, Alamat, Email, Kelas) VALUES (@Nama, @TTL, @Alamat, @Email, @Kelas)";
                            break;

                        case "MataPelajaran":
                            sql = "INSERT INTO MataPelajaran (NamaMapel, GuruPengampu, JumlahJam) VALUES (@NamaMapel, @GuruPengampu, @JumlahJam)";
                            break;
                    }

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        foreach (var field in inputData)
                        {
                            command.Parameters.AddWithValue($"@{field.Key}", field.Value);
                        }

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data berhasil disimpan ke database.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
                }
            }
        }

        private void GoToMainPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
