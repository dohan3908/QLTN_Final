using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLTN_Final
{
    public partial class FrmGV : Form
    {
        public FrmGV()
        {
            InitializeComponent();
        }

        private void kinhTếChínhTrịMácToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmGV_Load(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void cÂUHỎIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = System.DateTime.Now.ToString();

        }

       

        private void bÁOCÁOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDiemthi f = new FrmDiemthi();
            this.Hide();
            f.ShowDialog();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void hỌCPHẦNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHocphan f = new FrmHocphan();
            this.Hide();
            f.ShowDialog();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTTTK f = new FrmTTTK();
            this.Hide();
            f.ShowDialog();
        }

        private void danhSáchCâuHỏiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCauhoi f = new FrmCauhoi();
            this.Hide();
            f.ShowDialog();
        }

        private void thêmCâuHỏiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhapcauhoi f = new FrmNhapcauhoi();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
