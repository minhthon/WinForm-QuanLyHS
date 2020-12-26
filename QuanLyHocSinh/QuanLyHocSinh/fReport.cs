using CrystalDecisions.CrystalReports.Engine;
using QuanLyHocSinh.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class fReport : Form
    {
        public fReport()
        {
            InitializeComponent();
            LoadNameClass();
            LoadSubject();
            ReportClass();
            ReportTeacher();
        }

        private void fReport_Load(object sender, EventArgs e)
        {
           

        }
      
        void LoadSubject()
        {
            cbSubject.DataSource = SubjectDAO.Instance.LoadSubjectList();
            cbSubject.DisplayMember = "name";
        }
        void LoadNameClass()
        {
            cbClass.DataSource = ClassDAO.Instance.LoadClassList();
            cbClass.DisplayMember = "name";
            cbClassInScore.DataSource = ClassDAO.Instance.LoadClassList();
            cbClassInScore.DisplayMember = "name";

        }
        void ReportTeacher()
        {
            DataTable dt;
            FileReport.Teacher rpt = new FileReport.Teacher();

            dt = TeacherDAO.Instance.LoadTeacherReport();
            rpt.SetDataSource(dt);
           cryTeacher.ReportSource = rpt;
        }
      void ReportClass()
        {
            DataTable dt;
            FileReport.Class rpt = new FileReport.Class();

            dt = ClassDAO.Instance.LoadClassReport();
            rpt.SetDataSource(dt);
            cryClass.ReportSource = rpt;
        }


        private void cbClass_TextChanged(object sender, EventArgs e)
        {
            string nameClass = cbClass.Text;

            DataTable dt;
            FileReport.HocSinh rpt = new FileReport.HocSinh();

            dt = StudentDAO.Instance.LoadSudentReport(nameClass);
            rpt.SetDataSource(dt);
            cryStudent.ReportSource = rpt;
        }

        private void cbClassInScore_TextChanged(object sender, EventArgs e)
        {
            string nameclass = cbClassInScore.Text;
            string namesubject = cbSubject.Text;
            DataTable dt;
            FileReport.Score rpt = new FileReport.Score();
            dt = ScoresDAO.Instance.LoadScoreReportByAdmin(nameclass, namesubject);
            rpt.SetDataSource(dt);
            cryScore.ReportSource = rpt;



        }

        private void cbSubject_TextChanged(object sender, EventArgs e)
        {
            string nameclass = cbClassInScore.Text;
            string namesubject = cbSubject.Text;
            DataTable dt;
            FileReport.Score rpt = new FileReport.Score();
            dt = ScoresDAO.Instance.LoadScoreReportByAdmin(nameclass, namesubject);
            rpt.SetDataSource(dt);
            cryScore.ReportSource = rpt;
        }
    }
}
