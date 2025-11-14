using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN_Final
{
    public partial class FrmNhapcauhoi : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string str, sql;
        public FrmNhapcauhoi()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmGV f = new FrmGV();
            this.Hide();
            f.ShowDialog();
        }

        private void cbLoaicauhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string checkSql = "SELECT COUNT(*) FROM ChiTietCauHoi WHERE MaCauHoi = @MaCauHoi";
            SqlCommand checkCmd = new SqlCommand(checkSql, conn);
            checkCmd.Parameters.AddWithValue("@MaCauHoi", txtMaCauHoi.Text);
            int count = (int)checkCmd.ExecuteScalar();

            if (count == 0)
            {
                // Thực hiện chèn như ở trên
            }
            else
            {
                MessageBox.Show("Mã câu hỏi đã tồn tại. Vui lòng nhập mã khác.");
            }

            string sql = "INSERT INTO ChiTietCauHoi (MaCauHoi, NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung, MaHP, LoaiCauHoi, MucDo) " +
                         "VALUES (@MaCauHoi, @NoiDung, @DapAnA, @DapAnB, @DapAnC, @DapAnD, @DapAnDung, @MaHP, @LoaiCauHoi, @MucDo)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaCauHoi", txtMaCauHoi.Text);
            cmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text);
            cmd.Parameters.AddWithValue("@DapAnA", txtA.Text);
            cmd.Parameters.AddWithValue("@DapAnB", txtB.Text);
            cmd.Parameters.AddWithValue("@DapAnC", txtC.Text);
            cmd.Parameters.AddWithValue("@DapAnD", txtD.Text);
            cmd.Parameters.AddWithValue("@DapAnDung", txtDung.Text);
            cmd.Parameters.AddWithValue("@MaHP", cboHocPhan.SelectedValue);
            cmd.Parameters.AddWithValue("@LoaiCauHoi", cboLoaiCauHoi.Text);
            cmd.Parameters.AddWithValue("@MucDo", cboMucDo.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật thành công");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Vi phạm PRIMARY KEY
                {
                    MessageBox.Show("Mã câu hỏi đã tồn tại. Không thể chèn trùng.");
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
        }

        

        private void FrmNhapcauhoi_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Data Source=DESKTOP-16RTLLC\HPELITEBOOK840G5;Initial Catalog=QLTN;Integrated Security=True;Encrypt=False";
            conn.Open();

            string sql = "SELECT MaHP, TenHP FROM HocPhan";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cboHocPhan.DataSource = dt;
            cboHocPhan.DisplayMember = "TenHP"; // Hiển thị tên học phần
            cboHocPhan.ValueMember = "MaHP";    // Lưu giá trị là mã học phần
            txtPreQues.Text = new SqlCommand("SELECT TOP 1 MaCauHoi FROM ChiTietCauHoi ORDER BY MaCauHoi DESC", conn).ExecuteScalar().ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            MessageBox.Show(" Hãy nhập thông tin câu hỏi sau đó ấn cập nhập để hoàn thành thêm câu hỏi");
            txtMaCauHoi.Focus();// Đưa con trỏ về txtManhom để nhập liệu
            txtPreQues.Text = new SqlCommand("SELECT TOP 1 MaCauHoi FROM ChiTietCauHoi ORDER BY MaCauHoi DESC", conn).ExecuteScalar().ToString();

        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            FrmCauhoi f = new FrmCauhoi();
            this.Hide();
            f.ShowDialog();

        }

        private void cboHocPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        
        }
        

        private void ClearForm()
        {
            txtMaCauHoi.Clear();
            txtNoiDung.Clear();
            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            txtD.Clear();
            txtDung.Clear();
            cboHocPhan.SelectedIndex = -1;
            cboLoaiCauHoi.SelectedIndex = -1;
            cboMucDo.SelectedIndex = -1; 
        }
    }
}
