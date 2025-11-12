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
    public partial class frmSinhVien : Form
    {
        private string MaSV;
        private string MaCaThi;
        private DateTime thoiGianBatDau;
        private int thoiGianConLai = 40 * 60;
        private Timer timerThi = new Timer();

        public frmSinhVien(string MaSV, string MaCaThi)
        {
            InitializeComponent();
            this.MaSV = MaSV;
            this.MaCaThi = MaCaThi;
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-16RTLLC\HPELITEBOOK840G5;Initial Catalog=QLTN;Integrated Security=True;Encrypt=False");
        private List<CauHoi> danhSachCauHoi = new List<CauHoi>();
        private List<Button> danhSachButton = new List<Button>();
        private Dictionary<int, string> dapAnDaChon = new Dictionary<int, string>();

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // 1. Lấy thông tin sinh viên
                string querySV = "SELECT HoTen FROM SinhVien WHERE MaSV = @MaSV";
                SqlCommand cmdSV = new SqlCommand(querySV, conn);
                cmdSV.Parameters.AddWithValue("@MaSV", MaSV);
                SqlDataReader readerSV = cmdSV.ExecuteReader();
                if (readerSV.Read())
                {
                    txtMSV.Text = MaSV;
                    txtHoTen.Text = readerSV["HoTen"].ToString();
                }
                readerSV.Close();

                // 2. Lấy thông tin ca thi và học phần
                string queryCaThi = @"
            SELECT CaThi.MaCaThi, CaThi.MaHP, HocPhan.TenHP 
            FROM CaThi 
            JOIN HocPhan ON CaThi.MaHP = HocPhan.MaHP 
            WHERE CaThi.MaCaThi = @MaCaThi";
                SqlCommand cmdCaThi = new SqlCommand(queryCaThi, conn);
                cmdCaThi.Parameters.AddWithValue("@MaCaThi", MaCaThi);
                SqlDataReader readerCaThi = cmdCaThi.ExecuteReader();
                string maHP = "";
                if (readerCaThi.Read())
                {
                    txtCaThi.Text = readerCaThi["MaCaThi"].ToString();
                    txtHocPhan.Text = readerCaThi["TenHP"].ToString();
                    maHP = readerCaThi["MaHP"].ToString(); // lấy trực tiếp
                }
                readerCaThi.Close(); // đóng ngay sau khi đọc

                if (string.IsNullOrEmpty(maHP))
                {
                    MessageBox.Show("Không tìm thấy mã học phần.");
                    return;
                }

                string queryCauHoi = @"
                        SELECT TOP 30 * 
                        FROM ChiTietCauHoi 
                        WHERE MaHP = @MaHP 
                    ORDER BY NEWID()";

                SqlCommand cmdCauHoi = new SqlCommand(queryCauHoi, conn);
                cmdCauHoi.Parameters.AddWithValue("@MaHP", maHP);
                SqlDataReader readerCauHoi = cmdCauHoi.ExecuteReader();

                while (readerCauHoi.Read())
                {
                    CauHoi ch = new CauHoi
                    {
                        NoiDung = readerCauHoi["NoiDung"].ToString(),
                        DapAnA = readerCauHoi["DapAnA"].ToString(),
                        DapAnB = readerCauHoi["DapAnB"].ToString(),
                        DapAnC = readerCauHoi["DapAnC"].ToString(),
                        DapAnD = readerCauHoi["DapAnD"].ToString(),
                        DapAnDung = readerCauHoi["DapAnDung"].ToString()
                    };
                    danhSachCauHoi.Add(ch);
                }
                readerCauHoi.Close();
                // Giả sử bạn đã có 30 button tên là btnCau1 đến btnCau30
                for (int i = 1; i <= 30; i++)
                {
                    Button btn = this.Controls.Find("btnCau" + i, true).FirstOrDefault() as Button;
                    if (btn != null)
                    {
                        btn.Tag = i - 1;
                        btn.Click += btnCauHoi_Click;
                        danhSachButton.Add(btn);
                    }
                }

                // Hiển thị câu 1 khi bắt đầu
                if (danhSachButton.Count > 0)
                {
                    btnCauHoi_Click(danhSachButton[0], EventArgs.Empty);
                }


                // 3. Ngày thi
                var ngayThiTheoCa = new Dictionary<string, string>
{
    { "231C01", "25-11-2025" },
    { "231C02", "25-11-2025" },
    { "231C03", "25-11-2025" },
    { "231C04", "25-11-2025" },
    { "231C05", "25-11-2025" },
    { "231C06", "25-11-2025" },
    { "231C07", "25-11-2025" },
    { "231C08", "26-11-2025" },
    { "231C09", "26-11-2025" },
    { "231C10", "26-11-2025" },
    { "231C11", "26-11-2025" },
    { "231C12", "26-11-2025" }
};

                string ngayThi = ngayThiTheoCa.TryGetValue(MaCaThi, out var ngay) ? ngay : "Chưa xác định";
                txtNgayThi.Text = ngayThi;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            txtMSV.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtHocPhan.ReadOnly = true;
            txtCaThi.ReadOnly = true;

            // Gắn sự kiện đúng cách, chỉ một lần
            rdoOptionA.CheckedChanged += rdo_CheckedChanged;
            rdoOptionB.CheckedChanged += rdo_CheckedChanged;
            rdoOptionC.CheckedChanged += rdo_CheckedChanged;
            rdoOptionD.CheckedChanged += rdo_CheckedChanged;

            timerThi.Interval = 1000;
            timerThi.Tick += TimerThi_Tick;
            timerThi.Start();
        }
        private void btnCauHoi_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = (int)btn.Tag;
            if (index >= danhSachCauHoi.Count) return;

            CauHoi ch = danhSachCauHoi[index];

            txtCauHoiSo.Text = "Câu " + (index + 1).ToString(); // TextBox hiển thị số câu
            int viTriCham = ch.NoiDung.IndexOf('.');
            if (viTriCham >= 0 && viTriCham < ch.NoiDung.Length - 1)
            {
                txtNoiDungCauHoi.Text = ch.NoiDung.Substring(viTriCham + 1).Trim();
            }
            else
            {
                txtNoiDungCauHoi.Text = ch.NoiDung; // nếu không có dấu chấm thì hiển thị toàn bộ
            }
            // Reset trước
            rdoOptionA.Checked = false;
            rdoOptionB.Checked = false;
            rdoOptionC.Checked = false;
            rdoOptionD.Checked = false;

            // Gán nội dung
            rdoOptionA.Text = "A. " + ch.DapAnA;
            rdoOptionB.Text = "B. " + ch.DapAnB;
            rdoOptionC.Text = "C. " + ch.DapAnC;
            rdoOptionD.Text = "D. " + ch.DapAnD;


            rdoOptionC.Visible = !string.IsNullOrWhiteSpace(ch.DapAnC);
            rdoOptionD.Visible = !string.IsNullOrWhiteSpace(ch.DapAnD);

            if (dapAnDaChon.ContainsKey(index))
            {
                string da = dapAnDaChon[index];
                if (da == "A") rdoOptionA.Checked = true;
                else if (da == "B") rdoOptionB.Checked = true;
                else if (da == "C") rdoOptionC.Checked = true;
                else if (da == "D") rdoOptionD.Checked = true;
            }
        }
        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;
            if (rdo == null || !rdo.Checked) return;

            int index = int.Parse(txtCauHoiSo.Text.Replace("Câu ", "")) - 1;

            string dapAn = "";
            if (rdo == rdoOptionA) dapAn = "A";
            else if (rdo == rdoOptionB) dapAn = "B";
            else if (rdo == rdoOptionC) dapAn = "C";
            else if (rdo == rdoOptionD) dapAn = "D";

            dapAnDaChon[index] = dapAn;

            if (index >= 0 && index < danhSachButton.Count)
            {
                danhSachButton[index].BackColor = Color.LightGreen;
            }

            lblSoCauDaLam.Text = $"{dapAnDaChon.Count}/{danhSachCauHoi.Count}";
        }
        private void TimerThi_Tick(object sender, EventArgs e)
        {
            thoiGianConLai--;

            int phut = thoiGianConLai / 60;
            int giay = thoiGianConLai % 60;

            lblThoiGianConLai.Text = $"{phut:D2}:{giay:D2}";

            if (thoiGianConLai <= 0)
            {
                timerThi.Stop();
                MessageBox.Show("Hết giờ! Bài thi sẽ được nộp.");
                TinhDiemVaHienKetQua();
            }
        }

        private void TinhDiemVaHienKetQua()
        {
            int soCauDung = 0;

            for (int i = 0; i < danhSachCauHoi.Count; i++)
            {
                if (dapAnDaChon.ContainsKey(i))
                {
                    string daChon = dapAnDaChon[i];
                    string noiDungDaChon = "";

                    switch (daChon)
                    {
                        case "A":
                            noiDungDaChon = danhSachCauHoi[i].DapAnA;
                            break;
                        case "B":
                            noiDungDaChon = danhSachCauHoi[i].DapAnB;
                            break;
                        case "C":
                            noiDungDaChon = danhSachCauHoi[i].DapAnC;
                            break;
                        case "D":
                            noiDungDaChon = danhSachCauHoi[i].DapAnD;
                            break;
                    }

                    string dapAnDung = danhSachCauHoi[i].DapAnDung;

                    if (!string.IsNullOrWhiteSpace(noiDungDaChon) &&
                        noiDungDaChon.Trim().Equals(dapAnDung.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        soCauDung++;
                    }
                }
            }
            if (dapAnDaChon.Count < danhSachCauHoi.Count)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn chưa làm hết tất cả các câu. Bạn có chắc chắn muốn nộp bài?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;
            }

            KetQuaThi ketQua = new KetQuaThi(MaSV, MaCaThi, thoiGianBatDau, soCauDung);
            ketQua.Show();
            this.Hide();
        }

        private void btnNopBai_Click(object sender, EventArgs e)
        {
            timerThi.Stop(); // dừng đếm ngược nếu còn
            TinhDiemVaHienKetQua();
        }

        private void txtMSV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


