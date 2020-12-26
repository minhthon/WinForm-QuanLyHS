using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DTO
{
    public class Teacher
    {
        public  Teacher(int id, string name,int idclass,int idsubject,int idfaculty)
            {
            this.ID = id;
            this.Name = name;
            this.IdClass = idclass;
            this.IdSubject = idsubject;
            this.IdFaculty = idfaculty;
            }
        public Teacher (DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["Name"].ToString();
            try
            {
                this.IdClass = (int)row["malop"];
            }
            catch { }
            this.IdSubject = (int)row["mamonhoc"];
            this.IdFaculty = (int)row["makhoa"];
        }
        private int iD;
        private string name;
        private int idClass;
        private int idSubject;
        private int idFaculty;
       
        public string Name { get => name; set => name = value; }
        public int ID { get => iD; set => iD = value; }
        public int IdClass { get => idClass; set => idClass = value; }
        public int IdSubject { get => idSubject; set => idSubject = value; }
        public int IdFaculty { get => idFaculty; set => idFaculty = value; }
    }
}
