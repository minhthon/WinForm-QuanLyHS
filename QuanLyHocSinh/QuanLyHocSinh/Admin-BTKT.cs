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
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class fAdmin : Form
    {
        BindingSource listAccount = new BindingSource();
        BindingSource liststudent = new BindingSource();
        BindingSource listFaculty = new BindingSource();
        BindingSource listClass = new BindingSource();
        BindingSource listScores = new BindingSource();
        BindingSource listSubject = new BindingSource();
        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            dtgvAccount.DataSource = listAccount;
            dtgvHocSinh.DataSource = liststudent;
            dtgvFaculty.DataSource = listFaculty;
            dtgvClass.DataSource = listClass;
            dtgvScores.DataSource = listScores;
            dtgvSubject.DataSource = listSubject;
            LoadStudentList();
            LoadFacultylist();
            LoadClassList();
            LoadScoresList();
            LoadListAccount();
            StudentBinding();
            AccountBinding();
            FacultyBinding();
            LoadSubjectList();
            SubjectBinding();
            ClassBinding();
            ScoresBinding();
          
            LoadFacultyIntoCombox(cbNameFacultySubject);
            LoadFacultyIntoCombox(cbNameFacultyClass);
           
        }

        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/

        #region methods
        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
        #region Scores
     
        void AddScore(int idhocsinh, int idmonhoc, float diem15p, float diem1tiet, float diemthi,float diemtb)
        {
            if (ScoresDAO.Instance.AddScores(idhocsinh,idmonhoc,diem15p,diem1tiet,diemthi,diemtb))
            {
                MessageBox.Show("Thêm điểm thành công");
            }
            else
            {
                MessageBox.Show("Thêm điểm thất bại");
            }
            LoadScoresList();
        }
        void EditScore(int idhocsinh, int idmonhoc, float diem15p, float diem1tiet, float diemthi,float diemtb)
        {
            if (ScoresDAO.Instance.EditScores(idhocsinh, idmonhoc, diem15p, diem1tiet,  diemthi,diemtb))
            {
                MessageBox.Show("Sửa thông tin điểm thành công");
            }
            else
            {
                MessageBox.Show("Sửa thông tin điểm thất bại");
            }
            LoadScoresList();
        }
        void DeleteScore(int idhocsinh, int idmonhoc)
        {
            if (ScoresDAO.Instance.DeleteScores(idhocsinh, idmonhoc))
            {
                MessageBox.Show("Xóa điểm thành công");
            }
            else
            {
                MessageBox.Show("Xóa điểm thất bại");
            }
            LoadScoresList();
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
        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
        #region Class
        void SeachClassByName(string name)
        {
            listClass.DataSource = ClassDAO.Instance.SearchClasstByName(name);
        }
        void AddClass(string name, int makhoa)
        {
            if (ClassDAO.Instance.AddClass(name, makhoa))
            {
                MessageBox.Show("Thêm lớp thành công");
            }
            else
            {
                MessageBox.Show("Thêm lớp thất bại");
            }
            LoadClassList();
        }
        void EditClass(string name, int makhoa, int id)
        {
            if (ClassDAO.Instance.EditClass(id, name, makhoa))
            {
                MessageBox.Show("Sửa thông tin lớp thành công");
            }
            else
            {
                MessageBox.Show("Sửa thông tin lớp thất bại");
            }
            LoadClassList();
        }
        void DeleteClass(int id)
        {
            if (ClassDAO.Instance.DeleteClass(id))
            {
                MessageBox.Show("Xóa lớp thành công");
            }
            else
            {
                MessageBox.Show("Xóa lớp thất bại");
            }
            LoadClassList();
        }
        #endregion
        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
        #region Subject
        void SeachSubjectByName(string name)
        {
            listSubject.DataSource = SubjecDAO.Instance.SearchSubjectByName(name);

        }
        void AddSubject(string name,int makhoa)
        {
            if (SubjecDAO.Instance.AddSuibject(name,makhoa))
            {
                MessageBox.Show("Thêm môn học thành công");
            }
            else
            {
                MessageBox.Show("Thêm môn học thất bại");
            }
            LoadSubjectList();
        }
        void EditSubject(string name,int makhoa,int id)
        {
            if (SubjecDAO.Instance.EditSubject(id, name,makhoa))
            {
                MessageBox.Show("Sửa môn học thành công");
            }
            else
            {
                MessageBox.Show("Sửa môn học thất bại");
            }
            LoadSubjectList();
        }
        void DeleteSubject(int id)
        {
            if (SubjecDAO.Instance.DeleteSubject(id))
            {
                MessageBox.Show("Xóa môn học thành công");
            }
            else
            {
                MessageBox.Show("Xóa môn học thất bại");
            }
            LoadSubjectList();
        }
      



        #endregion

        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
        #region Faculty
        void SeachFacultyByName(string name)
        {
            listFaculty.DataSource = FacultyDAO.Instance.SearchFacultyByName(name);
        }
        void AddFaculty(string name)
        {
            if (FacultyDAO.Instance.AddFaculty(name))
            {
                MessageBox.Show("Thêm khoa thành công");
            }
            else
            {
                MessageBox.Show("Thêm khoa thất bại");
            }
            LoadFacultylist();
        }
        void EditFaculty(string name, int id)
        {
            if (FacultyDAO.Instance.EditFaculty(id, name))
            {
                MessageBox.Show("Sửa khoa thành công");
            }
            else
            {
                MessageBox.Show("Sửa khoa thất bại");
            }
            LoadFacultylist();
        }
        void DeleteFaculty(int id)
        {
            if (FacultyDAO.Instance.DeleteFaculty(id))
            {
                MessageBox.Show("Xóa khoa thành công");
            }
            else
            {
                MessageBox.Show("Xóa khoa thất bại");
            }
            LoadFacultylist();
        }


        #endregion

        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
        #region Student
                    void SeachStudentByName(string name)
                    {
                        liststudent.DataSource= StudentDAO.Instance.SearchStudentByName(name);
                       
                        
                    }
                    void AddStudent(string name, DateTime ngaysinh, int gioitinh, string diachi, int malop)
                    {
                        if (StudentDAO.Instance.AddStudent(name, ngaysinh, gioitinh,diachi,malop))
                        {
                            MessageBox.Show("Thêm học sinh thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm học sinh thất bại");
                        }
                        LoadStudentList();
                    }
                    void EditStudent(string name, DateTime ngaysinh, int gioitinh, string diachi, int malop,int id)
                    {
                        if (StudentDAO.Instance.EditStudent(id,name, ngaysinh, gioitinh, diachi, malop))
                        {
                            MessageBox.Show("Sửa học sinh thành công");
                        }
                        else
                        {
                            MessageBox.Show("Sửa học sinh thất bại");
                        }
                        LoadStudentList();
                    }
                    void DeleteStudent(int id)
                    {

                        if (StudentDAO.Instance.DeleteStudent(id))
                        {
                            MessageBox.Show("Xóa học sinh thành công");
                        }
                        else
                        {
                            MessageBox.Show("Xóa học sinh thất bại");
                        }
                        LoadStudentList();
                    }

        #endregion
        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
        #region Account
     
                        void AddAccount(string username, string displayname,int type)
                        {
                            if(AccountDAO.Instance.InsertAccount(username,displayname,type))
                             {
                               MessageBox.Show("Thêm tài khoản thành công");
                             }
                            else 
                            { MessageBox.Show("Thêm tài khoản thất bại"); }
                            LoadListAccount();
                        }
        
                        void EditAccount(string username,string displayname,int type)
                        {
                            if (AccountDAO.Instance.UpdateAccount(username, displayname, type))
                            {
                                MessageBox.Show("Sửa tài khoản thành công");
                            }
                            else
                            { MessageBox.Show("Sửa tài khoản thất bại"); }
                            LoadListAccount();
                        }
                        void DeleteAccount(string username)
                        {
                            if(loginAccount.UserName.Equals(username))
                            {
                                MessageBox.Show("Bạn không thể xóa chính mình được");
                            }    
                            if (AccountDAO.Instance.DeleteAccount(username))
                            {
                                MessageBox.Show("Xóa tài khoản thành công");
                            }
                            else
                            { MessageBox.Show("Xóa tài khoản thất bại"); }
                            LoadListAccount();
                        }
                        void ResetPassword(string username)
                        {
                            if (AccountDAO.Instance.ResetPassword(username))
                            {
                                MessageBox.Show("Reset mật khẩu thành công");
                            }
                            else
                            { MessageBox.Show("Reset mật khẩu thất bại"); }
                        }
        #endregion

        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/

        #region LoadAndBinding
        private void fAdmin_Load(object sender, EventArgs e)
        {
           
            
        }

        void ScoresBinding()
        {
            txtScoreIDStudent.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "idHocsinh", true, DataSourceUpdateMode.Never));
            txtScoreIDSubject.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "idMonhoc", true, DataSourceUpdateMode.Never));
            txtScore15m.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diem15p", true, DataSourceUpdateMode.Never));
            txtScore45m.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diem1tiet", true, DataSourceUpdateMode.Never));
            txtScoreTest.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diemthi", true, DataSourceUpdateMode.Never));
            txtScoreMedium.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diemtrungbinh", true, DataSourceUpdateMode.Never));
        }
        
        void SubjectBinding()
        {
           
            txtIDSubject.DataBindings.Add(new Binding("Text", dtgvSubject.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtNameSubject.DataBindings.Add(new Binding("Text", dtgvSubject.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtIDFacultySubject.DataBindings.Add(new Binding("Text", dtgvSubject.DataSource, "IDFaculty", true, DataSourceUpdateMode.Never));

        }
        void ClassBinding()
        {
           txtClassID.DataBindings.Add(new Binding("Text", dtgvClass.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtNameClass.DataBindings.Add(new Binding("Text", dtgvClass.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtIDFacultyClass.DataBindings.Add(new Binding("Text", dtgvClass.DataSource, "IDFaculty", true, DataSourceUpdateMode.Never));
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

        }
        private void LoadListAccount()
        {
            listAccount.DataSource = AccountDAO.Instance.GetListAccount();
            dtgvAccount.Columns["Username"].HeaderText = "Tên tài khoản";
            dtgvAccount.Columns["Displayname"].HeaderText = "Tên hiển thị";
            dtgvAccount.Columns["Type"].HeaderText = "Loại tài khoản";
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
            listSubject.DataSource = SubjecDAO.Instance.LoadSubjectList();
            dtgvSubject.Columns["id"].HeaderText = "Mã môn học";
            dtgvSubject.Columns["name"].HeaderText = "Tên môn học";
            dtgvSubject.Columns["idFaculty"].HeaderText = "Mã môn khoa";

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
            dtgvScores.Columns["diem15p"].HeaderText = "Điểm 15 phút";
            dtgvScores.Columns["diem1tiet"].HeaderText = "Điểm 45  phút";
            dtgvScores.Columns["diemthi"].HeaderText = "Điểm thi";
            dtgvScores.Columns["diemtrungbinh"].HeaderText = "Điểm trung bình";


        }
        #endregion
        #endregion

        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/

        #region events

        #region Noname
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }
        private void btnShowStudent_Click(object sender, EventArgs e)
        {
            LoadStudentList();
        }
        private void btnShowCaculty_Click(object sender, EventArgs e)
        {
            LoadFacultylist();
        }



        private void txtIDSubject_TextChanged(object sender, EventArgs e)
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

        

        private void txtIDFacultyClass_TextChanged_1(object sender, EventArgs e)
        {
            int id = (int)dtgvClass.SelectedCells[0].OwningRow.Cells["IDFaculty"].Value;

            Faculty faculty = FacultyDAO.Instance.GetFacultyID(id);
            cbNameFacultyClass.SelectedItem = faculty;

            int index = -1;
            int i = 0;
            foreach (Faculty item in cbNameFacultyClass.Items)
            {
                if (item.ID == faculty.ID)
                {
                    index = i;
                    break;
                }
                i++;
            }
            cbNameFacultyClass.SelectedIndex = index;
        }

        private void txtScoreIDStudent_TextChanged(object sender, EventArgs e)//Lấy tên môn học từ ID trên textBox
        {
            try
            {
                int id = (int)dtgvScores.SelectedCells[0].OwningRow.Cells["IDHocSinh"].Value;

                Student student = StudentDAO.Instance.GetStudentID(id);
                
                foreach (Student item in StudentDAO.Instance.LoadStudentList())
                {
                    if (item.ID == student.ID)
                    {
                        txtScoreNameStudent.Text = student.Name;
                        break;
                    }
                    
                }
            }
            catch { }


        }
        private void txtScoreIDSubject_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dtgvScores.SelectedCells[0].OwningRow.Cells["IDMonHoc"].Value;

                Subject subject = SubjecDAO.Instance.GetSubjectID(id);
                int i = 0;
                foreach (Subject item in SubjecDAO.Instance.LoadSubjectList())
                {
                    if (item.ID == subject.ID)
                    {
                        txtScoreNameSubject.Text = subject.Name;
                        break;
                    }
                    i++;
                }
            }
            catch { }
        }
        #endregion

        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
        #region Account
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            DeleteAccount(username);
        }

        private void btnAddAcount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string displayname = txtDisplayName.Text;
            int type = (int)nmTypeAccount.Value;
            AddAccount(username, displayname, type);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string displayname = txtDisplayName.Text;
            int type = (int)nmTypeAccount.Value;
            EditAccount(username, displayname, type);
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
        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
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
                string name = txtNameStudent.Text;
                DateTime ngaysinh = dtpBirthdayStudent.Value;
                int gioitinh = (int)nmSexStudent.Value;
                string diachi = txtLocationStudent.Text;
                int malop;
                int.TryParse(txtIDClassStudent.Text, out malop);
                AddStudent(name, ngaysinh, gioitinh, diachi, malop);
            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!"); }
        }

        private void btnDeletesStudent_Click_1(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(txtIDStudent.Text, out id);
                try
                {
                    DeleteStudentByIDStudent(id);
                }

                catch { }
                DeleteStudent(id);

            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!"); }
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
            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!"); }
        }



        #endregion
        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
        #region Faculty
        private void btnSearchFacultyByName_Click(object sender, EventArgs e)
        {
            SeachFacultyByName(txtSearchFacultyByName.Text);
        }

        private void btnEditFaculty_Click(object sender, EventArgs e)
        {
            string name = txtNameFaculty.Text;
            int id;
            int.TryParse(txtIDFaculty.Text, out id);

            EditFaculty(name, id);
        }

        private void btnShowFaculty_Click_1(object sender, EventArgs e)
        {
            LoadFacultylist();
        }

        private void btnAddFaculty_Click(object sender, EventArgs e)
        {
            string name = txtNameFaculty.Text;
            AddFaculty(name);
        }

        private void btnDeleteFaculty_Click(object sender, EventArgs e)
        {
            //try
            //{
                int idFaculty;
                int.TryParse(txtIDFaculty.Text, out idFaculty);
            //  SubjecDAO.Instance.DeleteScorebyIDSubjectoIDFaculty(idFaculty);
            //ClassDAO.Instance.DeleteStudentbyIDClassToIDFaculty(idFaculty);
            ClassDAO.Instance.DeleteClassByIdFaculty(idFaculty);
                SubjecDAO.Instance.DeleteSubjectbyIDFaculty(idFaculty);
                
                DeleteFaculty(idFaculty);
            //}
            //catch
            //{
            //    MessageBox.Show("Error");
            //}
        }
        #endregion
        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/


        #region Subject
        private void btnEditSubject_Click_1(object sender, EventArgs e)
        {
            string name = txtNameSubject.Text;
            int makhoa; int id;
            int.TryParse(txtIDStudent.Text, out id);
            int.TryParse(txtIDFacultySubject.Text, out makhoa);
            EditSubject(name, makhoa, id);
        }

        private void btnAddSubject_Click_1(object sender, EventArgs e)
        {
            string name = txtNameSubject.Text;
            int makhoa;
            int.TryParse(txtIDFacultySubject.Text, out makhoa);
            AddSubject(name, makhoa);
        }

        private void btnDeleteSubject_Click_1(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(txtIDSubject.Text, out id);
                DeleteScoreByIDSubjectt(id);
                DeleteSubject(id);
            }
            catch { MessageBox.Show("Không thể xóa môn này"); }
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
        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/

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
                int makhoa;
                int.TryParse(txtIDFacultyClass.Text, out makhoa);
                AddClass(name, makhoa);
            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!"); }
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(txtClassID.Text, out id);
                int idclass;
                int.TryParse(txtClassID.Text, out idclass);
                if (StudentDAO.Instance.DeleteStudentbyIdClass(idclass))
                {
                    DeleteClass(id);
                }
              
            }
            catch { MessageBox.Show("Không thể xóa lớp này"); }
        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameClass.Text;
                int makhoa; int id;
                int.TryParse(txtClassID.Text, out id);
                int.TryParse(txtIDFacultyClass.Text, out makhoa);
                EditClass(name, makhoa, id);

            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!"); }
        }

        private void btnShowClass_Click_1(object sender, EventArgs e)
        {
            LoadClassList();
        }
        #endregion
        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
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
            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!"); }
        }

        private void btnDeleteScore_Click(object sender, EventArgs e)
        {
            try
            {
                int idhocsinh;
                int.TryParse(txtScoreIDStudent.Text, out idhocsinh);
                int idmonhoc;
                int.TryParse(txtScoreIDSubject.Text, out idmonhoc);

                DeleteScore(idhocsinh, idmonhoc);
            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!"); }
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
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!"); }
        }


        #endregion
        /*---------------------BTKT-------------------dev--Trần-Minh-Thon-0306181076------------*/
        #region textchange
        private void txtScoreIDStudent_TextChanged_2(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dtgvScores.SelectedCells[0].OwningRow.Cells["IDHocSinh"].Value;

                Student student = StudentDAO.Instance.GetStudentID(id);

                foreach (Student item in StudentDAO.Instance.LoadStudentList())
                {
                    if (item.ID == student.ID)
                    {
                        txtScoreNameStudent.Text = student.Name;
                        break;
                    }

                }
            }
            catch { }
        }

        private void txtScoreIDSubject_TextChanged_2(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dtgvScores.SelectedCells[0].OwningRow.Cells["IDMonHoc"].Value;

                Subject subject = SubjecDAO.Instance.GetSubjectID(id);
                int i = 0;
                foreach (Subject item in SubjecDAO.Instance.LoadSubjectList())
                {
                    if (item.ID == subject.ID)
                    {
                        txtScoreNameSubject.Text = subject.Name;
                        break;
                    }
                    i++;
                }
            }
            catch { }
        }

        private void txtIDFacultyClass_TextChanged_2(object sender, EventArgs e)
        {
            int id = (int)dtgvClass.SelectedCells[0].OwningRow.Cells["IDFaculty"].Value;

            Faculty faculty = FacultyDAO.Instance.GetFacultyID(id);
            cbNameFacultyClass.SelectedItem = faculty;

            int index = -1;
            int i = 0;
            foreach (Faculty item in cbNameFacultyClass.Items)
            {
                if (item.ID == faculty.ID)
                {
                    index = i;
                    break;
                }
                i++;
            }
            cbNameFacultyClass.SelectedIndex = index;
        }

        private void txtIDFacultySubject_TextChanged(object sender, EventArgs e)
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




        #endregion

        #endregion


    }
}
