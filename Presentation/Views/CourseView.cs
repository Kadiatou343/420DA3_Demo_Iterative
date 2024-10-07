using _420DA3_Demo_Iterative.Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _420DA3_Demo_Iterative.Presentation.Views
{
    public partial class CourseView : Form
    {
        private CourseServices courseServices;
        public CourseView(CourseServices courseServices)
        {
            InitializeComponent();
            this.courseServices = courseServices;
            this.tableView.DataSource = this.courseServices.GetCourseTable();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.courseServices.SaveChanges();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            this.courseServices.ReloadCourseTable();
        }
    }
}
