using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DTO
{
    public class Teaching_Class
    {
        public Teaching_Class(int idTeacher,int idclass,string nameteacher, string nameclass)
        {
            this.IDTeacher = idTeacher;
            this.IdClass = idclass;
            this.NameTeacher = nameTeacher;
            this.NameClass = nameclass;
        }
        public Teaching_Class(DataRow row)
        {
            this.IDTeacher = (int)row["idgiaovien"];
            this.IdClass = (int)row["idlop"];
            this.NameTeacher = row["nameteacher"].ToString();
            this.NameClass = row["name"].ToString();
        }

        private int iDTeacher;
        private int  idClass;
        private string nameTeacher;
        private string nameClass;

        public int IdClass { get => idClass; set => idClass = value; }
        public int IDTeacher { get => iDTeacher; set => iDTeacher = value; }
        public string NameClass { get => nameClass; set => nameClass = value; }
        public string NameTeacher { get => nameTeacher; set => nameTeacher = value; }
    }
}
