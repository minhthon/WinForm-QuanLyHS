using CrystalDecisions.CrystalReports.Engine;
using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DAO
{
    public class StudentDAO
    {
        private static StudentDAO instance;
        public static StudentDAO Instance
        {
            get { if (instance == null) instance = new StudentDAO(); return instance; }
            private set { instance = value; }
        }
        private StudentDAO() { }


      
        public List<Student> LoadStudentListByNameClass(string name)
        {
            List<Student> studentList = new List<Student>();
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select *  from SinhVien where Malop in( Select id from Lop where name = N'{0}')",name));//Truy van vao CSDL lay danh sach hoc sinh
            foreach (DataRow item in data.Rows)
            {
                Student table = new Student(item);

                studentList.Add(table);
            }
            return studentList;
        }
        public List<Student> LoadStudentList()
        {
            List<Student> studentList = new List<Student>();
            DataTable data = DataProvider.Instance.ExcuteQuery("exec USP_GetStudentList");//Truy van vao CSDL lay danh sach hoc sinh
            foreach (DataRow item in data.Rows)
            {
                Student table = new Student(item);

                studentList.Add(table);
            }
            return studentList;
        }
        public DataTable LoadSudentReport(string nameclass)
        {
            string SQL =string.Format( "Select * from SinhVien where Malop in(select id from Lop where name=N'{0}') ",nameclass);
            DataTable dt = DataProvider.Instance.ExcuteQuery(SQL);
            return dt;
            
        }

        public Student GetStudentID(int id)
        {
            Student student = null;

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from SinhVien where id= " + id);
            foreach (DataRow item in data.Rows)
            {
                Student table = new Student(item);

                student = new Student(item);
                return student;
            }
            return student;
        }
      
        
        public bool AddStudent( string name,DateTime ngaysinh, int gioitinh, string diachi, string tenlop)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Insert into SinhVien (name,ngaysinh,gioitinh,Diachi,Malop) select N'{0}','{1}',{2},N'{3}' ,(select id from Lop where Name =N'{4}')", name , ngaysinh , gioitinh , diachi , tenlop));

            return ret > 0;
        }
        public bool EditStudent(int id, string name, DateTime ngaysinh, int gioitinh, string diachi, int malop)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Update SinhVien set name= N'{0}' ,ngaysinh  =N'{1}', gioitinh ={2} , diachi= N'{3}' , malop={4}  where id={5} ",name ,ngaysinh ,gioitinh ,diachi ,malop ,id));

            return ret > 0;
        }
        public bool DeleteStudent(int id)
        {
           
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete SinhVien where id={0} ", id));

            return ret > 0;
        }
        public bool DeleteStudentbyIdClass(int idClass)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete SinhVien where malop={0} ", idClass));

            return ret > 0;
        }
        public List<Student>SearchStudentByName(string name)
        {
            List<Student> studentList = new List<Student>();
            string query = string.Format("Select * from sinhvien where dbo.Thaydoikitu(name) like N'%' +dbo.Thaydoikitu(N'{0}')+'%'", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Student table = new Student(item);

                studentList.Add(table);
            }
            return studentList;
        }
        public List<Student> SearchStudentByIDFaculty(int idClass)
        {
            List<Student> studentList = new List<Student>();
            string query = string.Format("Select * from sinhvien where malop = {0} ", idClass);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Student table = new Student(item);

                studentList.Add(table);
            }
            return studentList;
        }
    }
}
