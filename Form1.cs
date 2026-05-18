using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        bool thoatBangNut = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;

            dr = MessageBox.Show(
                "Bạn có thực sự muốn thoát không?",
                "Thông báo",
                MessageBoxButtons.YesNo
            );

            if (dr == DialogResult.Yes)
            {
                thoatBangNut = true;
                this.Close();
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            double so1, so2, kq = 0;
            so1 = double.Parse(txtSo1.Text);
            so2 = double.Parse(txtSo2.Text);

            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked)
            {
                if (so2 == 0)
                {
                    MessageBox.Show("Không thể chia cho 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                kq = so1 / so2;
            }

            txtKq.Text = kq.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thoatBangNut) return;

            DialogResult dr;

            dr = MessageBox.Show(
                "Bạn có muốn thoát không?",
                "Thông báo"
            );
        }

        private void txtSo_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtSo_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.SelectionLength == 0)
            {
                textBox.SelectAll();
            }
        }
    }
}
