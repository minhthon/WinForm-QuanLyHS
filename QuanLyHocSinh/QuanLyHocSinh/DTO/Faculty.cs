using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DTO
{
    public class Faculty
    {
        public Faculty(int id,string name)
        {
            this.ID = id;
            this.Name = name;

        }
        public Faculty (DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
        }
        private int iD;
        private string name;

        public string Name { get => name; set => name = value; }
        public int ID { get => iD; set => iD = value; }
    }
}
