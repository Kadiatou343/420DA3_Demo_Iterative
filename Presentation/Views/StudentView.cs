using _420DA3_Demo_Iterative.Services;
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
    public partial class StudentView : Form
    {
        private StudentService studentService;
        public StudentView(StudentService service)
        {
            this.studentService = service;
            InitializeComponent();
            this.tableView.DataSource = this.studentService.GetStudentTable();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.studentService.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.studentService.ReloadStudentTable();
        }
    }
}
