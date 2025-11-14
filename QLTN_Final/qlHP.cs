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
    public partial class qlHP : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string str, sql;
        Boolean addnewflag = false;
        public qlHP()
        {
            InitializeComponent();
        }
        public void NapCT()
        {
            int i = grdHP.CurrentRow.Index;
            txtTenHP.Text= grdHP.Rows[i].Cells["TenHP"].Value.ToString();
            txtMaHP.Text= grdHP.Rows[i].Cells["MaHP"].Value.ToString();
            txtMakhoa.Text= grdHP.Rows[i].Cells["Makhoa"].Value.ToString();



        }
        private void lblHoten_Click(object sender, EventArgs e)
        {
          
        }

        private void qlHP_Load(object sender, EventArgs e)
        {
            str = "Data Source=DESKTOP-59GH4OI\\SQLEXPRESS;Initial Catalog=qltn_final2 (1);Integrated Security=True;Encrypt=False";
            conn.ConnectionString = str;
            conn.Open();
            sql = "Select TenHP, MaHP, MaKhoa  FROM HocPhan";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdHP.DataSource = dt;
            NapCT();
            grdHP.SelectionChanged += new EventHandler(grdHP_SelectionChanged);
        }
        private void grdHP_SelectionChanged(object sender, EventArgs e)
        {
            if (grdHP.CurrentRow != null && grdHP.CurrentRow.Index >= 0)
            {
                NapCT();
            }
        }
        private void grdHP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            grdHP.ClearSelection();
            grdHP.CurrentCell = grdHP[0, 0];
            NapCT();
        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
             int i = Convert.ToInt16(grdHP.CurrentRow.Index.ToString());
            if (i>0)
            {
                grdHP.CurrentCell = grdHP[0, i - 1];
                NapCT();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(grdHP.CurrentRow.Index.ToString());
            if (i < grdHP.RowCount-1)
            {
                grdHP.CurrentCell = grdHP[0, i + 1];
                NapCT();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int i = grdHP.RowCount -1;
            grdHP.CurrentCell = grdHP[0, grdHP.RowCount -1];
            NapCT();
        }

        private void comTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select Distinct " + comTruong.Text + " From HocPhan";
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
                sql = "Select  TenHP, MaHP, MaKhoa  FROM HocPhan"+
                    " where " + comTruong.Text + "=N'" + comGT.Text + "'";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdHP.DataSource = dt;
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
                sql = "Select  TenHP, MaHP, MaKhoa  FROM HocPhan";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdHP.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý: " + ex.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grdHP.CurrentCell = grdHP[0, grdHP.RowCount -1];
            NapCT();
            MessageBox.Show(" Bạn hãy nhập thông tin học phần mới và bấm cập nhật để hoàn tất ");
            txtMakhoa.Focus();
            addnewflag = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hãy sửa thông tin học phần và bấm cập nhật để hoàn tất ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa hàng hóa này không?", "Hỏi xóa",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = " Delete from HocPhan where MaHP=N'" + txtMaHP.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                int i = grdHP.CurrentRow.Index;
                grdHP.Rows.RemoveAt(i);
                NapCT();
                MessageBox.Show("Đã xóa thành công");

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (addnewflag)
            {

                sql = " insert into HocPhan (TenHP, MaHP, MaKhoa) " + "values (N'"+ txtTenHP.Text + "', N'"+ txtMaHP.Text + "', N'"+ txtMakhoa.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật thành công");
                Naplai();
            }

            else
            {
                int n = grdHP.RowCount;
                for (int i = 0; i<n-1; i++)
                {
                    string tTenHp = grdHP.Rows[i].Cells["TenHP"].Value.ToString();
                    string tMaHP = grdHP.Rows[i].Cells["MaHP"].Value.ToString();
                    string tMakhoa = grdHP.Rows[i].Cells["Makhoa"].Value.ToString();

                    sql = "update HocPhan set TenHP = N'" + tTenHp + "', Makhoa = " + tMakhoa + " where MaHP = N'" + tMaHP + "'";
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

        
    }
}
