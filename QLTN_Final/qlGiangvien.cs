using DevExpress.XtraPrinting;
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
using DevExpress.XtraReports.UI;

namespace QLTN_Final
{
    public partial class qlGiangvien : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string str, sql;
        Boolean addnewflag = false;
        public qlGiangvien()
        {
            InitializeComponent();
        }

        public void NapCT()
        {
            int i = grdGV.CurrentRow.Index;
            txtHoten.Text= grdGV.Rows[i].Cells["Hoten"].Value.ToString();
            txtMaGV.Text= grdGV.Rows[i].Cells["MaGV"].Value.ToString();
            txtMakhoa.Text= grdGV.Rows[i].Cells["Makhoa"].Value.ToString();
            txtChucvu.Text= grdGV.Rows[i].Cells["Chucvu"].Value.ToString();
            txtMatkhau.Text= grdGV.Rows[i].Cells["Matkhau"].Value.ToString();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comGT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            grdGV.ClearSelection();
            grdGV.CurrentCell = grdGV[0, 0];
            NapCT();

        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(grdGV.CurrentRow.Index.ToString());
            if (i>0)
            {
                grdGV.CurrentCell = grdGV[0, i - 1];
                NapCT();
            }



        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(grdGV.CurrentRow.Index.ToString());
            if (i < grdGV.RowCount-1)
            {
                grdGV.CurrentCell = grdGV[0, i + 1];
                NapCT();
            }

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int i = grdGV.RowCount -1;
            grdGV.CurrentCell = grdGV[0, grdGV.RowCount -1];
            NapCT();

        }

        private void grdGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void comTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select Distinct " + comTruong.Text + " From GiangVien ";
            da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comGT.DataSource = dt;
            comGT.DisplayMember = comTruong.Text;
            comGT.ValueMember = comTruong.Text;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "Select TenGV, MaGV, MaKhoa, ChucVu, MatKhau  FROM GiangVien"+
                    " where " + comTruong.Text + "=N'" + comGT.Text + "'";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdGV.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý: " + ex.Message);
            }
            txtMakhoa.Visible = true;
            comMakhoa.Visible = false;
            txtMakhoa.Text = "";
        }
        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Naplai();
        }
        public void Naplai()
        {
            try
            {
                sql = "Select TenGV, MaGV, MaKhoa, ChucVu, MatKhau  FROM GiangVien";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdGV.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý: " + ex.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grdGV.CurrentCell = grdGV[0, grdGV.RowCount -1];
            NapCT();
            MessageBox.Show(" Bạn hãy nhập thông tin giảng viên mới và bấm cập nhật để hoàn tất ");
            txtMakhoa.Focus();
            addnewflag = true;
            txtMakhoa.Visible = false;
            comMakhoa.Visible = true;
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa hàng hóa này không?", "Hỏi xóa",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = " Delete from GiangVien where MaGV=N'" + txtMaGV.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                int i = grdGV.CurrentRow.Index;
                grdGV.Rows.RemoveAt(i);
                NapCT();
                MessageBox.Show("Đã xóa thành công");

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (addnewflag)
            {
                string maKhoa;
                if (txtMakhoa.Visible)
                {
                    maKhoa = txtMakhoa.Text;
                }
                else
                {
                    maKhoa = comMakhoa.SelectedItem?.ToString();
                }

                sql = "INSERT INTO GiangVien (TenGV, MaGV, MaKhoa, ChucVu, MatKhau) " +
                      "VALUES (N'" + txtHoten.Text + "', N'" + txtMaGV.Text + "', N'" + maKhoa + "', N'" + txtChucvu.Text + "', N'" + txtMatkhau.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật thành công");
                Naplai();
            }
            else
            {
                int n = grdGV.RowCount;
                for (int i = 0; i < n - 1; i++)
                {
                    string tHoten = grdGV.Rows[i].Cells["Hoten"].Value.ToString();
                    string tMaGV = grdGV.Rows[i].Cells["MaGV"].Value.ToString();
                    string tMakhoa = grdGV.Rows[i].Cells["Makhoa"].Value.ToString();
                    string tChucvu = grdGV.Rows[i].Cells["Chucvu"].Value.ToString();
                    string tMatkhau = grdGV.Rows[i].Cells["Matkhau"].Value.ToString();

                    sql = "UPDATE GiangVien SET TenGV = N'" + tHoten + "', Matkhau = N'" + tMatkhau + "', Makhoa = N'" + tMakhoa + "', Chucvu = N'" + tChucvu + "' WHERE MaGV = N'" + tMaGV + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Đã cập nhật thành công các sửa đổi");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hãy sửa thông tin giảng viên và bấm cập nhật để hoàn tất ");
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void qlGiangvien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{Tab}");//nút enter chuyển sang control kế tiếp

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void qlGiangvien_Load(object sender, EventArgs e)
        {
            str = "Data Source=DESKTOP-59GH4OI\\SQLEXPRESS;Initial Catalog=qltn_final2 (1);Integrated Security=True;Encrypt=False";
            conn.ConnectionString = str;
            conn.Open();
            sql = "Select TenGV, MaGV, MaKhoa, ChucVu, MatKhau  FROM GiangVien";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdGV.DataSource = dt;
            NapCT();
            grdGV.SelectionChanged += new EventHandler(grdGV_SelectionChanged);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            rptDSGiangvien rpt = new rptDSGiangvien();
            sql = "Select * FROM GiangVien"+ " where " + comTruong.Text + "=N'" + comGT.Text + "'";
            da = new SqlDataAdapter(sql, conn);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            rpt.DataSource = dt1;
            rpt.lblDKLoc.Text = "Điều kiện lọc: " + comTruong.Text + " = " + comGT.Text;
            rpt.lblNgayin.Text = string.Format("Hà Nội, ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            rpt.ShowPreview();
        }

        private void grdGV_SelectionChanged(object sender, EventArgs e)
        {
            if (grdGV.CurrentRow != null && grdGV.CurrentRow.Index >= 0)
            {
                NapCT();
            }
        }

    }
}
