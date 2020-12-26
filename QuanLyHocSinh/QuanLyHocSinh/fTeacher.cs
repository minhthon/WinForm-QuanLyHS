using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinh.DTO;
using QuanLyHocSinh.DAO;
using DevComponents.AdvTree;
using Microsoft.ReportingServices.Diagnostics.Internal;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace QuanLyHocSinh
{
    public partial class fTeacher : Form
    {
        #region ----
        BindingSource liststudent = new BindingSource();
        BindingSource listScores = new BindingSource();
      private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }

        }

        private void ChangeAccount(Account account)
        {
            txtIDTeacher.Text = loginAccount.IdGiaoVien.ToString();
            lblNameTeacher.Text = loginAccount.DisplayName;
            lblNameTeacherInStudent.Text = loginAccount.DisplayName;


        }

       
        public fTeacher(Account account)
        {
            InitializeComponent();
            LoginAccount = account;// lấy thông tin account đang đăng nhập
            dtgvStudent.DataSource = liststudent;
            dtgvScores.DataSource = listScores;
          
           
        }
        private void fTeacher_Load(object sender, EventArgs e)
        {
            LoadClassToComboBoxNameCLass();  // lấy tên các lớp của giáo viên đang giảng dạy hiện lên combo box.
            ScoresBinding();
            StudentBinding();
            cbClassInPrintScore_TextChanged(sender, e);
            cbClassInPrintStudent_TextChanged(sender,e);
            LoadNameColum();
        }
        #endregion // end----
        /* ------------------------------------------------------------------------------------ */

        #region methods
        /* ------------------------------------------------------------------------------------ */
        #region Student
        void EditStudent(string name, DateTime ngaysinh, int gioitinh, string diachi, int malop, int id)
        {
            if (StudentDAO.Instance.EditStudent(id, name, ngaysinh, gioitinh, diachi, malop))
            {
                MessageBox.Show("Cập nhật học sinh thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật học sinh thất bại", "Thông báo");
            }

        }
        #endregion
        #region Load

        void LoadNameColum()
        {
            try
            {
                try
                {
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
                catch { }
                try
                {
                    dtgvStudent.Columns["id"].HeaderText = "Mã số học sinh";
                    dtgvStudent.Columns["name"].HeaderText = "Họ tên học sinh";
                    dtgvStudent.Columns["Ngaysinh"].HeaderText = "Ngày sinh";
                    dtgvStudent.Columns["gioitinh"].HeaderText = "Giới tính";
                    dtgvStudent.Columns["Diachi"].HeaderText = "Địa chỉ";
                    dtgvStudent.Columns["Malop"].HeaderText = "Mã lớp";
                }
                catch { }
            }
            catch { }
        }
        void LoadClassToComboBoxNameCLass()// Tải tên lớp vào các combobox
        {
            string id1 =txtIDTeacher.Text;
            int id;
            int.TryParse(id1, out id);
           
            cbCLassInScore.DataSource = ClassDAO.Instance.LoadClassListByIDTeacher(id);
            cbCLassInScore.DisplayMembers = "name";
            cbClassInPrintScore.DataSource = ClassDAO.Instance.LoadClassListByIDTeacher(id);
            cbClassInPrintScore.DisplayMembers = "name";
            cbClassInPrintStudent.DataSource = ClassDAO.Instance.LoadClassListByIDTeacher(id);
            cbClassInPrintStudent.DisplayMembers = "name";


        }
        #endregion
        /* ------------------------------------------------------------------------------------ */

        #region Binding
        void StudentBinding()
        {
            try
            {

                txtIDClassStudent.DataBindings.Add(new Binding("Text",dtgvStudent.DataSource, "malop", true, DataSourceUpdateMode.Never));
                txtIDStudent.DataBindings.Add(new Binding("Text", dtgvStudent.DataSource, "ID", true, DataSourceUpdateMode.Never));
                txtNameStudent.DataBindings.Add(new Binding("Text", dtgvStudent.DataSource, "name", true, DataSourceUpdateMode.Never));
                dtpBirthdayStudent.DataBindings.Add(new Binding("Value", dtgvStudent.DataSource, "ngaysinh", true, DataSourceUpdateMode.Never));
                nmSexStudent.DataBindings.Add(new Binding("Value", dtgvStudent.DataSource, "gioitinh", true, DataSourceUpdateMode.Never));
                txtLocationStudent.DataBindings.Add(new Binding("Text", dtgvStudent.DataSource, "diachi", true, DataSourceUpdateMode.Never));

            }
            catch
            {

            }
        }

        void ScoresBinding()
        {
            try
            {
               
               txtIDStudentInScore.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "idHocsinh", true, DataSourceUpdateMode.Never));
               txtIDSubject.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "idMonhoc", true, DataSourceUpdateMode.Never));
                txtScore15m.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diemchuyencan", true, DataSourceUpdateMode.Never));
                txtScore45m.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diemtrungbinhkiemtra", true, DataSourceUpdateMode.Never));
                txtScoreTest.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diemthi", true, DataSourceUpdateMode.Never));
                txtScoreAVG.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "Diemtrungbinh", true, DataSourceUpdateMode.Never));
                txtNameStudentInScore.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "TenHocSinh", true, DataSourceUpdateMode.Never));
                txtNameSubject.DataBindings.Add(new Binding("Text", dtgvScores.DataSource, "TenMonHoc", true, DataSourceUpdateMode.Never));

            }
            catch { }
        }
        #endregion
        /* ------------------------------------------------------------------------------------ */
        #region Score


        void EditScore(int idhocsinh, int idmonhoc, float diem15p, float diem1tiet, float diemthi, float diemtb)
        {
            if (ScoresDAO.Instance.EditScores(idhocsinh, idmonhoc, diem15p, diem1tiet, diemthi, diemtb))
            {
                MessageBox.Show("Cập nhật thông tin điểm thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin điểm thất bại");
            }
          
            
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
        
        }
        #endregion // Score #endregion  
        /* ------------------------------------------------------------------------------------ */
        #endregion
        /* ------------------------------------------------------------------------------------ */

        #region Event    
        /* ------------------------------------------------------------------------------------ */

        #region TextChange
        private void cbCLassInScore_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string id1 = loginAccount.IdGiaoVien.ToString();
                int id;
                int.TryParse(id1, out id);
                string nameclass = cbCLassInScore.Text;
                string nameteacher = lblNameTeacher.Text;

                liststudent.DataSource = StudentDAO.Instance.LoadStudentListByNameClass(nameclass);
                //dtgvStudent.Columns["id"].HeaderText = "Mã số học sinh";
                //dtgvStudent.Columns["name"].HeaderText = "Họ tên học sinh";
                //dtgvStudent.Columns["Ngaysinh"].HeaderText = "Ngày sinh";
                //dtgvStudent.Columns["gioitinh"].HeaderText = "Giới tính";
                //dtgvStudent.Columns["Diachi"].HeaderText = "Địa chỉ";
                //dtgvStudent.Columns["Malop"].HeaderText = "Mã lớp";

                listScores.DataSource = ScoresDAO.Instance.LoadScoresListByIDTeacherAndNameClass(id, nameclass);

            }
            catch { }
        }
        #endregion // Textchange
        /* ------------------------------------------------------------------------------------ */

        #region Score

        private void btnDeleteScore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa điểm này không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                try
                {
                    int idhocsinh;
                    int.TryParse(txtIDStudentInScore.Text, out idhocsinh);
                    int idmonhoc;
                    int.TryParse(txtIDSubject.Text, out idmonhoc);

                    DeleteScore(idhocsinh, idmonhoc);
                }
                catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
                cbCLassInScore_TextChanged(sender, e);
            }
        }

        private void btnUpdateScore_Click(object sender, EventArgs e)
        {
            try
            {
                int idhocsinh;
                int.TryParse(txtIDStudentInScore.Text, out idhocsinh);
                int idmonhoc;
                int.TryParse(txtIDSubject.Text, out idmonhoc);
                float diem15p;
                float.TryParse(txtScore15m.Text, out diem15p);
                float diem1tiet;
                float.TryParse(txtScore45m.Text, out diem1tiet);
                float diemthi;
                float.TryParse(txtScoreTest.Text, out diemthi);
                float diemtb;
                float.TryParse(txtScoreAVG.Text, out diemtb);
                EditScore(idhocsinh, idmonhoc, diem15p, diem1tiet, diemthi, diemtb);
                cbCLassInScore_TextChanged(sender, e);
            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
        }



        #endregion // Event Score
        /* ------------------------------------------------------------------------------------ */

        #region Student
        private void btnEditStudent_Click(object sender, EventArgs e)
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
                cbCLassInScore_TextChanged(sender, e);               
            }
            catch { MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra thông tin!", "Thông báo"); }
           
        }
        #endregion
        /* ------------------------------------------------------------------------------------ */
        #region Report
        private void cbClassInPrintScore_TextChanged(object sender, EventArgs e)
        {
            string nameSubject = txtNameSubject.Text;
            string nameclass = cbClassInPrintScore.Text;
            DataTable dt;
            FileReport.Score rpt = new FileReport.Score();
            dt = ScoresDAO.Instance.LoadScoreReportByAdmin(nameclass, nameSubject);
            rpt.SetDataSource(dt);
            cryScore.ReportSource = rpt;

        }

        private void cbClassInPrintStudent_TextChanged(object sender, EventArgs e)
        {
            string nameClass = cbClassInPrintStudent.Text;

            DataTable dt;
            FileReport.HocSinh rpt = new FileReport.HocSinh();

            dt = StudentDAO.Instance.LoadSudentReport(nameClass);
            rpt.SetDataSource(dt);
            cryStudent.ReportSource = rpt;
        }
        #endregion
        #endregion//endEvent

    }
}
