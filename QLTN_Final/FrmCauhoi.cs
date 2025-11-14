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
    public partial class FrmCauhoi : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string str, sql;
        public FrmCauhoi()
        {
            InitializeComponent();
        }
       


        private void cÂUHỎIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGV f = new FrmGV();
            this.Hide();
            f.ShowDialog();
        }

        private void lable1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comTruong.Text == "MaHP")
            {
                sql = "SELECT DISTINCT hp.TenHP, hp.MaHP FROM ChiTietCauHoi ct JOIN HocPhan hp ON ct.MaHP = hp.MaHP";
                da = new SqlDataAdapter(sql, conn);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                comGT.DataSource = dt1;
                comGT.DisplayMember = "TenHP";  // Hiển thị tên học phần
                comGT.ValueMember = "MaHP";     // Giá trị xử lý là mã học phần
            }
            else if (comTruong.Text == "MaGV")
            {
                sql = "SELECT DISTINCT gv.TenGV, gv.MaGV FROM ChiTietCauHoi ct JOIN GiangVien gv ON ct.MaGV = gv.MaGV";
                da = new SqlDataAdapter(sql, conn);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                comGT.DataSource = dt1;
                comGT.DisplayMember = "TenGV";  // Hiển thị tên giảng viên
                comGT.ValueMember = "MaGV";     // Giá trị xử lý là mã giảng viên
            }
            else
            {
                sql = "SELECT DISTINCT " + comTruong.Text + " FROM ChiTietCauHoi";
                da = new SqlDataAdapter(sql, conn);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                comGT.DataSource = dt1;
                comGT.DisplayMember = comTruong.Text;
                comGT.ValueMember = comTruong.Text;
            }

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            grdDSCH.CurrentCell = grdDSCH[0, 0];
            NapCT();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            FrmNhapcauhoi f = new FrmNhapcauhoi();
            this.Hide();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void NapCT()
        {
            if (grdDSCH.CurrentRow == null) return;
            int i = grdDSCH.CurrentRow.Index;
            txtMaCauHoi.Text = grdDSCH.Rows[i].Cells["MaCauHoi"].Value.ToString();
            txtNoiDung.Text = grdDSCH.Rows[i].Cells["NoiDung"].Value.ToString();
            txtA.Text = grdDSCH.Rows[i].Cells["DapAnA"].Value.ToString();
            txtB.Text = grdDSCH.Rows[i].Cells["DapAnB"].Value.ToString();
            txtC.Text = grdDSCH.Rows[i].Cells["DapAnC"].Value.ToString();
            txtD.Text = grdDSCH.Rows[i].Cells["DapAnD"].Value.ToString();
            txtDung.Text = grdDSCH.Rows[i].Cells["DapAnDung"].Value.ToString();

        }
        private void grdDSCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdDSCH.CurrentRow != null)
            {
                NapCT();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FrmNhapcauhoi f = new FrmNhapcauhoi();
            this.Hide();
            f.ShowDialog();

        }

        private void button12_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Hãy sửa thông tin câu hỏi sau đó ấn cập nhập để hoàn tất");
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "delete from ChiTietCauHoi where MaCauHoi = N'" + txtMaCauHoi.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                // Xóa dòng hiện hành trên DataGridView
                int i = grdDSCH.CurrentRow.Index; // Lấy chỉ số dòng hiện hành
                grdDSCH.Rows.RemoveAt(i);
                NapCT();
                MessageBox.Show("Đã xóa thành công");
                // Nếu có code này thì không cần gọi hàm nạp lại
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int n = grdDSCH.RowCount;
            for (int i = 0; i < n - 1; i++)
            {

               
                string tMaCauHoi = grdDSCH.Rows[i].Cells["MaCauHoi"].Value.ToString();
                string tMaHP = grdDSCH.Rows[i].Cells["MaHP"].Value.ToString();
                string tMaGV = grdDSCH.Rows[i].Cells["MaGV"].Value.ToString();
                string tNoiDung = grdDSCH.Rows[i].Cells["NoiDung"].Value.ToString();
                string tDapAnA = grdDSCH.Rows[i].Cells["DapAnA"].Value.ToString();
                string tDapAnB = grdDSCH.Rows[i].Cells["DapAnB"].Value.ToString();
                string tDapAnC = grdDSCH.Rows[i].Cells["DapAnC"].Value.ToString();
                string tDapAnD = grdDSCH.Rows[i].Cells["DapAnD"].Value.ToString();
                string tDapAnDung = grdDSCH.Rows[i].Cells["DapAnDung"].Value.ToString();
                string tLoaiCauHoi = grdDSCH.Rows[i].Cells["LoaiCauHoi"].Value.ToString();
                string tMucDo = grdDSCH.Rows[i].Cells["MucDo"].Value.ToString();
                sql = "update ChiTietCauHoi set MaHP=N'" + tMaHP + "', MaGV=N'" + tMaGV + "', NoiDung=N'" + tNoiDung + "', DapAnA=N'" + tDapAnA + "', DapAnB=N'" + tDapAnB + "', DapAnC=N'" + tDapAnC + "', DapAnD=N'" + tDapAnD + "', DapAnDung=N'" + tDapAnDung + "', LoaiCauHoi=N'" + tLoaiCauHoi + "', MucDo=N'" + tMucDo + "' where MaCauHoi=N'" + tMaCauHoi + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Đã cập nhập thành công trên ô lưới!");

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            grdDSCH.CurrentCell = grdDSCH[0, grdDSCH.RowCount - 2];
            NapCT();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int i = grdDSCH.CurrentRow.Index;
            if (i < grdDSCH.RowCount - 1)
            {
                grdDSCH.CurrentCell = grdDSCH[0, i + 1];
                NapCT();
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            int i = grdDSCH.CurrentRow.Index;
            if (i > 0)
            {
                grdDSCH.CurrentCell = grdDSCH[0, i - 1];
                NapCT();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tên trường cần lọc (MaHP, MaGV, LoaiCauHoi, MucDo)
                string truongLoc = comTruong.Text;

                // Lấy giá trị cần lọc (mã hoặc nội dung tương ứng)
                string giaTriLoc = comGT.SelectedValue?.ToString() ?? comGT.Text.Trim();

                sql = "SELECT MaCauHoi, MaHP, MaGV, NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung, LoaiCauHoi, MucDo " +
                      "FROM ChiTietCauHoi " +
                      "WHERE " + truongLoc + " = N'" + giaTriLoc + "'";

                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdDSCH.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý: " + ex.Message);
            }

        }

        public void Naplai()
        {
            try
            {
                sql = "Select MaCauHoi, MaHP, MaGV, NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung, LoaiCauHoi, MucDo from ChiTietCauHoi ";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                // Kết nối DataTable với DataGridView
                grdDSCH.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý:" + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Naplai();
        }

        

        private void FrmCauhoi_Load(object sender, EventArgs e)
        {
            str = "Data Source=DESKTOP-MTLSMU4\\MSSQLSERVER2;Initial Catalog=qltn_final2;Integrated Security=True;Encrypt=False";
            conn.ConnectionString = str;
            conn.Open();
            // Đổ dữ liệu vào DataGridView
            sql = "Select MaCauHoi, MaHP, MaGV, NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung, LoaiCauHoi, MucDo from ChiTietCauHoi ";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            // Kết nối DataTable với DataGridView
            grdDSCH.DataSource = dt;
            NapCT();
            grdDSCH.CellClick += new DataGridViewCellEventHandler(grdDSCH_CellClick);
       }

        private void btnInbaocao_Click(object sender, EventArgs e)
        {
            rptDSCH rpt = new rptDSCH();
            string sql = "SELECT ct.MaCauHoi, ct.MaHP, hp.TenHP, ct.MaGV, gv.TenGV, " +
              "ct.NoiDung, ct.DapAnA, ct.DapAnB, ct.DapAnC, ct.DapAnD, " +
              "ct.DapAnDung, ct.LoaiCauHoi, ct.MucDo " +
              "FROM ChiTietCauHoi ct " +
              "JOIN HocPhan hp ON ct.MaHP = hp.MaHP " +
              "JOIN GiangVien gv ON ct.MaGV = gv.MaGV " +
              "WHERE ct." + comTruong.Text + " = N'" + comGT.SelectedValue.ToString() + "'";
            da = new SqlDataAdapter(sql, conn);
                 DataTable rdt = new DataTable();
                 da.Fill(rdt);
            rpt.lblDkloc.Text = "Điều kiện lọc: " + comGT.Text;
            rpt.rptNgayin.Text = string.Format("Hà Nội, ngày {0} tháng {1} năm {2}",
                DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
                 rpt.DataSource = rdt;
                rpt.ShowPreview();
        }

        private void FrmGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }

}
