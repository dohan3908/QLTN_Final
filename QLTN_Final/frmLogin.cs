using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTN_Final
{
    public partial class frmLogin : Form
    {
        private int soLanSai = 0;
        private const int MAX_SAI = 3;
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-16RTLLC\HPELITEBOOK840G5;Initial Catalog=QLTN;Integrated Security=True;Encrypt=False");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string query = "";
            SqlDataAdapter da;
            DataTable dt = new DataTable();

            try
            {
                // Xác định quyền đăng nhập
                if (rdoAdmin.Checked)
                {
                    query = "SELECT MaAdmin, MatKhau FROM Admin WHERE MaAdmin = '" + username + "' AND MatKhau = '" + password + "'";
                }
                else if (rdoGiangVien.Checked)
                {
                    query = "SELECT MaGV, MatKhau FROM GiangVien WHERE MaGV = '" + username + "' AND MatKhau = '" + password + "'";
                }
                else if (rdoSinhVien.Checked)
                {
                    query = "SELECT MaSV, MatKhau FROM SinhVien WHERE MaSV = '" + username + "' AND MatKhau = '" + password + "'";
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn tư cách đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện truy vấn
                da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@username", username);
                da.SelectCommand.Parameters.AddWithValue("@password", password);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    this.Hide();

                    if (rdoAdmin.Checked)
                    {
                        frmMainAdmin f = new frmMainAdmin();
                        f.Show();
                    }
                    else if (rdoGiangVien.Checked)
                    {
                        frmMainGV f = new frmMainGV();
                        f.Show();
                    }
                    else if (rdoSinhVien.Checked)
                    {
                        string MaSV = dt.Rows[0]["MaSV"].ToString();
                        frmNhanDeThi f = new frmNhanDeThi(MaSV);
                        f.Show();
                    }
                }
                else
                {
                    soLanSai++;

                    if (soLanSai >= MAX_SAI)
                    {
                        MessageBox.Show("Bạn đã nhập sai quá 3 lần. Tài khoản bị khóa tạm thời!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        btnLogin.Enabled = false;
                        return;
                    }

                    MessageBox.Show($"Sai tên đăng nhập hoặc mật khẩu! ({soLanSai}/{MAX_SAI})", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
