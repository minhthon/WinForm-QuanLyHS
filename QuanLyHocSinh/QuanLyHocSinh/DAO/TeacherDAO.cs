using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DAO
{
    public class TeacherDAO
    {
        private static TeacherDAO instance;
        public static TeacherDAO Instance
        {
            get { if (instance == null) instance = new TeacherDAO(); return instance; }
            private set { instance = value; }
        }

        private TeacherDAO() { }
        public DataTable LoadTeacherReport()
        {
            string SQL = "Select * from GiaoVien";
            DataTable dt = DataProvider.Instance.ExcuteQuery(SQL);
            return dt;

        }
        public List<Teacher> LoadListTeacher()
        {
            List<Teacher> classList = new List<Teacher>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from GiaoVien");
            foreach (DataRow item in data.Rows)
            {
                Teacher table = new Teacher(item);
                classList.Add(table);
            }
            return classList;
        }

        public bool AddTeacher(string name, int malop, int mamonhoc,int makhoa)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("insert GiaoVien ( name , malop, mamonhoc ,makhoa) values (N'{0}',{1},{2},{3})", name, malop,mamonhoc,makhoa));

            return ret > 0;
        }
        public bool AddTeacherNoIdCLass(string name, int mamonhoc, int makhoa)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("insert GiaoVien ( name , mamonhoc ,makhoa) values (N'{0}',{1},{2})", name, mamonhoc, makhoa));

            return ret > 0;
        }
        public bool Editeacher(int id, string name, int malop,int mamonhoc,int makhoa)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Update GiaoVien set name= N'{0}' , malop={1} , mamonhoc= {2}, makhoa ={4} where id={3} ", name, malop,mamonhoc, id,makhoa));

            return ret > 0;
        }
        public bool Editeacher(int id)
        { 
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Update GiaoVien set  mamonhoc= 13, makhoa =5  where makhoa={0} ",id));

            return ret > 0;
        }
        public bool Editeacher(int id, string name,  int mamonhoc, int makhoa)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Update GiaoVien set name= N'{0}'  , mamonhoc= {1}, makhoa ={2} where id={3} ", name, mamonhoc,  makhoa,id));

            return ret > 0;
        }

        public bool DeleteTeacher(int id)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete GiaoVien where id={0} ", id));

            return ret > 0;
        }
  
     
        public List<Teacher> SearchTeacherByNameSubject(string name)
        {
            List<Teacher> classList = new List<Teacher>();
            string query = string.Format("Select * from GiaoVien where mamonhoc in (select id from monhoc where name = N'{0}')", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Teacher table = new Teacher(item);

                classList.Add(table);
            }
            return classList;
        }
        public List<Teacher> SearchTeacherByNameClass(string name)
        {
            List<Teacher> classList = new List<Teacher>();
            string query = string.Format("Select * from GiaoVien where malop in (select id from Lop where name = N'{0}')", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Teacher table = new Teacher(item);

                classList.Add(table);
            }
            return classList;
        }
        public List<Teacher> SearchTeacherByNameFaculty(string name)
        {
            List<Teacher> classList = new List<Teacher>();
            string query = string.Format("Select * from GiaoVien where makhoa in (select id from Khoa where name = N'{0}')", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Teacher table = new Teacher(item);

                classList.Add(table);
            }
            return classList;
        }
        public List<Teacher> SearchTeacherByName(string name)
        {
            List<Teacher> classList = new List<Teacher>();
            string query = string.Format("Select * from GiaoVien where dbo.Thaydoikitu(name) like N'%' +dbo.Thaydoikitu(N'{0}')+'%'", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Teacher table = new Teacher(item);

                classList.Add(table);
            }
            return classList;
        }
 
    }
}
