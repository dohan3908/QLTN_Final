using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN_Final
{
    public partial class frmAdmin : Form

    {
        public frmAdmin()
        {
            InitializeComponent();
        }

     

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void kếtThúcChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void dữToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            status2.Text = System.DateTime.Now.ToString();
        }





        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void status2_Click(object sender, EventArgs e)
        {
            status2.Text = System.DateTime.Now.ToString();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quảnLýGiảngViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            qlGiangvien f = new qlGiangvien();
            f.ShowDialog();
        }

        private void quảnLýSinhViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            qlSinhvien f = new qlSinhvien();
            f.ShowDialog();
        }

        private void quảnLýHọcPhầnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            qlHP f = new qlHP();
            f.ShowDialog();
        }

        private void quảnLýCaThiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            qlCathi f = new qlCathi();
            f.ShowDialog();
        }

        private void saoLưuVàPhụcHồiDữLiệuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            status1.Text= "Đang sao lưu dữ liệu";
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlKhoa f = new qlKhoa();
            f.ShowDialog();
        }

        private void đăngNhậpHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ttAdmin f  = new ttAdmin();
            f.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            uảnLýNgườiDùngToolStripMenuItem.MouseDown += quảnLýNgườiDùngToolStripMenuItem_MouseDown;
            hệThốngToolStripMenuItem.MouseDown += hệThốngToolStripMenuItem_MouseDown;
            menuStrip1.MouseDown += MenuStrip1_MouseDown;
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void MenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Xác định vị trí chuột phải nằm trên mục nào
                ToolStripItem item = menuStrip1.GetItemAt(e.Location);
                if (item == hệThốngToolStripMenuItem)
                {
                    contextMenuStrip1.Show(menuStrip1, e.Location);
                }
                else if (item == uảnLýNgườiDùngToolStripMenuItem)
                {
                    contextMenuStrip2.Show(menuStrip1, e.Location);
                }
            }
        }
        private void hệThốngToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
   
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void uảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void quảnLýNgườiDùngToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { 
                contextMenuStrip2.Show(Cursor.Position);
            }
        }

    }
}
