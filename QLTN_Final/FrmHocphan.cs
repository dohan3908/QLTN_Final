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
    public partial class FrmHocphan : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string str, sql;
        public FrmHocphan()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmGV f = new FrmGV();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
        
        public void NapCT()
        {
            int i = grdDSHP.CurrentRow.Index;
            txtMaHP.Text = grdDSHP.Rows[i].Cells["MaHP"].Value.ToString();
            txtMaKhoa.Text = grdDSHP.Rows[i].Cells["MaKhoa"].Value.ToString();
            txtTenHP.Text = grdDSHP.Rows[i].Cells["TenHP"].Value.ToString();
        }
        private void grdDSHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdDSHP.CurrentRow != null)
            {
                NapCT();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            grdDSHP.CurrentCell = grdDSHP[0, 0];
            NapCT();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grdDSHP.CurrentCell = grdDSHP[0, grdDSHP.Rows.Count - 2];
            NapCT();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            NapCT();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int i = grdDSHP.CurrentRow.Index;
            if (i < grdDSHP.Rows.Count - 1)
            {
                grdDSHP.CurrentCell = grdDSHP[0, i + 1];
                NapCT();
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            int i = grdDSHP.CurrentRow.Index;
            if (i > 0)
            {
                grdDSHP.CurrentCell = grdDSHP[0, i - 1];
                NapCT();
            }
        }
        

        private void button4_Click(object sender, EventArgs e)
        { 
               try
            {
                string maKhoa = comKhoa.SelectedValue.ToString(); // Lấy mã khoa từ ComboBox

                sql = "SELECT MaHP, MaKhoa, TenHP FROM HocPhan WHERE MaKhoa = N'" + maKhoa + "'";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);

                grdDSHP.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý: " + ex.Message);
    }
        }


        private void comKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Naplai();

        }
        public void Naplai()
        {
            try
            {
                sql = "SELECT MaHP, MaKhoa, TenHP FROM HocPhan";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                // Kết nối DataTable với DataGridView
                grdDSHP.DataSource = dt;
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi cần xử lý:" + ex.Message);
            }
        }
        private void FrmHocphan_Load(object sender, EventArgs e)
        {

            // Thiết lập kết nối
            str = @"Data Source=DESKTOP-16RTLLC\HPELITEBOOK840G5;Initial Catalog=QLTN;Integrated Security=True;Encrypt=False";
            conn.ConnectionString = str;
            conn.Open();
            // Đổ dữ liệu vào DataGridView từ bảng HocPhan
            string sqlHP = "SELECT MaHP, MaKhoa, TenHP FROM HocPhan";
            SqlDataAdapter daHP = new SqlDataAdapter(sqlHP, conn);
            DataTable dtHP = new DataTable();
            daHP.Fill(dtHP);
            grdDSHP.DataSource = dtHP;

            // Đổ dữ liệu vào ComboBox từ bảng Khoa
            string sqlKhoa = "SELECT MaKhoa, TenKhoa FROM Khoa";
            SqlDataAdapter daKhoa = new SqlDataAdapter(sqlKhoa, conn);
            DataTable dtKhoa = new DataTable();
            daKhoa.Fill(dtKhoa);
            comKhoa.DataSource = dtKhoa;
            comKhoa.DisplayMember = "TenKhoa";
            comKhoa.ValueMember = "MaKhoa";


            NapCT();
            grdDSHP.CellClick += new DataGridViewCellEventHandler(grdDSHP_CellClick);



        }
    }
    }
