using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DAO
{
   public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }
        public bool Login(string username, string password)
        {

            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);//bien mat khau thanh mang kieu byte
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);// ma hoa mat khau bang MD5

            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            string query = "USP_Login @username , @password";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { username, hasPass });
            return result.Rows.Count > 0;
        }
        public DTO.Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from account where username= '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new DTO.Account(item);
            }
            return null;

        }
        public bool UpdateAccount(string userName, string displayName, string passWord, string newPassword)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @username , @displayname , @password , @newpassword", new object[] { userName, displayName, passWord, newPassword });
            return ret > 0;//
        }
        public DataTable GetListAccount()//Giống như loadlistaccount. trả về danh sách tài khoản
        {
            return DataProvider.Instance.ExcuteQuery("Select username ,Displayname,type,idGiaoVien from Account");
        }
        public bool InsertAccount(string username, string displayname, int type,int id)
        {


            string query = string.Format("Insert Account (Username, displayname, type, password,idGiaoVien) values (N'{0}',N'{1}','{2}',N'{3}',{4}) ", username, displayname, type, "1962026656160185351301320480154111117132155",id);
            int ret = DataProvider.Instance.ExecuteNonQuery(query);
            return ret > 0;
             
        }
        public bool InsertAccount(string username, string displayname, int type)
        {


            string query = string.Format("Insert Account (Username, displayname, type, password) values (N'{0}',N'{1}','{2}',N'{3}') ", username, displayname, type, "1962026656160185351301320480154111117132155");
            int ret = DataProvider.Instance.ExecuteNonQuery(query);
            return ret > 0;

        }
        public bool UpdateAccount(string username, string displayname, int type,int idGiaoVien)
        {
            string query = string.Format("Update Account set  displayname= N'{1}',type = N'{2}', idGiaoVien= {3} where Username=N'{0}' ", username, displayname, type,idGiaoVien);
            int ret = DataProvider.Instance.ExecuteNonQuery(query);
            return ret > 0;
        }
        public bool UpdateAccount(string username, string displayname, int type)
        {
            string query = string.Format("Update Account set  displayname= N'{1}',type = N'{2}' where Username=N'{0}' ", username, displayname, type);
            int ret = DataProvider.Instance.ExecuteNonQuery(query);
            return ret > 0;
        }
        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName=N'{0}'", name);
            int ret = DataProvider.Instance.ExecuteNonQuery(query);
            return ret > 0;
        }
        public bool ResetPassword(string name)
        {

            string query = string.Format("Update Account set  password='1962026656160185351301320480154111117132155' where username=N'{0}'", name);

            int ret = DataProvider.Instance.ExecuteNonQuery(query);
            return ret > 0;
        }
        public List<Account>loadListAccount()
        {
            List<Account> accountList = new List<Account>();
            DataTable data = DataProvider.Instance.ExcuteQuery("exec USB_GetAccountList");
            foreach (DataRow item in data.Rows)
            {
                Account table = new Account(item);

                accountList.Add(table);
            }
            return accountList;
        }

    }
}

