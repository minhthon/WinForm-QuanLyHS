using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DAO
{
   public class Teaching_ClassDAO
    {
        private static Teaching_ClassDAO instance;
        public static Teaching_ClassDAO Instance
        {
            get { if (instance == null) instance = new Teaching_ClassDAO(); return instance; }
            private set { instance = value; }
        }

        private Teaching_ClassDAO() { }

        public List<Teaching_Class> LoadListTeachering_class()
        {
            List<Teaching_Class> classList = new List<Teaching_Class>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select lg.idGiaoVien, gv.name as nameteacher,lg.idlop,l.name from LopGiangDay as lg, GiaoVien as gv ,Lop as l where lg.idLop=l.id and lg.idGiaoVien=gv.id");
            foreach (DataRow item in data.Rows)
            {
               Teaching_Class table = new Teaching_Class(item);
                classList.Add(table);
            }
            return classList;
        }
      
        public bool AddTeaching_class(int idteacher, int idclass)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("insert into Lopgiangday( idgiaovien , idlop) values (N'{0}',{1})", idteacher, idclass));

            return ret > 0;
        }
        public bool DeleteTeaching_classByIDFaculty(int id)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Lopgiangday where  idlop in(select id from lop where idkhoa ={0})", id));

            return ret > 0;
        }
        public bool DeleteTeaching_class(int idteacher, int idclass)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Lopgiangday where idgiaovien={0} and idlop ={1}", idteacher, idclass));

            return ret > 0;
        }
        public bool DeleteTeaching_classByIdTeacher(int idteacher)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Lopgiangday where idgiaovien={0}", idteacher));

            return ret > 0;
        }
        public bool DeleteTeaching_classByIDClass(int idclass)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Lopgiangday where idlop ={0}",  idclass));

            return ret > 0;
        }


    }
}
