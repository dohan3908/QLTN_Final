using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN_Final
{
    public partial class FrmDiemthi : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string str, sql;
        public FrmDiemthi()
        {
            InitializeComponent();
        }

        private void comTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comTruong.Text == "MaHP")
            {
                // Lấy tên học phần từ bảng HocPhan thông qua bảng CaThi
                sql = @"SELECT DISTINCT hp.TenHP, hp.MaHP 
            FROM CaThi ct 
            JOIN HocPhan hp ON ct.MaHP = hp.MaHP";

                da = new SqlDataAdapter(sql, conn);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);

                comGT.DataSource = dt1;
                comGT.DisplayMember = "TenHP";   // Hiển thị tên học phần
                comGT.ValueMember = "MaHP";      // Giá trị xử lý là mã học phần
            }
            else if (comTruong.Text == "MaCaThi")
            {
                // Lấy danh sách mã ca thi từ bảng CaThi
                sql = @"SELECT DISTINCT MaCaThi FROM CaThi";

                da = new SqlDataAdapter(sql, conn);
                DataTable dt2 = new DataTable();
                da.Fill(dt2);

                comGT.DataSource = dt2;
                comGT.DisplayMember = "MaCaThi";  // Hiển thị mã ca thi
                comGT.ValueMember = "MaCaThi";    // Giá trị xử lý là mã ca thi
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            grdDSDT.CurrentCell = grdDSDT[0, 0];
            NapCT();
        }

        public void NapCT()
        {
            if (grdDSDT.CurrentRow == null) return;
            int i = grdDSDT.CurrentRow.Index;
            txtCathi.Text = grdDSDT.Rows[i].Cells["MaCaThi"].Value.ToString();
            txtMaHP.Text = grdDSDT.Rows[i].Cells["MaHP"].Value.ToString();
            txtMaSV.Text = grdDSDT.Rows[i].Cells["MaSV"].Value.ToString();
            txtHoten.Text = grdDSDT.Rows[i].Cells["HoTen"].Value.ToString();
            txtDiemthi.Text = grdDSDT.Rows[i].Cells["DiemSo"].Value.ToString();
            txtTGBD.Text = grdDSDT.Rows[i].Cells["Thoigianbatdau"].Value.ToString();
            txtTGKT.Text = grdDSDT.Rows[i].Cells["Thoigianketthuc"].Value.ToString();
        }
        private void grdDSDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdDSDT.CurrentRow != null)
            {
                NapCT();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            grdDSDT.CurrentCell = grdDSDT[0, grdDSDT.RowCount - 2];
            NapCT();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int i = grdDSDT.CurrentRow.Index;
            if (i < grdDSDT.RowCount - 1)
            {   
                grdDSDT.CurrentCell = grdDSDT[0, i + 1];
                NapCT();
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            int i = grdDSDT.CurrentRow.Index;
            if (i > 0)
            {
                grdDSDT.CurrentCell = grdDSDT[0, i - 1];
                NapCT();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmGV f = new FrmGV();
            this.Hide();
            f.ShowDialog();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string truongLoc = comTruong.Text;
                string giaTriLoc = comGT.SelectedValue?.ToString() ?? comGT.Text.Trim();
                sql = @"
                SELECT 
                    dt.MaCaThi,         
                    ct.MaHP,  
                    ct.PhongThi,
                    dt.MaSV,           
                    sv.HoTen,           
                    dt.DiemSo,          
                    dt.Thoigianbatdau,  
                    dt.Thoigianketthuc  
                FROM 
                    DiemThi dt
                JOIN 
                    CaThi ct ON dt.MaCaThi = ct.MaCaThi
                JOIN 
                    SinhVien sv ON dt.MaSV = sv.MaSV
                WHERE 
                    " + (truongLoc == "MaHP" ? "ct.MaHP" : "dt.MaCaThi") + " = N'" + giaTriLoc + "'";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdDSDT.DataSource = dt;
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
                sql = @"
                    SELECT 
                        dt.MaCaThi,
                        ct.MaHP,
                        ct.PhongThi,
                        dt.MaSV,
                        sv.HoTen,
                        dt.DiemSo,
                        dt.Thoigianbatdau,
                        dt.Thoigianketthuc
                    FROM 
                        DiemThi dt
                    JOIN 
                        CaThi ct ON dt.MaCaThi = ct.MaCaThi
                    JOIN 
                            SinhVien sv ON dt.MaSV = sv.MaSV";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                // Kết nối DataTable với DataGridView
                grdDSDT.DataSource = dt;
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

        private void button1_Click(object sender, EventArgs e)
        {
            rptDSDT rpt = new rptDSDT();
            string sql =
          "SELECT dt.MaCaThi, ct.MaHP, ct.PhongThi, ct.PhongThi, dt.MaSV, sv.HoTen, " +
          "dt.DiemSo, dt.Thoigianbatdau, dt.Thoigianketthuc " +
          "FROM DiemThi dt " +
          "JOIN CaThi ct ON dt.MaCaThi = ct.MaCaThi " +
          "JOIN SinhVien sv ON dt.MaSV = sv.MaSV " +
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

        private void FrmDiemthi_Load(object sender, EventArgs e)
        {
            str = "Data Source=DESKTOP-MTLSMU4\\MSSQLSERVER2;Initial Catalog=qltn_final;Integrated Security=True;Encrypt=False";
            conn.ConnectionString = str;
            conn.Open();
            sql = @"
        SELECT 
            dt.MaCaThi,
            ct.MaHP,
            ct.PhongThi,   
            dt.MaSV,
            sv.Hoten,
            dt.DiemSo,
            dt.Thoigianbatdau,
            dt.Thoigianketthuc
        FROM 
            DiemThi dt
        JOIN 
            CaThi ct ON dt.MaCaThi = ct.MaCaThi
        JOIN 
            SinhVien sv ON dt.MaSV = sv.MaSV";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdDSDT.DataSource = dt;
         grdDSDT.CellClick += new DataGridViewCellEventHandler(grdDSDT_CellClick);
        }
    }
}
