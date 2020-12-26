using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinh.DAO;
using QuanLyHocSinh.DTO;

namespace QuanLyHocSinh
{
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();
            LoadTreeSystem();
            Hienthingaygio();            
        }
        void Hienthingaygio()
        {
            DateTime d1 = DateTime.Now;
            listBox1.Items.Add("Năm: " + d1.Year);
            listBox1.Items.Add("Tháng: " + d1.Month);
            listBox1.Items.Add("Ngày: " + d1.Day);
            listBox1.Items.Add("Ngày trong tuần: " + d1.DayOfWeek);
            listBox1.Items.Add("Ngày trong năm: " + d1.DayOfYear);
            listBox1.Items.Add("Thời gian mở ứng dụng: " + d1.TimeOfDay);

        }
        #region Search
        List<Subject> SearchSubjectByName(string name)
        {
            List<Subject> listSubject = SubjectDAO.Instance.SearchSubjectByName(name);

            return listSubject;
        }
        List<Class> SearchClassByName(string name)
        {
            List<Class> listClass = ClassDAO.Instance.SearchClasstByName(name);
            return listClass;
        }

        List<Faculty> SearchFacultyByName(string name)
        {
            List<Faculty> listFaculty = FacultyDAO.Instance.SearchFacultyByName(name);
            return listFaculty;
        }
        List<Student> SearchStudentByName(string name)
        {
            List<Student> listStudent = StudentDAO.Instance.SearchStudentByName(name);
            return listStudent;
        }
        #endregion
        void LoadTreeSystem()
        {
            List<Faculty> listFaculty = FacultyDAO.Instance.LoadFacultyList();
            List<Class> listClass = ClassDAO.Instance.LoadClassList();
            List<Student> listStudent = StudentDAO.Instance.LoadStudentList();

            for (int i = 0; i < listFaculty.Count; i++)
            {


                int idFaculty = listFaculty[i].ID;
                string nameFaculty = listFaculty[i].Name;
                TreeNode nodeFaculty = new TreeNode(nameFaculty);
                nodeFaculty.Tag = idFaculty;
                tvSystem.Nodes.Add(nodeFaculty);
                for (int j = 0; j < listClass.Count; j++)

                {


                    int idFacultyClass = listClass[j].IDFaculty;
                    int idClass = listClass[j].ID;
                    string nameClass = listClass[j].Name;
                    if (idFaculty == idFacultyClass)
                    {
                        TreeNode nodeClass = new TreeNode(nameClass);
                        nodeClass.Tag = idClass;
                        nodeFaculty.Nodes.Add(nodeClass);

                        for (int a = 0; a < listStudent.Count; a++)
                        {
                            int idClassStudent = listStudent[a].MaLop;
                            string nameStudent = listStudent[a].Name;
                            int idStudent = listStudent[a].ID;
                            if (idClass == idClassStudent)
                            {
                                TreeNode nodeStudent = new TreeNode(nameStudent);
                                nodeStudent.Tag = idStudent;
                                nodeClass.Nodes.Add(nodeStudent);

                            }
                        }
                    }
                }

            }

        }
        void LoadStudentList()
        {
            dtgvSystem.Columns.Clear();
            dtgvSystem.DataSource = StudentDAO.Instance.LoadStudentList();
            dtgvSystem.Columns["id"].HeaderText = "Mã số học sinh";
            dtgvSystem.Columns["name"].HeaderText = "Họ tên học sinh";
            dtgvSystem.Columns["Ngaysinh"].HeaderText = "Ngày sinh";
            dtgvSystem.Columns["gioitinh"].HeaderText = "Giới tính";
            dtgvSystem.Columns["Diachi"].HeaderText = "Địa chỉ";
            dtgvSystem.Columns["Malop"].HeaderText = "Mã lớp";

        }
       
        public int GetIDTeacher(int id)
        {

            int idTeacher = id;
            return idTeacher;
        }

        private void fChinh_Load(object sender, EventArgs e)
        {

        }




        #region Event

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblWatch1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

      
        private void tvSystem_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Level == 0)
                {
                    int idFaculty = int.Parse(e.Node.Tag.ToString());
                    List<Class> listClass = new List<Class>();
                    listClass = ClassDAO.Instance.SearchClassByID(idFaculty);

                    dtgvSystem.DataSource = listClass;
                    dtgvSystem.Columns["id"].HeaderText = "Mã lóp";
                    dtgvSystem.Columns["name"].HeaderText = "Tên lóp";
                    dtgvSystem.Columns["idFaculty"].HeaderText = "Mã khoa";

                }
                if (e.Node.Level == 1)
                {
                    int idClass = int.Parse(e.Node.Tag.ToString());
                    List<Student> listStudent = new List<Student>();
                    listStudent = StudentDAO.Instance.SearchStudentByIDFaculty(idClass);
                    dtgvSystem.DataSource = listStudent;
                    dtgvSystem.Columns["id"].HeaderText = "Mã số học sinh";
                    dtgvSystem.Columns["name"].HeaderText = "Họ tên học sinh";
                    dtgvSystem.Columns["Ngaysinh"].HeaderText = "Ngày sinh";
                    dtgvSystem.Columns["gioitinh"].HeaderText = "Giới tính";
                    dtgvSystem.Columns["Diachi"].HeaderText = "Địa chỉ";
                    dtgvSystem.Columns["Malop"].HeaderText = "Mã lớp";
                }
                if (e.Node.Level == 2)
                {
                    try
                    {
                        int idStudent = int.Parse(e.Node.Tag.ToString());
                        List<Scores> listScore = new List<Scores>();
                        listScore = ScoresDAO.Instance.SearchScoreByID(idStudent);
                        dtgvSystem.DataSource = listScore;
                        dtgvSystem.Columns["idhocsinh"].HeaderText = "Mã học sinh";
                        dtgvSystem.Columns["idmonhoc"].HeaderText = "Mã môn học";
                        dtgvSystem.Columns["diemchuyencan"].HeaderText = "Điểm chuyên cần";
                        dtgvSystem.Columns["diemtrungbinhkiemtra"].HeaderText = "Điểm trung bình kiểm tra";
                        dtgvSystem.Columns["diemthi"].HeaderText = "Điểm thi";
                        dtgvSystem.Columns["diemtrungbinh"].HeaderText = "Điểm trung bình";
                        dtgvSystem.Columns["tenhocsinh"].HeaderText = "Tên học sinh";
                        dtgvSystem.Columns["tenmonhoc"].HeaderText = "Tên môn học";
                    }
                    catch { }
                }
            }

        }

        private void btnSearchClass_Click_1(object sender, EventArgs e)
        {
            try
            {
                dtgvSystem.DataSource = SearchClassByName(txtSearchName.Text);
                txtSearchName.Text = "";

            }
            catch { MessageBox.Show("Có lỗi xảy ra khi thực hiện tìm kiếm"); }
        }

        private void btnShowClass_Click(object sender, EventArgs e)
        {
            dtgvSystem.Columns.Clear();
            dtgvSystem.DataSource = ClassDAO.Instance.LoadClassList();
            dtgvSystem.Columns["id"].HeaderText = "Mã lóp";
            dtgvSystem.Columns["name"].HeaderText = "Tên lóp";
            dtgvSystem.Columns["idFaculty"].HeaderText = "Mã khoa";

        }

        private void btnShowFaculty_Click(object sender, EventArgs e)
        {
            dtgvSystem.Columns.Clear();

            dtgvSystem.DataSource = FacultyDAO.Instance.LoadFacultyList();
            dtgvSystem.Columns["name"].HeaderText = "Tên khoa";
            dtgvSystem.Columns["id"].HeaderText = "Mã khoa";
        }

        private void btnShowSubject_Click(object sender, EventArgs e)
        {
            dtgvSystem.Columns.Clear();
            dtgvSystem.DataSource = SubjectDAO.Instance.LoadSubjectList();
            dtgvSystem.Columns["id"].HeaderText = "Mã môn học";
            dtgvSystem.Columns["name"].HeaderText = "Tên môn học";
            dtgvSystem.Columns["idFaculty"].HeaderText = "Mã khoa";
        }

        private void btnSearchStudent_Click_1(object sender, EventArgs e)
        {
            try
            {
                dtgvSystem.DataSource = SearchStudentByName(txtSearchName.Text);
                txtSearchName.Text = "";
            }
            catch { MessageBox.Show("Có lỗi xảy ra khi thực hiện tìm kiếm"); }

        }

        private void dtgvSystem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearchFaculty_Click_1(object sender, EventArgs e)
        {
            try
            {
                dtgvSystem.DataSource = SearchFacultyByName(txtSearchName.Text);
                txtSearchName.Text = "";

            }
            catch { MessageBox.Show("Có lỗi xảy ra khi thực hiện tìm kiếm"); }
        }

        private void btnSearchSubject_Click_1(object sender, EventArgs e)
        {
            try
            {
                dtgvSystem.DataSource = SearchSubjectByName(txtSearchName.Text);
                txtSearchName.Text = "";

            }
            catch { MessageBox.Show("Có lỗi xảy ra khi thực hiện tìm kiếm"); }
        }


        #endregion

     
    }
}
