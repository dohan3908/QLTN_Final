using DevExpress.XtraReports.UI;
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
    public partial class qlSinhvien : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string str, sql;
        Boolean addnewflag = false;
        public qlSinhvien()
        {
            InitializeComponent();
        }
        public void NapCT()
        {
            int i = grdSV.CurrentRow.Index;
            txtHoten.Text= grdSV.Rows[i].Cells["Hoten"].Value.ToString();
            txtMaSV.Text= grdSV.Rows[i].Cells["MaSV"].Value.ToString();
            txtLopcn.Text= grdSV.Rows[i].Cells["Lopcn"].Value.ToString();
            txtMatkhau.Text= grdSV.Rows[i].Cells["Matkhau"].Value.ToString();


        }
        

        private void qlSinhvien_Load(object sender, EventArgs e)
        {
            str = "Data Source=DESKTOP-59GH4OI\\SQLEXPRESS;Initial Catalog=qltn_final2 (1);Integrated Security=True;Encrypt=False";
            conn.ConnectionString = str;
            conn.Open();
            sql = "Select HoTen,MaSV, LopChuyenNganh, MatKhau  FROM SinhVien";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdSV.DataSource = dt;
            NapCT();
            grdSV.SelectionChanged += new EventHandler(grdSV_SelectionChanged);

        }
        private void grdSV_SelectionChanged(object sender, EventArgs e)
        {
            if (grdSV.CurrentRow != null && grdSV.CurrentRow.Index >= 0)
            {
                NapCT();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void grdSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            grdSV.ClearSelection();
            grdSV.CurrentCell = grdSV[0, 0];
            NapCT();
        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(grdSV.CurrentRow.Index.ToString());
            if (i>0)
            {
                grdSV.CurrentCell = grdSV[0, i - 1];
                NapCT();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(grdSV.CurrentRow.Index.ToString());
            if (i < grdSV.RowCount-1)
            {
                grdSV.CurrentCell = grdSV[0, i + 1];
                NapCT();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int i = grdSV.RowCount -1;
            grdSV.CurrentCell = grdSV[0, grdSV.RowCount -1];
            NapCT();
        }

        private void comTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select Distinct " + comTruong.Text + " From SinhVien ";
            da = new SqlDataAdapter(sql, conn);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            comGT.DataSource = dt1;
            comGT.DisplayMember = comTruong.Text;
            comGT.ValueMember = comTruong.Text;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "Select  HoTen,MaSV, LopChuyenNganh, MatKhau  FROM SinhVien"+
                    " where " + comTruong.Text + "=N'" + comGT.Text + "'";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdSV.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Naplai();   
        }
        public void Naplai()
        {
            try
            {
                sql = "Select HoTen,MaSV, LopChuyenNganh, MatKhau  FROM SinhVien";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdSV.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý: " + ex.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grdSV.CurrentCell = grdSV[0, grdSV.RowCount -1];
            NapCT();
            MessageBox.Show(" Bạn hãy nhập thông tin sinh viên mới và bấm cập nhật để hoàn tất ");
            txtLopcn.Focus();
            addnewflag = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hãy sửa thông tin sinh viên và bấm cập nhật để hoàn tất ");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa hàng hóa này không?", "Hỏi xóa",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = " Delete from SinhVien where MaSV=N'" + txtMaSV.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                int i = grdSV.CurrentRow.Index;
                grdSV.Rows.RemoveAt(i);
                NapCT();
                MessageBox.Show("Đã xóa thành công");

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (addnewflag)
            {

                sql = " insert into SinhVien (HoTen,MaSV, LopChuyenNganh, MatKhau) " + "values (N'"+ txtHoten.Text + "', N'"+ txtMaSV.Text + "', N'"+ txtLopcn.Text + "', N'"+ txtMatkhau.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật thành công");
                Naplai();
            }

            else
            {
                int n = grdSV.RowCount;
                for (int i = 0; i<n-1; i++)
                {
                    string tHoten = grdSV.Rows[i].Cells["Hoten"].Value.ToString();
                    string tMaSV = grdSV.Rows[i].Cells["MaSV"].Value.ToString();
                    string tLopcn = grdSV.Rows[i].Cells["Lopcn"].Value.ToString();
                    string tMatkhau = grdSV.Rows[i].Cells["Matkhau"].Value.ToString();
                    sql = "update SinhVien set HoTen = N'" + tHoten + "', Matkhau = N'" + tMatkhau + "', Lopcn = " + tLopcn + " where MaSV = N'" + tMaSV + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Đã cập nhật thành công các sửa đổi ");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            rptDSSinhvien rpt = new rptDSSinhvien();
            sql = "Select * FROM SinhVien"+ " where " + comTruong.Text + "=N'" + comGT.Text + "'";
            da = new SqlDataAdapter(sql, conn);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            rpt.DataSource = dt1;
            rpt.lblDKLoc.Text = "Điều kiện lọc: " + comTruong.Text + " = " + comGT.Text;
            rpt.lblNgayin.Text = string.Format("Hà Nội, ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            rpt.ShowPreview();
        }

        private void status2_Click(object sender, EventArgs e)
        {

        }
    }
}
