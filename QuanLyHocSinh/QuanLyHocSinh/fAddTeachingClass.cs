using QuanLyHocSinh.DAO;
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
    public partial class fAddTeachingClass : Form
    {
        BindingSource listTeacher = new BindingSource();
        BindingSource listClass = new BindingSource();
        BindingSource listTeaching_class = new BindingSource();

        public fAddTeachingClass()
        {
            InitializeComponent();
            dtgvTeacher.DataSource = listTeacher;
            dtgvClass.DataSource = listClass;
            dtgvTeaching_class.DataSource = listTeaching_class;
            LoadListTeacher();//Tải danh sách giáo viên
            
            LoadListClass();
            LoadListTeaching_class();
            Binding();
        }
        void LoadListTeacher() // Lấy danh sách giáo viên 
        {
            listTeacher.DataSource = TeacherDAO.Instance.LoadListTeacher();
            dtgvTeacher.Columns["id"].HeaderText = "Mã giáo viên";
            dtgvTeacher.Columns["name"].HeaderText = "Tên giáo viên";
            dtgvTeacher.Columns["idclass"].HeaderText = "Mã lớp giảng dạy";
            dtgvTeacher.Columns["idSubject"].HeaderText = "Mã môn giảng dạy";

            dtgvTeacher.Columns["idFaculty"].HeaderText = "Mã Khoa";

        }
        void LoadListClass() // Lấy danh sách lớp
        {
            listClass.DataSource = ClassDAO.Instance.LoadClassList();
            dtgvClass.Columns["id"].HeaderText = "Mã lóp";
            dtgvClass.Columns["name"].HeaderText = "Tên lóp";
            dtgvClass.Columns["idFaculty"].HeaderText = "Mã khoa";
        }
      
        void LoadListTeaching_class()
        {
            listTeaching_class.DataSource = Teaching_ClassDAO.Instance.LoadListTeachering_class();
            //dtgvTeaching_class.Columns["idgiaovien"].HeaderText = "Mã giáo viên";
            //dtgvTeaching_class.Columns["idlop"].HeaderText = "Mã Lớp";
        }
        void Binding()
        {
           txtIDTecher.DataBindings.Add(new Binding("text", dtgvTeacher.DataSource, "id", true, DataSourceUpdateMode.Never));
           txtIDClass.DataBindings.Add(new Binding("text", dtgvClass.DataSource, "id", true, DataSourceUpdateMode.Never));
        }
        void Addteaching_class(int idteacher,int idclass)
        {
            if(Teaching_ClassDAO.Instance.AddTeaching_class(idteacher,idclass))
            {
                MessageBox.Show("Thêm lớp giảng dạy cho giáo viên thành công", "Thông báo!");
            }else
            {

                MessageBox.Show("Thêm lớp giảng dạy cho giáo viên thất bại\nVui lòng kiểm tra lại thông tin!", "Thông báo!");
            }
        }
        void DeleteTeaching_class(int idteacher,int idclass)
        {
            if(Teaching_ClassDAO.Instance.DeleteTeaching_class(idteacher,idclass))
            {
                MessageBox.Show("Xóa lớp giảng dạy của giáo viên thành công", "Thông báo!");
            } 
            else
            {
                MessageBox.Show("Xóa lớp giảng dạy của giáo viên thất bại", "Thông báo!");
            }    
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int idteacher;
            int.TryParse(txtIDTecher.Text, out idteacher);
            int idclass;
            int.TryParse(txtIDClass.Text, out idclass);
            Addteaching_class(idteacher, idclass);
            LoadListTeaching_class();
        }

    

        private void btnDeleteTeaching_Class_Click(object sender, EventArgs e)
        {
            int idteacher, idclass;
            int.TryParse(txtIDClass.Text, out idclass);
            int.TryParse(txtIDTecher.Text, out idteacher);
            Teaching_ClassDAO.Instance.DeleteTeaching_class(idteacher, idclass);
            LoadListTeaching_class();
        }
    }
}
