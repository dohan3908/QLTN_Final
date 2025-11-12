using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN_Final
{
    public partial class KetQuaThi : Form
    {
        private string maSV;
        private string maCaThi;
        private DateTime thoiGianBatDau;
        private int soCauDung;
        public KetQuaThi(string maSV, string maCa, DateTime batDau, int soCauDung)
        {
            InitializeComponent();

            this.maSV = maSV;
            this.maCaThi = maCa;
            this.thoiGianBatDau = batDau;
            this.soCauDung = soCauDung;

            double diem = Math.Round(soCauDung * 0.33, 2); // mỗi câu đúng 0.33 điểm
            lblKetQua.Text = $"{diem}/10";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KetQuaThi_Load(object sender, EventArgs e)
        {
            double diem = Math.Round(soCauDung * 0.33, 2);
            DateTime thoiGianKetThuc = DateTime.Now;

            string connectionString = @"Data Source=DESKTOP-16RTLLC\HPELITEBOOK840G5;Initial Catalog=QLTN;Integrated Security=True;Encrypt=False";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Kiểm tra sinh viên đã thi chưa
                string checkQuery = "SELECT COUNT(*) FROM DiemThi WHERE MaCaThi = @MaCaThi AND MaSV = @MaSV";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MaCaThi", maCaThi);
                    checkCmd.Parameters.AddWithValue("@MaSV", maSV);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        string insertQuery = "INSERT INTO DiemThi (MaCaThi, MaSV, DiemSo, ThoiGianBatDau, ThoiGianKetThuc) " +
                                             "VALUES (@MaCaThi, @MaSV, @DiemSo, @BatDau, @KetThuc)";

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@MaCaThi", maCaThi);
                            insertCmd.Parameters.AddWithValue("@MaSV", maSV);
                            insertCmd.Parameters.AddWithValue("@DiemSo", diem);
                            insertCmd.Parameters.AddWithValue("@BatDau", thoiGianBatDau);
                            insertCmd.Parameters.AddWithValue("@KetThuc", thoiGianKetThuc);

                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

    }
}
