using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DAO
{
    public class ClassDAO
    {
        private static ClassDAO instance;
        public static ClassDAO Instance
        {
            get { if (instance == null) instance = new ClassDAO(); return instance; }
            private set { instance = value; }
        }
        private ClassDAO() { }

        public DataTable LoadClassReport()
        {
            string SQL = "Select * from Lop";
            DataTable dt = DataProvider.Instance.ExcuteQuery(SQL);
            return dt;

        }
        public List<Class> LoadClassListByIDTeacher(int id)
        {
            List<Class> classList = new List<Class>();
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from Lop where id in(select idLop from LopGiangDay where idGiaoVien = N'{0}')", id));
            foreach (DataRow item in data.Rows)
            {
                Class table = new Class(item);

                classList.Add(table);
            }
            return classList;
        }
        public List<Class> LoadClassListInFacultyName(string name )
        {
            List<Class> classList = new List<Class>();
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select *  from Lop where idkhoa in( Select id from Khoa where name = N'{0}')", name));
            foreach (DataRow item in data.Rows)
            {
                Class table = new Class(item);

                classList.Add(table);
            }
            return classList;
        }
        public List<Class> LoadClassList()
        {
            List<Class> classList = new List<Class>();
            DataTable data = DataProvider.Instance.ExcuteQuery("exec USP_GetClassList");
            foreach (DataRow item in data.Rows)
            {
                Class table = new Class(item);

               classList.Add(table);
            }
            return classList;
        }
        public bool DeleteStudentbyIDClassToIDFaculty(int id)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Delete SinhVien where malop in (select id from Lop where idkhoa= {0})", id));

            return ret > 0;       

    }
    public bool AddClass(string name, string nameFaculty)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Insert into Lop(name,idKhoa) select N'{0}', id from Khoa where name= N'{1}' ", name, nameFaculty));

            return ret > 0;
        }
        public bool EditClass(int id, string name, int Makhoa)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Update Lop set name = N'{0}' ,idkhoa = {1} where id = {2} ", name, Makhoa, id));

            return ret > 0;
        }
        public bool DeleteClassByIdFaculty(int id)
        {
           
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Lop where idKhoa = {0} ", id));
            return ret > 0;
        }
        public bool DeleteClass(int id)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Lop where id={0} ", id));

            return ret > 0;
        }
        public List<Class> SearchClasstByName(string name)
        {
            List<Class> classList = new List<Class>();
            string query = string.Format("Select * from Lop where dbo.Thaydoikitu(name) like N'%' +dbo.Thaydoikitu(N'{0}')+'%'", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Class table = new Class(item);

                classList.Add(table);
            }
            return classList;
        }
        public List<Class> SearchClassByID(int id)
        {
            List<Class> classList = new List<Class>();
            string query = string.Format("Select * from Lop where idkhoa = {0} ", id );
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Class table = new Class(item);

                classList.Add(table);
            }
            return classList;
        }

    }
}

