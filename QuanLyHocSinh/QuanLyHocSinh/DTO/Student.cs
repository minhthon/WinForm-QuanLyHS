using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh.DTO
{
    public class Student
    {
        public Student(int malop)
        {
            this.MaLop = malop;
        }
       
        public Student(int id,string name,DateTime ngaysinh, int gioitinh,string diachi,int malop)
        {
            this.ID = id;
            this.Name = name;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gioitinh;
            this.DiaChi = diachi;
            this.MaLop = malop;
        }
        public Student (DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.NgaySinh = (DateTime)row["ngaysinh"];
            this.GioiTinh = (int)row["gioitinh"];
            this.DiaChi = row["diachi"].ToString();
            this.MaLop=(int)row["malop"];
        }
        private int iD;
        private string name;
        private DateTime ngaySinh;
        private int gioiTinh;
        private string diaChi;
        private int maLop;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int MaLop { get => maLop; set => maLop = value; }
    }
}
