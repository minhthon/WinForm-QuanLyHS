using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using QuanLyHocSinh.DAO;
using QuanLyHocSinh.DTO;
using static QuanLyHocSinh.fAccountProfile;

namespace QuanLyHocSinh
{
    public partial class fChinh : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); GetIDTeacher(loginAccount.IdGiaoVien); }
        }

        public fChinh(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;      
         

        }
        private void fChinh_Load(object sender, EventArgs e)
        {
            trangChủToolStripMenuItem_Click(sender, e); 
        }
        private bool CheckExistForm(string name)//Kiểm tra các form con đang hiển thị trong Form cha.
        {
            bool check = false;
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name==name)
                {
                    check = true;
                    break;
                }
            }    return check;
        }
        private void ActiveChildForm(string name)//hiển thị lên trên cùng các trong số các Form Con nếu nó đã hiện mà không phải tạo thể hiện mới.
        {
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name==name)
                {
                    frm.Activate();
                    break;
                }    
            }    
        }
        void ChangeAccount(int type)
        {
            thêmLớpGiảngDạyChoGiáoViênToolStripMenuItem.Enabled = type == 1;
            báoCáoToolStripMenuItem.Enabled = type == 1;
            quảnLýToolStripMenuItem.Enabled = type == 1;
            giáoViênToolStripMenuItem.Enabled = type == 2;  
            tàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";


        }
        public int GetIDTeacher(int id)
        {

            int idTeacher = id;
            return idTeacher;
        }

        void f_UpdateAccount(object sender, AccountEvent e)//Updete tên hiển thị sao khi cập nhật.
        {
            tàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }



        #region ToolStrip
        private void thêmLớpGiảngDạyChoGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fAddTeachingClass"))
            {
                fAddTeachingClass f = new fAddTeachingClass();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("fAddTeachingClass");
        }
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fHome"))
            {
                fHome f = new fHome();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("fHome");
        }
        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fAdmin"))
            {
                fAdmin ff = new fAdmin();
                ff.loginAccount = loginAccount;
                ff.MdiParent = this;
                ff.Show();              
            }
            else ActiveChildForm("fAdmin");
        }
        private void giáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fTeacher"))
            {
                fTeacher f = new fTeacher(loginAccount);
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("fTeacher");

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fAccountProfile"))
            {
                fAccountProfile f = new fAccountProfile(LoginAccount);
                f.UpdateAccount += f_UpdateAccount;
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("fAccountProfile");
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fReport"))
            {
                fReport f = new fReport();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("fReport");
        }

        #endregion //end ToolStrip

       
        #region Shotcut
        private void mởTrangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trangChủToolStripMenuItem_Click(sender, e);
        }
        private void mởTrangQuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quảnLýToolStripMenuItem_Click(sender, e);
        }

        private void mởTrangGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giáoViênToolStripMenuItem_Click(sender, e);
        }

        private void mởTrangBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            báoCáoToolStripMenuItem_Click(sender, e);
        }

        private void thêmLớpGiảngDạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thêmLớpGiảngDạyChoGiáoViênToolStripMenuItem_Click(sender, e);
        }

        #endregion


    }
}
