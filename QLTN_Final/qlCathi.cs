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
    public partial class qlCathi : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string str, sql;
        Boolean addnewflag = false;
        public qlCathi()
        {
            InitializeComponent();
        }
        public void NapCT()
        {
            int i = grdCathi.CurrentRow.Index;
            txtMaCathi.Text= grdCathi.Rows[i].Cells["MaCathi"].Value.ToString();
            txtMaHP.Text= grdCathi.Rows[i].Cells["MaHP"].Value.ToString();
            txtPhongthi.Text= grdCathi.Rows[i].Cells["Phongthi"].Value.ToString();
            dtpStart.Text= grdCathi.Rows[i].Cells["tgStart"].Value.ToString();
            dtpEnd.Text= grdCathi.Rows[i].Cells["tgEnd"].Value.ToString();

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void qlCathi_Load(object sender, EventArgs e)
        {
            str = "Data Source=DESKTOP-59GH4OI\\SQLEXPRESS;Initial Catalog=qltn_final2 (1);Integrated Security=True;Encrypt=False";
            conn.ConnectionString = str;
            conn.Open();
            sql = "Select MaCaThi, MaHP, PhongThi,ThoiGianBatDau, ThoiGianKetThuc  FROM CaThi";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdCathi.DataSource = dt;
            NapCT();
            grdCathi.SelectionChanged += new EventHandler(grdCathi_SelectionChanged);

        }
        private void grdCathi_SelectionChanged(object sender, EventArgs e)
{
    if (grdCathi.CurrentRow != null && grdCathi.CurrentRow.Index >= 0)
    {
        NapCT();
    }
}

        private void grdCathi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();    
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            grdCathi.ClearSelection();
            grdCathi.CurrentCell = grdCathi[0, 0];
            NapCT();
        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(grdCathi.CurrentRow.Index.ToString());
            if (i>0)
            {
                grdCathi.CurrentCell = grdCathi[0, i - 1];
                NapCT();
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(grdCathi.CurrentRow.Index.ToString());
            if (i < grdCathi.RowCount-1)
            {
                grdCathi.CurrentCell = grdCathi[0, i + 1];
                NapCT();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int i = grdCathi.RowCount -1;
            grdCathi.CurrentCell = grdCathi[0, grdCathi.RowCount -1];
            NapCT();
        }

        private void comTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select Distinct " + comTruong.Text + " From CaThi ";
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
                sql = "Select  MaCaThi, MaHP, PhongThi,ThoiGianBatDau, ThoiGianKetThuc  FROM CaThi"+
                    " where " + comTruong.Text + "=N'" + comGT.Text + "'";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdCathi.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý: " + ex.Message);
            }
            txtMaHP.Visible = true;
            comMaHP.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Naplai();   
        }
        public void Naplai()
        {
            try
            {
                sql = "Select MaCaThi, MaHP, PhongThi,ThoiGianBatDau, ThoiGianKetThuc  FROM CaThi";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdCathi.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý: " + ex.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grdCathi.CurrentCell = grdCathi[0, grdCathi.RowCount -1];
            NapCT();
            MessageBox.Show(" Bạn hãy nhập thông tin ca thi mới và bấm cập nhật để hoàn tất ");
            txtMaHP.Focus();
            addnewflag = true;
            txtMaHP.Visible = false;
            comMaHP.Visible = true;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hãy sửa thông tin Ca thi và bấm cập nhật để hoàn tất ");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa hàng hóa này không?", "Hỏi xóa",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = " Delete from CaThi where MaCaThi=N'" + txtMaCathi.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                int i = grdCathi.CurrentRow.Index;
                grdCathi.Rows.RemoveAt(i);
                NapCT();
                MessageBox.Show("Đã xóa thành công");

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (addnewflag)
            {
               
                string maHP ;
                if (txtMaHP.Visible)
                {
                    maHP = txtMaHP.Text;
                }
                else
                {
                    maHP = comMaHP.SelectedItem?.ToString();
                }

                sql = "INSERT INTO CaThi (MaCaThi, MaHP, PhongThi, ThoiGianBatDau, ThoiGianKetThuc) " +
                      "VALUES (N'" + txtMaCathi.Text + "', N'" + maHP + "', N'" + txtPhongthi.Text + "', N'" + dtpStart.Text + "', N'" + dtpEnd.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật thành công");
                Naplai();
            }
            else
            {
                int n = grdCathi.RowCount;
                for (int i = 0; i < n - 1; i++)
                {
                    string tMaCathi = grdCathi.Rows[i].Cells["MaCathi"].Value.ToString();
                    string tMaHP = grdCathi.Rows[i].Cells["MaHP"].Value.ToString();
                    string tPhongthi = grdCathi.Rows[i].Cells["Phongthi"].Value.ToString();
                    string tStart = grdCathi.Rows[i].Cells["tgStart"].Value.ToString();
                    string tEnd = grdCathi.Rows[i].Cells["tgEnd"].Value.ToString();

                    sql = "UPDATE CaThi SET MaHP = N'" + tMaHP + "', PhongThi = N'" + tPhongthi + "', ThoiGianBatDau = N'" + tStart + "', ThoiGianKetThuc = N'" + tEnd + "' WHERE MaCaThi = N'" + tMaCathi + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Đã cập nhật thành công các sửa đổi");
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
