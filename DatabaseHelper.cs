using System.Data;
using System.Data.SQLite;

namespace uas_pogdas_rev
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = @"Data Source=C:\Users\Thinkpad\source\repos\PraktikumDatabase\data_sekolah.db;Version=3;";


        public static DataTable GetGuruData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Guru";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public static void InsertGuru(string nama, string ttl, string alamat, string email, double gaji)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Guru (Nama, TTL, Alamat, Email, Gaji) VALUES (@Nama, @TTL, @Alamat, @Email, @Gaji)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nama", nama);
                    cmd.Parameters.AddWithValue("@TTL", ttl);
                    cmd.Parameters.AddWithValue("@Alamat", alamat);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Gaji", gaji);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGuru(int id, string nama, string ttl, string alamat, string email, double gaji)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE Guru SET Nama = @Nama, TTL = @TTL, Alamat = @Alamat, Email = @Email, Gaji = @Gaji WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nama", nama);
                    cmd.Parameters.AddWithValue("@TTL", ttl);
                    cmd.Parameters.AddWithValue("@Alamat", alamat);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Gaji", gaji);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteGuru(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Guru WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable GetMuridData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Murid";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

    

        public static void UpdateMurid(int id, string nama, string ttl, string alamat, string email, string kelas)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE Murid SET Nama = @Nama, TTL = @TTL, Alamat = @Alamat, Email = @Email, Kelas = @Kelas WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nama", nama);
                    cmd.Parameters.AddWithValue("@TTL", ttl);
                    cmd.Parameters.AddWithValue("@Alamat", alamat);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Kelas", kelas);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteMurid(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Murid WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetMataPelajaranData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM MataPelajaran";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }


        public static void UpdateMataPelajaran(int id, string namaMapel, string guruPengampu, string JumlahJam)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE MataPelajaran SET namaMapel = @namaMapel, guruPengampu = @guruPengampu, JumlahJam = @JumlahJam WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@namaMapel", namaMapel);
                    cmd.Parameters.AddWithValue("@guruPengampu", guruPengampu);
                    cmd.Parameters.AddWithValue("@JumlahJam", JumlahJam);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteMataPelajaran(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM MataPelajaran WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertMurid(string nama, string ttl, string alamat, string email, string kelas)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Murid (Nama, TTL, Alamat, Email, Kelas) VALUES (@Nama, @TTL, @Alamat, @Email, @Kelas)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nama", nama);
                    cmd.Parameters.AddWithValue("@TTL", ttl);
                    cmd.Parameters.AddWithValue("@Alamat", alamat);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Kelas", kelas);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertMataPelajaran(string namaMapel, string guruPengampu, string jumlahJam)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO MataPelajaran (NamaMapel, GuruPengampu, JumlahJam) VALUES (@NamaMapel, @GuruPengampu, @JumlahJam)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NamaMapel", namaMapel);
                    cmd.Parameters.AddWithValue("@GuruPengampu", guruPengampu);
                    cmd.Parameters.AddWithValue("@JumlahJam", jumlahJam);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
