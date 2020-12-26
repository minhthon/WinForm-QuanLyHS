using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace QuanLyHocSinh.DAO
{
   public class ScoresDAO
    {
        private static ScoresDAO instance;
        public static ScoresDAO Instance
        {
            get { if (instance == null) instance = new ScoresDAO(); return instance; }
            private set { instance = value; }
        }
        private ScoresDAO() { }

        public DataTable LoadScoreReportByAdmin(string nameclass, string namesubject)
        {
            string SQL = string.Format("select * from Diem where idHocSinh in(select id from SinhVien where malop in(select id from Lop Where name = N'{0}' )) and idMonHoc in(select id from GiaoVien where mamonhoc in( select id from MonHoc where name =N'{1}'))", nameclass,namesubject);
            DataTable dt = DataProvider.Instance.ExcuteQuery(SQL);
            return dt;

        }
        public DataTable LoadScoreReport(int idteacher, string nameclass)
        {
            string SQL = string.Format("Select * from Diem where idgiaovien ={0} and idhocsinh in(select id from SinhVien where malop in( select id from Lop where name= {1}))", idteacher, nameclass);
            DataTable dt = DataProvider.Instance.ExcuteQuery(SQL);
            return dt;

        }
        public List<Scores> LoadScoresListByNameClassAndNameTeacher(string nameclass, string nameteacher)
        {
            List<Scores> scoresList = new List<Scores>();
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select  sv.id,sv.name,d.diemchuyencan,d.diemtrungbinhkiemtra,d.diemthi,d.diemtrungbinh ,mh.name from SinhVien as sv,Diem as d,MonHoc as mh where sv.id=d.idHocSinh and mh.id=d.idMonHoc and sv.Malop in ( select  id From Lop where Name=N'{0}') and d.idgiaovien in(select id from GiaoVien where name=N'{1}')", nameclass, nameteacher));//Truy van vao CSDL lay danh sach hoc sinh
            foreach (DataRow item in data.Rows)
            {
                Scores table = new Scores(item);

                scoresList.Add(table);
            }
            return scoresList;
        }
        public List<Scores> LoadScoresListByIDTeacherAndNameClass(int id, string name)
        {
            List<Scores> scoresList = new List<Scores>();
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select idhocsinh, sv.name as'Ten hoc sinh',idmonhoc,mh.name,diemchuyencan,diemtrungbinhkiemtra,diemthi,diemtrungbinh from Diem as d, MonHoc as mh,SinhVien as sv  where mh.id=d.idMonHoc and d.idHocSinh=sv.id and d.idgiaovien =N'{0}' and sv.malop in(select id from Lop where name= N'{1}') ", id,name));
            foreach (DataRow item in data.Rows)
            {
                Scores table = new Scores(item);

                scoresList.Add(table);
            }
            return scoresList;
        }
        public List<Scores> LoadScoresListByNameC(string Name)
        {
            List<Scores> scoresList = new List<Scores>();
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select idhocsinh, sv.name as'Ten hoc sinh',idmonhoc,mh.name,diemchuyencan,diemtrungbinhkiemtra,diemthi,diemtrungbinh from Diem as d, MonHoc as mh,SinhVien as sv where mh.id=d.idMonHoc and d.idHocSinh=sv.id and sv.name =N'{0}'", Name));
            foreach (DataRow item in data.Rows)
            {
                Scores table = new Scores(item);

                scoresList.Add(table);
            }
            return scoresList;
        }
        public List<Scores> LoadScoresListByNameClassAndNameSubject(string NameClass, string nameSubject)
        {
            List<Scores> scoresList = new List<Scores>();
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select idhocsinh, sv.name as'Ten hoc sinh',idmonhoc,mh.name,diemchuyencan,diemtrungbinhkiemtra,diemthi,diemtrungbinh from Diem as d, MonHoc as mh,SinhVien as sv where mh.id=d.idMonHoc and d.idHocSinh=sv.id and sv.malop in (select id from Lop where name =N'{0}') and mh.id in(select id from Monhoc where name =N'{1}')", NameClass,nameSubject));
            foreach (DataRow item in data.Rows)
            {
                Scores table = new Scores(item);

                scoresList.Add(table);
            }
            return scoresList;
        }

        public List<Scores> LoadScoresList()
        {
            List<Scores> scoresList = new List<Scores>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select idhocsinh, sv.name as'Ten hoc sinh',idmonhoc,mh.name,diemchuyencan, diemtrungbinhkiemtra,diemthi,diemtrungbinh from Diem as d, MonHoc as mh,SinhVien as sv where mh.id=d.idMonHoc and d.idHocSinh=sv.id");
            foreach (DataRow item in data.Rows)
            {
                Scores table = new Scores(item);

                scoresList.Add(table);
            }
            return scoresList;
        }
        public bool AddScores(int idhocsinh,int idmonhoc,float diem15p, float diem1tiet, float diemthi,float diemtb)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("insert Diem ( idhocsinh , idmonhoc , diemchuyencan , diemtrungbinhkiemtra , diemthi,diemtrungbinh ) values (N'{0}',{1},{2},{3},{4},{5})", idhocsinh, idmonhoc,diem15p,diem1tiet,diemthi,diemtb));

            return ret > 0;
        }
        public bool EditScores(int idhocsinh, int idmonhoc, float diem15p, float diem1tiet,  float diemthi,float diemtrungbinh)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Update Diem set  diemchuyencan = {2} , diemtrungbinhkiemtra ={3}, diemthi = {4} , diemtrungbinh={5}  where idhocsinh= {0} and idmonhoc= {1} ", idhocsinh, idmonhoc, diem15p,diem1tiet,diemthi,diemtrungbinh));

            return ret > 0;
        }
        public bool DeleteScorebyIDSubjectoIDFaculty(int id)
        {
            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Diem where idmonhoc in (select id from MonHoc where Makhoa = {0})", id));
            return ret > 0;
        }
        public bool DeleteScores(int id, int idmonhoc)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("Update Diem set  diemchuyencan =0 , diemtrungbinhkiemtra=0, diemthi=0 where idhocsinh={0} and idmonhoc={1} ", id, idmonhoc));

            return ret > 0;
        }
        public bool ÍnsertScores( string  nameclass)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("insert into Diem (idHocSinh,idMonHoc,idgiaovien) select sv.id, mh.id ,gv.id from SinhVien as sv, MonHoc as mh, GiaoVien as gv where sv.id=  (select max(id) from SinhVien where malop in(select id from Lop where name=N'{0}')   and mh.id in(select id from MonHoc where Makhoa in(select idKhoa from Lop where name =N'{0}' )) and gv.id in (select mh.id from GiaoVien where mamonhoc=mh.id) ", nameclass));

            return ret > 0;
        }

        public bool DeleteScoresByIDStudent(int id)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Diem where idhocsinh={0}", id));

            return ret > 0;
        }
        public bool DeleteScoresByIDSubject(int idSubject)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Diem where idMonhoc = {0}", idSubject));

            return ret > 0;
        }
        public bool DeleteScoresByIDClass(int idClass)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Diem where idhocsinh in (select id from SinhVien where malop in(select id from Lop where id = {0}))", idClass));

            return ret > 0;
        }
        public bool DeleteScoresByIDStudentToIdFaculty(int idClass)
        {

            int ret = DataProvider.Instance.ExecuteNonQuery(string.Format("delete Diem where idhocsinh in (select id from SinhVien where malop in(select id from Lop where idKhoa = {0}))", idClass));

            return ret > 0;
        }
        public List<Scores> SearchScoreByID(int  id)
        {
            List<Scores> scoreList = new List<Scores>();
            string query = string.Format("Select * from Diem where idhocsinh= {0} ",id);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Scores table = new Scores(item);

                scoreList.Add(table);
            }
            return scoreList;
        }

    }

}

