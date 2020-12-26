using QuanLyHocSinh.DAO;
using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class fLogin : Form
    {
        public Account LoginAccount { get; private set; }
        public fLogin()
        {
            InitializeComponent();
        }

       

        private bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
                     
        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            string username = txtUserName.Text;
            string password = txtPassword.Text;
            if (Login(username, password))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(username);
                fChinh f = new fChinh(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
