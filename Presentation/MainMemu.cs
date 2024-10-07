using _420DA3_Demo_Iterative.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _420DA3_Demo_Iterative.Presentation
{
    public partial class MainMemu : Form
    {
        private App application;
        public MainMemu(App application)
        {
            InitializeComponent();
            this.application = application;
        }

        private void buttonManageStudents_Click(object sender, EventArgs e)
        {
            this.application.studentService.OpenStudentWindow();
        }

        private void buttonManageCourses_Click(object sender, EventArgs e)
        {
            this.application.courseServices.OpenCourseWindow();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
