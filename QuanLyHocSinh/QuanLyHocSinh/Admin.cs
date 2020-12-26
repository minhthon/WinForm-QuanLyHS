using QuanLyHocSinh.DAO;
using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class fAdmin : Form
    {
        BindingSource listTeacher = new BindingSource();
        BindingSource listAccount = new BindingSource();
        BindingSource liststudent = new BindingSource();
        BindingSource listFaculty = new BindingSource();
        BindingSource listClass = new BindingSource();
        BindingSource listScores = new BindingSource();
        BindingSource listSubject = new BindingSource();
        BindingSource listTeaching_class = new BindingSource();

        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            dtgvTeacher.DataSource = listTeacher;
            dtgvAccount.DataSource = listAccount;
            dtgvHocSinh.DataSource = liststudent;
            dtgvFaculty.DataSource = listFaculty;
            dtgvClass.DataSource = listClass;
            dtgvScores.DataSource = listScores;
            dtgvSubject.DataSource = listSubject;
            dtgvTeaching_class.DataSource = listTeaching_class;

            LoadStudentList();            //Load Danh sách học sinh 

            LoadFacultylist();  //Load danh sách khoa

            LoadClassList(); //Load danh sách lớp

            //Load danh sách điểm

            LoadListAccount();//Load danh sách tài khoản

            StudentBinding();//Binding danh sách học sinh

            AccountBinding(); //Binding danh sách tài khoản

            FacultyBinding();//Binding danh sách khoa
            TeacherBinding();
           
            SubjectBinding();
            ClassBinding();
            ScoresBinding();
            LoadTeacher();
            LoadSubjectList();
            LoadTeaching_class();
            
            LoadStudentByNameClass();
            LoadFacltyListInClass();
            LoadNameClassInScore();
            LoadFacultyListInSubject();
          //  LoadStudentInScore(); //Load danh sách học sinh vào combobox trong tab điểm.
            LoadNameSubjectInScore();
            LoadClassInTeacher();            //Dùng để load lớp học lên combobox trong  tab Giáo Viên
            LoadFacultyInTeacher(); //Load các khoa vào combobox trong giáo viên
            LoadFacultyIntoCombox(cbNameFacultySubject);
            Teaching_class_Binding();

        }
 private void fAdmin_Load(object sender, EventArgs e)
        {
            cbCLassInScore_TextChanged(sender, e);
            cbSubjectInScore_TextChanged(sender, e);

        }
        /*--------------------------------------------------------------------------------------*/
        #region methods
        #region LoadAndBinding
       
       
        void LoadStudentInScore(string name)
        {
            
        }
        void LoadFacultyInTeacher()
        {
            cbFacultyInTeacher.DataSource = FacultyDAO.Instance.LoadFacultyList();
            cbFacultyInTeacher.DisplayMembers = "name";
        }
       
        void LoadClassInTeacher()
        {
          
        }
        void LoadNameClassInScore()
        {
            cbCLassInScore.DataSource = ClassDAO.Instance.LoadClassList();
            cbCLassInScore.DisplayMembers = "name";
        }
        void LoadNameSubjectInScore()
        {
            cbSubjectInScore.DataSource = SubjectDAO.Instance.LoadSubjectList();
            cbSubjectInScore.DisplayMembers = "name";
        }

        void LoadFacultyListInSubject()
        {
            cbFacultyInSubject.DataSource = FacultyDAO.Instance.LoadFacultyList();
            cbFacultyInSubject.DisplayMember = "name";
        }
        void LoadFacltyListInClass()
        {
            cbFacultyInClass.DataSource = FacultyDAO.Instance.LoadFacultyList();
            cbFacultyInClass.DisplayMember = "Name";
        }
        void LoadStudentByNameClass()
        {
            cbShowStudentByClass.DataSource = ClassDAO.Instance.LoadClassList();
            cbShowStudentByClass.DisplayMember = "Name";
        }
        void LoadTeaching_class()
        {
            listTeaching_class.DataSource = Teaching_ClassDAO.Instance.LoadListTeachering_class();

        }
        void Teaching_class_Binding()
        {
            txtIDClassInTeaching_Class.DataBindings.Add(new Binding("Text", dtgvTeaching_class.DataSource, "idclass", true, DataSourceUpdateMode.Never));
            txtIdTeacherInTeaching_class.DataBindings.Add(new Binding("Text", dtgvTeaching_class.DataSource, "idteacher", true, DataSourceUpdateMode.Never));
            txtNameTeacherInTeaching_class.DataBindings.Add(new Binding("Text", dtgvTeaching_class.DataSource, "nameteacher", true, DataSourceUpdateMode.Never));
            txtNameClassInTeaching_Class.DataBindings.Add(new Binding("Text", dtgvTeaching_class.DataSource, "nameclass", true, DataSourceUpdateMode.Never));
        }
        void ScoresBinding()
        {
            txtScoreIDStudent.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "idHocsinh", true, DataSourceUpdateMode.Never));
            txtScoreIDSubject.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "idMonhoc", true, DataSourceUpdateMode.Never));
            txtScore15m.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diemchuyencan", true, DataSourceUpdateMode.Never));
            txtScore45m.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diemtrungbinhkiemtra", true, DataSourceUpdateMode.Never));
            txtScoreTest.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diemthi", true, DataSourceUpdateMode.Never));
            txtScoreMedium.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diemtrungbinh", true, DataSourceUpdateMode.Never));
            txtScoreNameStudent.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "tenhocsinh", true, DataSourceUpdateMode.Never));
            txtScoreNameSubject.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "tenmonhoc", true, DataSourceUpdateMode.Never));

        }

        void SubjectBinding()
        {

            txtIDSubject.DataBindings.Add(new Binding("Text", dtgvSubject.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtNameSubject.DataBindings.Add(new Binding("Text", dtgvSubject.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtIDFacultySubject.DataBindings.Add(new Binding("Text", dtgvSubject.DataSource, "IDFaculty", true, DataSourceUpdateMode.Never));
            txtTinChi.DataBindings.Add(new Binding("Text", dtgvSubject.DataSource, "TinChi", true, DataSourceUpdateMode.Never));

        }
        void ClassBinding()
        {
            txtClassID.DataBindings.Add(new Binding("Text", dtgvClass.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtNameClass.DataBindings.Add(new Binding("Text", dtgvClass.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtIDFacultyClass.DataBindings.Add(new Binding("Text", dtgvClass.DataSource, "idFaculty", true, DataSourceUpdateMode.Never));
        }
        void FacultyBinding()
        {
            txtNameFaculty.DataBindings.Add(new Binding("Text", dtgvFaculty.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtIDFaculty.DataBindings.Add(new Binding("Text", dtgvFaculty.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }
        void LoadFacultyIntoCombox(ComboBox cb)
        {
            cb.DataSource = FacultyDAO.Instance.LoadFacultyList();
            cb.DisplayMember = "Name";
        }


        void StudentBinding()
        {
            txtIDClassStudent.DataBindings.Add(new Binding("Text", dtgvHocSinh.DataSource, "malop", true, DataSourceUpdateMode.Never));
            txtIDStudent.DataBindings.Add(new Binding("Text", dtgvHocSinh.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtNameStudent.DataBindings.Add(new Binding("Text", dtgvHocSinh.DataSource, "name", true, DataSourceUpdateMode.Never));
            dtpBirthdayStudent.DataBindings.Add(new Binding("Value", dtgvHocSinh.DataSource, "ngaysinh", true, DataSourceUpdateMode.Never));
            nmSexStudent.DataBindings.Add(new Binding("Value", dtgvHocSinh.DataSource, "gioitinh", true, DataSourceUpdateMode.Never));
            txtLocationStudent.DataBindings.Add(new Binding("Text", dtgvHocSinh.DataSource, "diachi", true, DataSourceUpdateMode.Never));

        }
        void AccountBinding()
        {
            txtUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Username", true, DataSourceUpdateMode.Never));//Không cho dử liệu trong textbox Update về.
            txtDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Displayname", true, DataSourceUpdateMode.Never));//Không cho dử liệu trong textbox Update về.
            nmTypeAccount.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "type", true, DataSourceUpdateMode.Never));//Không cho dử liệu trong textbox Update về.
            txtIDTeacherInAccount.DataBindings.Add(new Binding("text",  dtgvAccount.DataSource, "idGiaoVien", true, DataSourceUpdateMode.Never));
        }
        void TeacherBinding()
        {
            txtIdTeacher.DataBindings.Add(new Binding("text", dtgvTeacher.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtNameTeacher.DataBindings.Add(new Binding("text", dtgvTeacher.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtIdClassInTeacher.DataBindings.Add(new Binding("text", dtgvTeacher.DataSource, "idclass", true, DataSourceUpdateMode.Never));
            txtIdFacultyINTeacher.DataBindings.Add(new Binding("text", dtgvTeacher.DataSource, "idfaculty", true, DataSourceUpdateMode.Never));
            txtIdSubjectInTeacher.DataBindings.Add(new Binding("text", dtgvTeacher.DataSource, "idsubject", true, DataSourceUpdateMode.Never));
           
        }
        void LoadTeacher()
        {
            listTeacher.DataSource = TeacherDAO.Instance.LoadListTeacher();
            dtgvTeacher.Columns["id"].HeaderText = "Mã giáo viên";
            dtgvTeacher.Columns["name"].HeaderText = "Tên giáo viên";
            dtgvTeacher.Columns["idclass"].HeaderText = "Mã lớp giảng dạy";
            dtgvTeacher.Columns["idSubject"].HeaderText = "Mã môn giảng dạy";

            dtgvTeacher.Columns["idFaculty"].HeaderText = "Mã Khoa";

        }
        private void LoadListAccount()
        {
            listAccount.DataSource = AccountDAO.Instance.GetListAccount();
            dtgvAccount.Columns["Username"].HeaderText = "Tên tài khoản";
            dtgvAccount.Columns["Displayname"].HeaderText = "Tên hiển thị";
            dtgvAccount.Columns["Type"].HeaderText = "Loại tài khoản";
            dtgvAccount.Columns["idgiaovien"].HeaderText = "Mã giáo viên";

        }
        public void LoadStudentList()
        {
            liststudent.DataSource = StudentDAO.Instance.LoadStudentList();
            dtgvHocSinh.Columns["id"].HeaderText = "Mã số học sinh";
            dtgvHocSinh.Columns["name"].HeaderText = "Họ tên học sinh";
            dtgvHocSinh.Columns["Ngaysinh"].HeaderText = "Ngày sinh";
            dtgvHocSinh.Columns["gioitinh"].HeaderText = "Giới tính";
            dtgvHocSinh.Columns["Diachi"].HeaderText = "Địa chỉ";
            dtgvHocSinh.Columns["Malop"].HeaderText = "Mã lớp";

        }
        private void LoadFacultylist()//load danh sach khoa
        {
            listFaculty.DataSource = FacultyDAO.Instance.LoadFacultyList();
            dtgvFaculty.Columns["name"].HeaderText = "Tên khoa";
            dtgvFaculty.Columns["id"].HeaderText = "Mã khoa";
        }

        private void LoadSubjectList()
        {
            listSubject.DataSource = SubjectDAO.Instance.LoadSubjectList();
            dtgvSubject.Columns["id"].HeaderText = "Mã môn học";
            dtgvSubject.Columns["name"].HeaderText = "Tên môn học";
            dtgvSubject.Columns["idFaculty"].HeaderText = "Mã khoa";
            dtgvSubject.Columns["TinChi"].HeaderText = "Tín chỉ";


        }
       
        private void LoadClassList()//Hien thi danh sach lop
        {

            listClass.DataSource = ClassDAO.Instance.LoadClassList();
            dtgvClass.Columns["id"].HeaderText = "Mã lóp";
            dtgvClass.Columns["name"].HeaderText = "Tên lóp";
            dtgvClass.Columns["idFaculty"].HeaderText = "Mã khoa";


        }
        private void LoadScoresList()//Lay danh sach diem
        {

            listScores.DataSource = ScoresDAO.Instance.LoadScoresList();
            dtgvScores.Columns["idhocsinh"].HeaderText = "Mã học sinh";
            dtgvScores.Columns["idmonhoc"].HeaderText = "Mã môn học";
            dtgvScores.Columns["diemchuyencan"].HeaderText = "Điểm chuyên cần";
            dtgvScores.Columns["diemtrungbinhkiemtra"].HeaderText = "Điểm trung bình kiểm tra";
            dtgvScores.Columns["diemthi"].HeaderText = "Điểm thi";
            dtgvScores.Columns["diemtrungbinh"].HeaderText = "Điểm trung bình";
            dtgvScores.Columns["tenhocsinh"].HeaderText = "Tên học sinh";
            dtgvScores.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            dtgvScores.Columns["idgiaovien"].HeaderText = "Mã giáo viên";


        }
        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region Scores
        void InsertScoreNewMember(string nameclass)
        {
            if (ScoresDAO.Instance.ÍnsertScores( nameclass))
            {

            }
            else
            {

            }    
        }
        void AddScore(int idhocsinh, int idmonhoc, float diem15p, float diem1tiet, float diemthi,float diemtb)
        {
            if (ScoresDAO.Instance.AddScores(idhocsinh,idmonhoc,diem15p,diem1tiet,diemthi,diemtb))
            {
                MessageBox.Show("Thêm điểm thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm điểm thất bại", "Thông báo");
            }
            LoadScoresList();
        }
        void EditScore(int idhocsinh, int idmonhoc, float diem15p, float diem1tiet, float diemthi,float diemtb)
        {
            if (ScoresDAO.Instance.EditScores(idhocsinh, idmonhoc, diem15p, diem1tiet,  diemthi,diemtb))
            {
                MessageBox.Show("Cập nhật thông tin điểm thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin điểm thất bại", "Thông báo");
            }
           
        }
        void DeleteScore(int idhocsinh, int idmonhoc)
        {
            if (ScoresDAO.Instance.DeleteScores(idhocsinh, idmonhoc))
            {
                MessageBox.Show("Xóa điểm thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xóa điểm thất bại", "Thông báo");
            }
            
        }
        void DeleteStudentByIDStudent(int id)
        {

            if (ScoresDAO.Instance.DeleteScoresByIDStudent(id))
            {
             
            }
            else
            {
              
            }
            LoadScoresList();
        }
        void DeleteScoreByIDSubjectt(int idSubject)
        {

            if (ScoresDAO.Instance.DeleteScoresByIDSubject(idSubject))
            {

            }
            else
            {

            }
            LoadScoresList();
        }
        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region Class
        void SeachClassByName(string name)
        {
            listClass.DataSource = ClassDAO.Instance.SearchClasstByName(name);
        }
        void AddClass(string name, string nameFaculty)
        {
            if (ClassDAO.Instance.AddClass(name, nameFaculty))
            {
                MessageBox.Show("Thêm lớp thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm lớp thất bại", "Thông báo");
            }
           
        }
        void EditClass(string name, int makhoa, int id)
        {
            if (ClassDAO.Instance.EditClass(id, name, makhoa))
            {
                MessageBox.Show("Cập nhật thông tin lớp thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin lớp thất bại", "Thông báo");
            }
           
        }
        void DeleteClass(int id)
        {

          //if(  Teaching_ClassDAO.Instance.DeleteTeaching_classByIDClass(id))
          //  {

          //  }   
          //else
          //  {

          //  }

            if (ClassDAO.Instance.DeleteClass(id))
            {
                MessageBox.Show("Xóa lớp thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xóa lớp thất bại", "Thông báo");
            }
         
        }
        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region Subject
        void SeachSubjectByName(string name)
        {
            listSubject.DataSource = SubjectDAO.Instance.SearchSubjectByName(name);

        }
        void AddSubject(string name,int makhoa,int tinchi)
        {
            if (SubjectDAO.Instance.AddSuibject(name,makhoa,tinchi))
            {
                MessageBox.Show("Thêm môn học thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm môn học thất bại", "Thông báo");
            }
          
        }
        void EditSubject(string name,int makhoa,int id,int tinchi)
        {
            if (SubjectDAO.Instance.EditSubject(id, name,makhoa,tinchi))
            {
                MessageBox.Show("Cập nhật môn học thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật môn học thất bại", "Thông báo");
            }
           
        }
        void DeleteSubject(int id)
        {
            if (SubjectDAO.Instance.DeleteSubject(id))
            {
                MessageBox.Show("Xóa môn học thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xóa môn học thất bại", "Thông báo");
            }
          
        }




        #endregion

        /*--------------------------------------------------------------------------------------*/
        #region Faculty
        void SeachFacultyByName(string name)
        {
            listFaculty.DataSource = FacultyDAO.Instance.SearchFacultyByName(name);
        }
        void AddFaculty(string name)
        {
            if (FacultyDAO.Instance.AddFaculty(name))
            {
                MessageBox.Show("Thêm khoa thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm khoa thất bại", "Thông báo");
            }
            LoadFacultylist();
        }
        void EditFaculty(string name, int id)
        {
            if (FacultyDAO.Instance.EditFaculty(id, name))
            {
                MessageBox.Show("Cập nhật khoa thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật khoa thất bại", "Thông báo");
            }
            LoadFacultylist();
        }
        void DeleteFaculty(int id)
        {
            if (FacultyDAO.Instance.DeleteFaculty(id))
            {
                MessageBox.Show("Xóa khoa thành công","Thông báo");
            }
            else
            {
                MessageBox.Show("Xóa khoa thất bại","Thông báo");
            }
           
        }


        #endregion

        /*--------------------------------------------------------------------------------------*/
        #region Student
        void SeachStudentByName(string name)
                    {
                        liststudent.DataSource= StudentDAO.Instance.SearchStudentByName(name);                     
                        
                    }
                    void AddStudent(string name, DateTime ngaysinh, int gioitinh, string diachi, string tenlop)
                    {
                       
                        if (StudentDAO.Instance.AddStudent(name, ngaysinh, gioitinh,diachi,tenlop))
                        {
                            MessageBox.Show("Thêm học sinh thành công", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Thêm học sinh thất bại", "Thông báo");
                        }
                       
                    }
                    void EditStudent(string name, DateTime ngaysinh, int gioitinh, string diachi, int malop,int id)
                    {
                        if (StudentDAO.Instance.EditStudent(id,name, ngaysinh, gioitinh, diachi, malop))
                        {
                            MessageBox.Show("Cập nhật học sinh thành công", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật học sinh thất bại", "Thông báo");
                        }
                       
                    }
                    void DeleteStudent(int id)
                    {

                        if (StudentDAO.Instance.DeleteStudent(id))
                        {
                            MessageBox.Show("Xóa học sinh thành công", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Xóa học sinh thất bại", "Thông báo");
                        }
                       
                    }

        #endregion

        /*--------------------------------------------------------------------------------------*/
        #region Teacher
        void SeachTeacherByName(string name)
        {
            listTeacher.DataSource = TeacherDAO.Instance.SearchTeacherByName(name);

        }
        void AddTeacherNoIDClass(string name,  int mamonhoc, int makhoa)
        {
            if (TeacherDAO.Instance.AddTeacherNoIdCLass(name,mamonhoc,makhoa))
            {
                MessageBox.Show("Thêm giáo viên thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm giáo viên thất bại", "Thông báo");
            }

        }

        void AddTeacher(string name, int malop,int mamonhoc,int makhoa)
        {
            if (TeacherDAO.Instance.AddTeacher(name,malop,mamonhoc,makhoa))
            {
                MessageBox.Show("Thêm giáo viên thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm giáo viên thất bại", "Thông báo");
            }

        }
        void EditTeacher(int id, string name, int mamonhoc, int makhoa)
        {
            if (TeacherDAO.Instance.Editeacher(id, name, mamonhoc, makhoa))
            {
                MessageBox.Show("Cập nhật thông tin giáo viên thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin giáo viên thất bại", "Thông báo");
            }

        }
        void EditTeacher(int id,string name,int malop,int mamonhoc,int makhoa)
        {
            if (TeacherDAO.Instance.Editeacher(id,name,malop,mamonhoc,makhoa))
            {
                MessageBox.Show("Cập nhật thông tin giáo viên thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin giáo viên thất bại", "Thông báo");
            }

        }
        void DeleteTeacher(int id)
        {
            if(Teaching_ClassDAO.Instance.DeleteTeaching_classByIdTeacher(id))
            {

            }
            else { }

            if (TeacherDAO.Instance.DeleteTeacher(id))
            {
                MessageBox.Show("Xóa giáo viên thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xóa giáo viên thất bại", "Thông báo");
            }

        }
        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region Account

        void AddAccount(string username, string displayname,int type,int idGiaoVien)
                        {
                            if(AccountDAO.Instance.InsertAccount(username,displayname,type,idGiaoVien))
                             {
                               MessageBox.Show("Thêm tài khoản thành công", "Thông báo");
                             }
                            else 
                            { MessageBox.Show("Thêm tài khoản thất bại", "Thông báo"); }
                            LoadListAccount();
                        }
        void AddAccount(string username, string displayname, int type)
        {
            if (AccountDAO.Instance.InsertAccount(username, displayname, type))
            {
                MessageBox.Show("Thêm tài khoản thành công", "Thông báo");
            }
            else
            { MessageBox.Show("Thêm tài khoản thất bại", "Thông báo"); }
            LoadListAccount();
        }

        void EditAccount(string username,string displayname,int type,int idGiaoVien)
                        {
                            if (AccountDAO.Instance.UpdateAccount(username, displayname, type,idGiaoVien))
                            {
                                MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo");
                            }
                            else
                            { MessageBox.Show("Cập nhật tài khoản thất bại", "Thông báo"); }
                            LoadListAccount();
                        }
        void EditAccount(string username, string displayname, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(username, displayname, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo");
            }
            else
            { MessageBox.Show("Cập nhật tài khoản thất bại", "Thông báo"); }
            LoadListAccount();
        }
        void DeleteAccount(string username)
                        {
                            if(loginAccount.UserName.Equals(username))
                            {
                                MessageBox.Show("Bạn không thể xóa chính mình được", "Thông báo");
                            }    
                            if (AccountDAO.Instance.DeleteAccount(username))
                            {
                                MessageBox.Show("Xóa tài khoản thành công", "Thông báo");
                            }
                            else
                            { MessageBox.Show("Xóa tài khoản thất bại", "Thông báo"); }
                            LoadListAccount();
                        }
                        void ResetPassword(string username)
                        {
                            if (AccountDAO.Instance.ResetPassword(username))
                            {
                                MessageBox.Show("Reset mật khẩu thành công", "Thông báo");
                            }
                            else
                            { MessageBox.Show("Reset mật khẩu thất bại", "Thông báo"); }
                        }
        #endregion

        /*--------------------------------------------------------------------------------------*/
        #region Teaching_ Class
       
         void DeleteTeaching_Class(int idteacher, int idclass)
        {
            if(Teaching_ClassDAO.Instance.DeleteTeaching_class(idteacher,idclass))
            {
                MessageBox.Show("Xóa lớp giảng dạy thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xóa lớp giảng dạy thất bại", "Thông báo");
            }
        }

        #endregion

        #endregion

        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/

        #region events

        #region Noname
        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Khi Thêm một giáo viên cần chú ý:\nNếu giáo viên đó chưa có nhận lớp giảng dạy thì mã lớp để rổng\nKhông thể có hai giáo viên dạy cùng một môn học trong cùng một lớp nên không thể có mã lớp và mã môn học giống nhau", "Thông báo");

        }






        #endregion

        /*--------------------------------------------------------------------------------------*/
        #region Account
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản này không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {

                string username = txtUserName.Text;
                DeleteAccount(username);
            }
        }

        private void btnAddAcount_Click(object sender, EventArgs e)
        {
            
            string username = txtUserName.Text;
            string displayname = txtDisplayName.Text;
            int type = (int)nmTypeAccount.Value;
            if (txtIDTeacherInAccount.Text == "")
            {
                AddAccount(username, displayname, type);
            }
            else
            {
                int idGiaoVien;
                int.TryParse(txtIDTeacherInAccount.Text, out idGiaoVien);
                AddAccount(username, displayname, type,idGiaoVien);
            }

        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string displayname = txtDisplayName.Text;
            int type = (int)nmTypeAccount.Value;
           
            if (txtIDTeacherInAccount.Text=="")
            {
                EditAccount(username, displayname, type);               
            }
            else
            {
                int idGiaoVien;
                int.TryParse(txtIDTeacherInAccount.Text, out idGiaoVien);
                EditAccount(username, displayname, type, idGiaoVien);

            }
        }

        private void btnShowAccount_Click_1(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        private void btnResetPassword_Click_1(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            ResetPassword(username);
        }
        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region Student

        private void btnShowStudent_Click_1(object sender, EventArgs e)
        {

            LoadStudentList();
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            SeachStudentByName(txtSearchNameStudent.Text);
        }

        private void btnAddStudent_Click_1(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(txtIDClassStudent.Text, out id);
                string name = txtNameStudent.Text;
                DateTime ngaysinh = dtpBirthdayStudent.Value;
                int gioitinh = (int)nmSexStudent.Value;
                string diachi = txtLocationStudent.Text;
                int malop;
                int.TryParse(txtIDClassStudent.Text, out malop);
                string tenlop = cbShowStudentByClass.Text;
                AddStudent(name, ngaysinh, gioitinh, diachi,tenlop ) ;   
                //InsertScoreNewMember(tenlop);
                cbShowStudentByClass_TextChanged(sender, e);
                
                cbCLassInScore_TextChanged(sender, e);
            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
        }

        private void btnDeletesStudent_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa học sinh này không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                try
                {
                    int id;
                    int.TryParse(txtIDStudent.Text, out id);
                    try
                    {
                        DeleteStudentByIDStudent(id);
                        cbShowStudentByClass_TextChanged(sender, e);
                    }

                    catch { }
                    DeleteStudent(id);
                    cbShowStudentByClass_TextChanged(sender, e);
                    cbCLassInScore_TextChanged(sender, e);
                }
                catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
            }
        }

        private void btnEditStudent_Click_1(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameStudent.Text;
                DateTime ngaysinh = dtpBirthdayStudent.Value;
                int gioitinh = (int)nmSexStudent.Value;
                string diachi = txtLocationStudent.Text;
                int malop; int id;
                int.TryParse(txtIDStudent.Text, out id);
                int.TryParse(txtIDClassStudent.Text, out malop);
                EditStudent(name, ngaysinh, gioitinh, diachi, malop, id);
                cbShowStudentByClass_TextChanged(sender, e);
                cbCLassInScore_TextChanged(sender, e);
            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
        }



        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region Faculty
        private void buttonX1_Click(object sender, EventArgs e)
        {
            SeachFacultyByName(txtSearchFacultyByName.Text);
        }
      
        private void btnEditFaculty_Click(object sender, EventArgs e)
        {
            string name = txtNameFaculty.Text;
            int id;
            int.TryParse(txtIDFaculty.Text, out id);
            if (id == 5)
            {
                MessageBox.Show("Bạn không thể cập nhật tên của khoa tạm này", "Thông báo");
            }
            else
            {
                EditFaculty(name, id);
                LoadFacultyInTeacher();
                LoadFacltyListInClass();
                LoadFacultyListInSubject();
            }
        }

        private void btnShowFaculty_Click_1(object sender, EventArgs e)
        {
            LoadFacultylist();
        }

        private void btnAddFaculty_Click(object sender, EventArgs e)
        {
            string name = txtNameFaculty.Text;
            AddFaculty(name);
            LoadFacultyInTeacher();
            LoadFacltyListInClass();
            LoadFacultyListInSubject();
            

        }

        private void btnDeleteFaculty_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Bạn có muốn xóa khoa này không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                int idFaculty;
                int.TryParse(txtIDFaculty.Text, out idFaculty);
                if (idFaculty == 5)
                {
                    MessageBox.Show("Bạn không thể xóa Khoa Tạm này được");
                }
                else
                {
                    try
                    {
                        try
                        {
                            ScoresDAO.Instance.DeleteScoresByIDStudentToIdFaculty(idFaculty);

                        }
                        catch { }

                        try
                        {
                            ScoresDAO.Instance.DeleteScorebyIDSubjectoIDFaculty(idFaculty);

                        }
                        catch { }
                        try
                        {
                            ClassDAO.Instance.DeleteStudentbyIDClassToIDFaculty(idFaculty);

                        }
                        catch { }
                        try
                        {
                            Teaching_ClassDAO.Instance.DeleteTeaching_classByIDFaculty(idFaculty);
                        }
                        catch
                        {

                        }
                        try
                        {
                            ClassDAO.Instance.DeleteClassByIdFaculty(idFaculty);

                        }
                        catch { }
                        try
                        {
                            TeacherDAO.Instance.Editeacher(idFaculty);
                        }
                        catch { }
                        try
                        {
                            SubjectDAO.Instance.DeleteSubjectbyIDFaculty(idFaculty);
                        }
                        catch { }


                        DeleteFaculty(idFaculty);
                        LoadFacultylist();
                        LoadFacultyInTeacher();
                        LoadFacltyListInClass();
                        LoadFacultyListInSubject();

                    }

                    catch
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }
        #endregion
        /*--------------------------------------------------------------------------------------*/

        #region Subject
        private void btnEditSubject_Click_1(object sender, EventArgs e)
        {
            string name = txtNameSubject.Text;
            int makhoa; int id;int tinchi;
            int.TryParse(txtIDSubject.Text, out id);
            int.TryParse(txtIDFacultySubject.Text, out makhoa);
            int.TryParse(txtTinChi.Text, out tinchi);
            if (id == 13)
            {
                MessageBox.Show("Không thể xóa môn học Mon Tam này");
            }
            else
            {
                EditSubject(name, makhoa, id, tinchi);
                cbFacultyInSubject_TextChanged(sender, e);
                cbSubjectInScore_TextChanged(sender, e);
            }
        }

        private void btnAddSubject_Click_1(object sender, EventArgs e)
        {
            string name = txtNameSubject.Text;
            int makhoa;
            int tinchi;
            int.TryParse(txtIDFacultySubject.Text, out makhoa);
            int.TryParse(txtTinChi.Text, out tinchi);
            
            AddSubject(name, makhoa,tinchi);
            cbFacultyInSubject_TextChanged(sender, e);
            cbSubjectInScore_TextChanged(sender, e);
        }

        private void btnDeleteSubject_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa môn này không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                int id;
                int.TryParse(txtIDSubject.Text, out id);
                if (id == 13)
                {
                    MessageBox.Show("Không thể xóa môn học Mon Tam này");
                }
                else
                {
                    try
                    {

                        DeleteScoreByIDSubjectt(id);
                        DeleteSubject(id);
                        cbFacultyInSubject_TextChanged(sender, e);
                        cbSubjectInScore_TextChanged(sender, e);
                    }
                    catch { MessageBox.Show("Không thể xóa môn này"); }
                }
            }
        }

        private void btnSearchSubjectByName_Click(object sender, EventArgs e)
        {
            SeachSubjectByName(txtSearchSubjectByName.Text);
        }


        private void btnShowSubject_Click_1(object sender, EventArgs e)
        {
            LoadSubjectList();
        }

        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region Teacher
        private void btnShowTeacher_Click(object sender, EventArgs e)
        {
            LoadTeacher();
        }

        private void btnSearchTeacher_Click(object sender, EventArgs e)
        {
            SeachTeacherByName(txtSearchTeacher.Text);
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameTeacher.Text;
                int malop, mamonhoc, makhoa;
                int.TryParse(txtIdClassInTeacher.Text, out malop);
                int.TryParse(txtIdSubjectInTeacher.Text, out mamonhoc);
                int.TryParse(txtIdFacultyINTeacher.Text, out makhoa);
                if (malop == 0)
                {
                    AddTeacherNoIDClass(name, mamonhoc, makhoa);
                }
                else
                {
                    AddTeacher(name, malop, mamonhoc, makhoa);
                }
                cbFacultyInTeacher_TextChanged(sender, e);
            }
            catch
            {
                MessageBox.Show("Thêm giáo viên thất bại\nVui lòng kiểm tra lại thông tin", "Thông báo");   
            }
        }

        private void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(txtIdTeacher.Text, out id);
            DeleteTeacher(id);
            cbFacultyInTeacher_TextChanged(sender, e);

        }

        private void btnEditTeacher_Click(object sender, EventArgs e)
        {

            string name = txtNameTeacher.Text;
            int malop, mamonhoc, makhoa, id;
            
            int.TryParse(txtIdSubjectInTeacher.Text, out mamonhoc);
            int.TryParse(txtIdTeacher.Text, out id);
            int.TryParse(txtIdFacultyINTeacher.Text, out makhoa);
            int.TryParse(txtIdClassInTeacher.Text, out malop);
            if (malop== 0)
            {
                EditTeacher(id, name, mamonhoc, makhoa);
            }
            else
            {
               
                EditTeacher(id, name, malop, mamonhoc, makhoa);
            }
            cbFacultyInTeacher_TextChanged(sender, e);

        }
        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region Class

        private void btnSearchClassByName_Click(object sender, EventArgs e)
        {
            SeachClassByName(txtSearchClassByName.Text);
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            try
            {
               
                string name = txtNameClass.Text;
                string nameFaculty = cbFacultyInClass.Text;
                AddClass(name, nameFaculty);
                cbFacultyInClass_TextChanged(sender, e);
                LoadClassInTeacher();
                LoadStudentByNameClass();
                LoadNameClassInScore();

            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa lớp này không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                try
                {

                    int idclass;
                    int.TryParse(txtClassID.Text, out idclass);

                    {

                        try
                        {
                            ScoresDAO.Instance.DeleteScoresByIDClass(idclass);
                            StudentDAO.Instance.DeleteStudentbyIdClass(idclass);
                            cbFacultyInClass_TextChanged(sender, e);
                        }
                        catch { }

                        DeleteClass(idclass);
                        cbFacultyInClass_TextChanged(sender, e);
                        LoadClassInTeacher();
                        LoadStudentByNameClass();
                        LoadNameClassInScore();
                    }




                }
                catch { MessageBox.Show("Không thể xóa lớp này", "Thông báo"); }
            }
        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(txtClassID.Text, out id);
           
                try
                {
                    string name = txtNameClass.Text;
                    int makhoa;

                    int.TryParse(txtIDFacultyClass.Text, out makhoa);
                    EditClass(name, makhoa, id);
                    cbFacultyInClass_TextChanged(sender, e);
                    LoadStudentByNameClass();
                    LoadNameClassInScore();

                }
                catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
            
        }

        private void btnShowClass_Click_1(object sender, EventArgs e)
        {
            LoadClassList();
        }
        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region Scores
        private void btnShowScores_Click_1(object sender, EventArgs e)
        {
            LoadScoresList();
        }

        private void btnEditScore_Click(object sender, EventArgs e)
        {
            try
            {
                int idhocsinh;
                int.TryParse(txtScoreIDStudent.Text, out idhocsinh);
                int idmonhoc;
                int.TryParse(txtScoreIDSubject.Text, out idmonhoc);
                float diem15p;
                float.TryParse(txtScore15m.Text, out diem15p);
                float diem1tiet;
                float.TryParse(txtScore45m.Text, out diem1tiet);
                float diemthi;
                float.TryParse(txtScoreTest.Text, out diemthi);
                float diemtb;
                float.TryParse(txtScoreMedium.Text, out diemtb);
                EditScore(idhocsinh, idmonhoc, diem15p, diem1tiet, diemthi, diemtb);
                cbCLassInScore_TextChanged(sender, e);
                cbSubjectInScore_TextChanged(sender, e);

            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
        }

        private void btnDeleteScore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa điểm này không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                try
                {
                    int idhocsinh;
                    int.TryParse(txtScoreIDStudent.Text, out idhocsinh);
                    int idmonhoc;
                    int.TryParse(txtScoreIDSubject.Text, out idmonhoc);

                    DeleteScore(idhocsinh, idmonhoc);
                    cbCLassInScore_TextChanged(sender, e);
                    cbSubjectInScore_TextChanged(sender, e);
                }
                catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
            }
        }

        private void btnAddScores_Click(object sender, EventArgs e)
        {
            try
            {
                int idhocsinh;
                int.TryParse(txtScoreIDStudent.Text, out idhocsinh);
                int idmonhoc;
                int.TryParse(txtScoreIDSubject.Text, out idmonhoc);
                float diem15p;
                float.TryParse(txtScore15m.Text, out diem15p);
                float diem1tiet;
                float.TryParse(txtScore45m.Text, out diem1tiet);
                float diemthi;
                float.TryParse(txtScoreTest.Text, out diemthi);
                float diemtb;
                float.TryParse(txtScoreMedium.Text, out diemtb);
                AddScore(idhocsinh, idmonhoc, diem15p, diem1tiet, diemthi, diemtb);
            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
        }


        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region textchange
        private void cbFacultyInClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameFacylty = cbFacultyInClass.Text;

        }
        private void cbFacultyInTeacher_TextChanged(object sender, EventArgs e) //Load danh sách giáo viên được phân theo khoa
        {
            string nameFaculty = cbFacultyInTeacher.Text;
            listTeacher.DataSource = TeacherDAO.Instance.SearchTeacherByNameFaculty(nameFaculty);
        }

       
        
        
        //Load danh sách điểm theo tên lớp và tên môn học
        private void cbCLassInScore_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string nameclass = cbCLassInScore.Text;
                string name = cbSubjectInScore.Text;
                listScores.DataSource = ScoresDAO.Instance.LoadScoresListByNameClassAndNameSubject(nameclass, name);
                LoadStudentInScore(nameclass);

            }
            catch { }
        }
        //Load danh sách điểm theo tên lớp và tên môn học
        private void cbSubjectInScore_TextChanged(object sender, EventArgs e)
        {
            try
            {
              
                string nameclass = cbCLassInScore.Text;
                string name = cbSubjectInScore.Text;
                listScores.DataSource = ScoresDAO.Instance.LoadScoresListByNameClassAndNameSubject(nameclass, name);
               
            }
            catch { }
        }
        private void cbFacultyInSubject_TextChanged(object sender, EventArgs e)
        {
            string name = cbFacultyInSubject.Text.ToString();
            listSubject.DataSource = SubjectDAO.Instance.LoadSubjectListByNameFaculty(name);
        }
        private void cbFacultyInClass_TextChanged(object sender, EventArgs e)
        {
            string name = cbFacultyInClass.Text.ToString();
            listClass.DataSource = ClassDAO.Instance.LoadClassListInFacultyName(name);
        }
        private void cbShowStudentByClass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string name = cbShowStudentByClass.Text.ToString();
                liststudent.DataSource = StudentDAO.Instance.LoadStudentListByNameClass(name);
            }
            catch { }
        }
        private void txtScoreIDStudent_TextChanged_2(object sender, EventArgs e)
        {
            try
            {
                //int id = (int)dtgvScores.SelectedCells[0].OwningRow.Cells["IDHocSinh"].Value;

                //Student student = StudentDAO.Instance.GetStudentID(id);

                //foreach (Student item in StudentDAO.Instance.LoadStudentList())
                //{
                //    if (item.ID == student.ID)
                //    {
                //        txtScoreNameStudent.Text = student.Name;
                //        break;
                //    }

                //}
            }
            catch { }
        }

        private void txtScoreIDSubject_TextChanged_2(object sender, EventArgs e)
        {
            //try
            //{
            //    int id=0;
                
            //      id  = (int)dtgvScores.SelectedCells[0].OwningRow.Cells["IDMonHoc"].Value;
               
            //        Subject subject = SubjecDAO.Instance.GetSubjectID(id);
            //        int i = 0;
            //        foreach (Subject item in SubjecDAO.Instance.LoadSubjectList())
            //        {
            //            if (item.ID == subject.ID)
            //            {
            //                txtScoreNameSubject.Text = subject.Name;
            //                break;
            //            }
            //            i++;
            //        }
                
            //}
            //catch { }
        }

        private void txtIDFacultyClass_TextChanged_2(object sender, EventArgs e)
        {
            try
            {

                //int id = (int)dtgvClass.SelectedCells[0].OwningRow.Cells["IDFaculty"].Value;

                //Faculty faculty = FacultyDAO.Instance.GetFacultyID(id);
                //cbNameFacultyClass.SelectedItem = faculty;

                //int index = -1;
                //int i = 0;
                //foreach (Faculty item in cbNameFacultyClass.Items)
                //{
                //    if (item.ID == faculty.ID)
                //    {
                //        index = i;
                //        break;
                //    }
                //    i++;
                //}
                //cbNameFacultyClass.SelectedIndex = index;
            }
            catch { }
        }

        private void txtIDFacultySubject_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dtgvSubject.SelectedCells[0].OwningRow.Cells["IDFaculty"].Value;

                Faculty faculty = FacultyDAO.Instance.GetFacultyID(id);
                cbNameFacultySubject.SelectedItem = faculty;

                int index = -1;
                int i = 0;
                foreach (Faculty item in cbNameFacultySubject.Items)
                {
                    if (item.ID == faculty.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbNameFacultySubject.SelectedIndex = index;
            }
            catch { }
        }



        #endregion
        /*--------------------------------------------------------------------------------------*/

        #region teaching_class
       



        private void btnDeleteTeaching_class_Click(object sender, EventArgs e)
        {
            int idteacher;
            int.TryParse(txtIdTeacherInTeaching_class.Text, out idteacher);
            int idclass;
            int.TryParse(txtIDClassInTeaching_Class.Text, out idclass);

            DeleteTeaching_Class(idteacher, idclass);
            LoadTeaching_class();
        }
        private void txtIDClassInTeaching_Class_TextChanged(object sender, EventArgs e)
        {

        }
       
        #endregion

        #endregion
    }
}
