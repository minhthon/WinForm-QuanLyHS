using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh.DAO
{
    public class FacultyDAO
    {
        private static FacultyDAO instance;
        public static FacultyDAO Instance
        {
            get { if (instance == null) instance = new FacultyDAO(); return instance; }
            private set { instance = value; }
        }
        private FacultyDAO() { }
      
        public List<Faculty> LoadFacultyList()
        {
            List<Faculty> facultyList = new List<Faculty>();
            DataTable data = DataProvider.Instance.ExcuteQuery("exec USP_GetFacultyList");
            foreach (DataRow item in data.Rows)
            {
                Faculty table = new Faculty(item);

                facultyList.Add(table);
            }  
            return facultyList;
        }
        public Faculty GetFacultyID(int id)
        {
            Faculty faculty = null;

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from Khoa where id= "+ id);
            foreach (DataRow item in data.Rows)
            {
                Faculty table = new Faculty(item);

                faculty = new Faculty(item);
                return faculty;
            }
            return faculty;
        }
        public bool AddFaculty(string name)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("insert Khoa ( name ) values (N'{0}')", name));

            return ret > 0;
        }
        public bool EditFaculty(int id, string name)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Update Khoa set name= N'{0}'  where id={1} ", name, id));

            return ret > 0;
        }
        public bool DeleteFaculty(int id)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Khoa where id={0} ", id));

            return ret > 0;
        }
        public List<Faculty> SearchFacultyByName(string name)
        {
            List<Faculty> facultyList = new List<Faculty>();
            string query = string.Format("Select * from Khoa where dbo.Thaydoikitu(name) like N'%' +dbo.Thaydoikitu(N'{0}')+'%'", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
              Faculty table = new Faculty(item);

                facultyList.Add(table);
            }
            return facultyList;
        }
    }
}
