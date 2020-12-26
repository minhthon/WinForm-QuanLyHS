using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DTO
{
    public class Subject
    {
        public Subject (int id, string name,int tinchi, int idfaculty)
        {
            this.ID = id;
            this.Name = name;
            this.TinChi = TinChi;
            this.IDFaculty = idfaculty;
        }
        public Subject(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.TinChi =(int) row["tinchi"];
            this.IDFaculty = (int)row["makhoa"];
        }
        private int iD;
        private string name;
        private int tinChi;
        private int iDFaculty;

        public int IDFaculty { get => iDFaculty; set => iDFaculty = value; }
        public string Name { get => name; set => name = value; }
        public int ID { get => iD; set => iD = value; }
        public int TinChi { get => tinChi; set => tinChi = value; }
    }
}
