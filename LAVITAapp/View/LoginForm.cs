using LAVITAapp.Data;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAVITAapp.View
{
    public partial class LoginForm : Form
    {
        private bool isPassVisible = false;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\LibraryManager");

            if (key != null)
            {
                var remember = key.GetValue("tsRemember");
                if (remember != null && remember.ToString() == "True")
                {
                    tsRemember.Checked = true;
                    // Không gán username/password, chờ user nhập để gợi ý
                }
            }

            // Ẩn mật khẩu mặc định
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.IconRight = Properties.Resources.icons8_show_password_32;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool remember = tsRemember.Checked;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            using (var db = new AppDbContext())
            {
                var user = db.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == username && tk.MatKhau == password);

                if (user != null)
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\LibraryManager");

                    if (remember)
                    {
                        var savedPassword = key.GetValue("Password")?.ToString();
                        bool isFirstTimeRemember = string.IsNullOrEmpty(savedPassword);

                        key.SetValue("Username", username);
                        key.SetValue("Password", password);
                        key.SetValue("tsRemember", true);

                        if (isFirstTimeRemember)
                        {
                            MessageBox.Show("Đã ghi nhớ tài khoản và mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        key.DeleteValue("Username", false);
                        key.DeleteValue("Password", false);
                        key.SetValue("tsRemember", false);
                    }

                    key.Close();

                    //Mở MainForm
                    MainForm mainForm = new MainForm(user);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (!tsRemember.Checked) return;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\LibraryManager");

            if (key != null)
            {
                string savedUser = key.GetValue("Username")?.ToString();
                string savedPass = key.GetValue("Password")?.ToString();
                string inputUser = txtUsername.Text.Trim();

                if (inputUser == savedUser && !string.IsNullOrEmpty(savedPass))
                {
                    DialogResult result = MessageBox.Show("Tự động điền mật khẩu đã lưu cho tài khoản này?", "Gợi ý đăng nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        txtPassword.Text = savedPass;
                    }
                }

            }
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            isPassVisible = !isPassVisible;
            txtPassword.UseSystemPasswordChar = !isPassVisible;

            txtPassword.IconRight = isPassVisible
                ? Properties.Resources.icons8_show_password_32
                : Properties.Resources.icons8_hide_password_32;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
