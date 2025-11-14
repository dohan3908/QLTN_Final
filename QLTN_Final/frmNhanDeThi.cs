using DevExpress.XtraEditors.Mask.Design;
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
    public partial class frmNhanDeThi : Form
    {
        private string MaSV; // Biến lưu mã sinh viên
        public frmNhanDeThi(string MaSV)
        {
            InitializeComponent();
            this.MaSV = MaSV;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-16RTLLC\HPELITEBOOK840G5;Initial Catalog=QLTN;Integrated Security=True;Encrypt=False");

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void frmNhanDeThi_Load(object sender, EventArgs e)
        {
            string query = "SELECT HoTen FROM SinhVien WHERE MaSV = @maSV";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@maSV", MaSV);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtTenSV.Text = reader["HoTen"].ToString(); // txtTenSV là textbox hiển thị họ tên
            }
            conn.Close();
        }

        private void btnLamBai3_Click(object sender, EventArgs e)
        {
            string MaCaThi = txtNhapMaCaThi.Text.Trim();
            string query = "SELECT * FROM CaThi WHERE MaCaThi = @maCaThi";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@maCaThi", MaCaThi);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Nếu cần lấy thêm thông tin từ CaThi, có thể dùng reader["..."]
                conn.Close();

                frmSinhVien f = new frmSinhVien(MaSV, MaCaThi); // truyền sang form làm bài
                f.Show();
                this.Hide();
            }
            else
            {
                conn.Close();
                MessageBox.Show("Mã ca thi không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
