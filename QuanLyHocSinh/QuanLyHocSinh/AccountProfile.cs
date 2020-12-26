using QuanLyHocSinh.DAO;
using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }

        }

        private void ChangeAccount(Account account)
        {
            txtUserName.Text = LoginAccount.UserName;
            txtDisplayName.Text = LoginAccount.DisplayName;
        }

        public fAccountProfile(Account account)
        {
            InitializeComponent();
            LoginAccount = account;
        }

     

       
        public class AccountEvent : EventArgs
        {
            private Account acc;

            public Account Acc
            {
                get { return acc; }
                set { acc = value; }
            }

            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        public void Update()
        {
            string displayName = txtDisplayName.Text;
            string password = txtPassword.Text;
            string newPassword = txtNewPassword.Text;
            string reNewPassword = txtReEnterPassword.Text;
            string userName = txtUserName.Text;


            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);//bien mat khau thanh mang kieu byte
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);// ma hoa mat khau bang MD5

            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }


            byte[] temp1 = ASCIIEncoding.ASCII.GetBytes(newPassword);//bien mat khau thanh mang kieu byte
            byte[] hasData1 = new MD5CryptoServiceProvider().ComputeHash(temp1);// ma hoa mat khau bang MD5

            string hasPass1 = "";
            foreach (byte item in hasData1)
            {
                hasPass1 += item;
            }


            byte[] temp2 = ASCIIEncoding.ASCII.GetBytes(reNewPassword);//bien mat khau thanh mang kieu byte
            byte[] hasData2 = new MD5CryptoServiceProvider().ComputeHash(temp2);// ma hoa mat khau bang MD5

            string hasPass2 = "";
            foreach (byte item in hasData2)
            {
                hasPass2 += item;
            }

            if (!hasPass1.Equals(hasPass2 ))
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không trùng khớp");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, hasPass, hasPass1))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (
                        updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại do mật khẩu không chính xác");
                }
            }
        }
     

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Update();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
