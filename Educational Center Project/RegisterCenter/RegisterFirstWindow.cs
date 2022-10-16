using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Educational_Center_Project.RegisterCenter
{
    public partial class RegisterFirstWindow : Form
    {
        public RegisterFirstWindow()
        {
            InitializeComponent();
        }

        private void RegisterFirstWindow_Load(object sender, EventArgs e)
        {

        }

        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.White;
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                symbol_pc.Image = Image.FromFile(openFileDialog.FileName);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            symbol_pc.Image.Save(ms, symbol_pc.Image.RawFormat);
            byte[] img = ms.ToArray();
        }
    }
}
