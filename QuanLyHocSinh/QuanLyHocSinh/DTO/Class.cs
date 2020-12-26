using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DTO
{
    public class Class
    {
        public Class(int id,string name,int idCaculty)
        {
            this.ID = id;
            this.Name = name;
            this.IDFaculty = idCaculty;
        }
        public Class(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["Name"].ToString();
            this.IDFaculty = (int)row["idKhoa"];
        }
        private int iD;
        private string name;
        private int iDFaculty;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int IDFaculty { get => iDFaculty; set => iDFaculty = value; }
    }
}
