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
    public partial class qlKhoa : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string str, sql;
        Boolean addnewflag = false;
        public qlKhoa()
        {
            InitializeComponent();
        }
        public void NapCT()
        {
            int i = grdKhoa.CurrentRow.Index;
            txtTenKhoa.Text= grdKhoa.Rows[i].Cells["TenKhoa"].Value.ToString();
            txtMaKhoa.Text= grdKhoa.Rows[i].Cells["MaKhoa"].Value.ToString();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void qlKhoa_Load(object sender, EventArgs e)
        {
            str = "Data Source=DESKTOP-59GH4OI\\SQLEXPRESS;Initial Catalog=qltn_final2 (1)" +
                ";Integrated Security=True;Encrypt=False";
            conn.ConnectionString = str;
            conn.Open();
            sql = "Select TenKhoa, MaKhoa  FROM Khoa";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdKhoa.DataSource = dt;
            NapCT();
            grdKhoa.SelectionChanged += new EventHandler(grdKhoa_SelectionChanged);
        }
        private void grdKhoa_SelectionChanged(object sender, EventArgs e)
        {
            if (grdKhoa.CurrentRow != null && grdKhoa.CurrentRow.Index >= 0)
            {
                NapCT();
            }
        }
        

        private void grdKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            grdKhoa.ClearSelection();
            grdKhoa.CurrentCell = grdKhoa[0, 0];
            NapCT();
        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(grdKhoa.CurrentRow.Index.ToString());
            if (i>0)
            {
                grdKhoa.CurrentCell = grdKhoa[0, i - 1];
                NapCT();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(grdKhoa.CurrentRow.Index.ToString());
            if (i < grdKhoa.RowCount-1)
            {
                grdKhoa.CurrentCell = grdKhoa[0, i + 1];
                NapCT();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int i = grdKhoa.RowCount -1;
            grdKhoa.CurrentCell = grdKhoa[0, grdKhoa.RowCount -1];
            NapCT();
        }

        private void comTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select Distinct " + comTruong.Text + " From Khoa ";
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
                sql = "Select  TenKhoa, MaKhoa  FROM Khoa"+
                    " where " + comTruong.Text + "=N'" + comGT.Text + "'";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdKhoa.DataSource = dt;
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
                sql = "Select TenKhoa, MaKhoa  FROM Khoa";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdKhoa.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý: " + ex.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grdKhoa.CurrentCell = grdKhoa[0, grdKhoa.RowCount -1];
            NapCT();
            MessageBox.Show(" Bạn hãy nhập thông tin khoa và bấm cập nhật để hoàn tất ");
            txtMaKhoa.Focus();
            addnewflag = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hãy sửa thông tin khoa và bấm cập nhật để hoàn tất ");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa hàng hóa này không?", "Hỏi xóa",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = " Delete from Khoa where MaKhoa=N'" + txtMaKhoa.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                int i = grdKhoa.CurrentRow.Index;
                grdKhoa.Rows.RemoveAt(i);
                NapCT();
                MessageBox.Show("Đã xóa thành công");

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (addnewflag)
            {

                sql = " insert into Khoa (TenKhoa, MaKhoa  ) " + "values (N'"+ txtTenKhoa.Text + "', N'"+ txtMaKhoa.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật thành công");
                Naplai();
            }

            else
            {
                int n = grdKhoa.RowCount;
                for (int i = 0; i<n-1; i++)
                {
                    string tTenKhoa = grdKhoa.Rows[i].Cells["TenKhoa"].Value.ToString();
                    string tMaKhoa = grdKhoa.Rows[i].Cells["MaKhoa"].Value.ToString();

                    sql = "update Khoa set  TenKhoa = N'" + tTenKhoa + "' where MaKhoa = N'" + tMaKhoa + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                Naplai();
                MessageBox.Show("Đã cập nhật thành công các sửa đổi ");
                
         
           }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblHoten_Click(object sender, EventArgs e)
        {

        }
    }
}
