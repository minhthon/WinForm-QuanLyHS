using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DAO
{
    public class SubjectDAO
    {
        private static SubjectDAO instance;
        public static SubjectDAO Instance
        {
            get { if (instance == null) instance = new SubjectDAO(); return instance; }
            private set { instance = value; }
        }
        private SubjectDAO() { }
        public List<Subject> LoadSubjectListByNameFaculty(string name)
        {
            List<Subject> subjectList = new List<Subject>();
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select *  from Monhoc where makhoa in( Select id from Khoa where name = N'{0}')", name));
            foreach (DataRow item in data.Rows)
            {
                Subject table = new Subject(item);

                subjectList.Add(table);
            }
            return subjectList;
        }
        public List<Subject> LoadSubjectList()
        {
            List<Subject> subjectList = new List<Subject>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from MonHoc");
            foreach (DataRow item in data.Rows)
            {
                Subject table = new Subject(item);

               subjectList.Add(table);
            }
            return subjectList;
        }
        public Subject GetSubjectID(int id)
        {
           Subject subject = null;

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from MonHoc where id= " + id);
            foreach (DataRow item in data.Rows)
            {
                Subject table = new Subject(item);

                subject = new Subject(item);
                return subject;
            }
            return subject;
        }

      


        public bool AddSuibject(string name, int makhoa,int tinchi)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("insert Monhoc ( name , makhoa, tinchi ) values (N'{0}',{1},{2})", name,makhoa,tinchi));

            return ret > 0;
        }
        public bool EditSubject(int id, string name,int Makhoa,int tinchi)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Update MonHoc set name= N'{0}' ,makhoa={1},tinchi = {3} where id={2} ", name, Makhoa,id,tinchi));

            return ret > 0;
        }
        public bool DeleteSubject(int id)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Monhoc where id={0} ", id));

            return ret > 0;
        }
        public bool DeleteSubjectbyIDFaculty(int id)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Delete Monhoc where makhoa = {0} ", id));
            return ret > 0;
        }
        public List<Subject> SearchSubjectByName(string name)
        {
            List<Subject> subjectList = new List<Subject>();
            string query = string.Format("Select * from Monhoc where dbo.Thaydoikitu(name) like N'%' +dbo.Thaydoikitu(N'{0}')+'%'", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
              Subject table = new Subject(item);

                subjectList.Add(table);
            }
            return subjectList;
        }
    }
}
