using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DTO
{
    public class Account
    {
       
        public Account(string username, string displayname, int type,int idGiaVien, string password = null)
        {
            this.UserName = username;
            this.DisplayName = displayname;
            this.Type = type;
            this.Password = password;
            this.IdGiaoVien = idGiaoVien;
        }
        public Account(DataRow row)
        {
            this.DisplayName = row["displayname"].ToString();
            this.UserName = row["UserName"].ToString();         
           // this.Password = row["password"].ToString();
            this.Type = (int)row["type"];
            try
            {
                this.IdGiaoVien = (int)row["idGiaoVien"];

            }
            catch { }
        }

        public Account()
        {
        }

        private string userName;
        private string password;
        private int type;
        private string displayName;
        private int idGiaoVien;

        public string DisplayName { get => displayName; set => displayName = value; }
        public int Type { get => type; set => type = value; }
        public string Password { get => password; set => password = value; }
        public string UserName { get => userName; set => userName = value; }
        public int IdGiaoVien { get => idGiaoVien; set => idGiaoVien = value; }
        // propsperty
    }
}
