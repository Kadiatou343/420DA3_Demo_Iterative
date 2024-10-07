using _420DA3_Demo_Iterative.Domain;
using _420DA3_Demo_Iterative.Presentation.Views;
using Data_Access_Module.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_Demo_Iterative.Business.Services
{
    public class CourseServices
    {
        private CourseDAO dao;
        private CourseView window;

        public CourseServices()
        {
            this.dao = new CourseDAO();
            this.window = new CourseView(this);
        }

        public void OpenCourseWindow()
        {
            this.window.ShowDialog();
        }

        public DataTable GetCourseTable()
        {
            return this.dao.GetDataTable();
        }

        public void ReloadCourseTable()
        {
            this.dao.ReloadDataTable();
        }

        public void SaveChanges()
        {
            this.dao.SaveChanges();
        }



        /*
        public Course CreateCourse(string name, string code, int duration)
        {
            Course course = new Course(name, code, duration);
            return this.dao.Create(course);
        }

        public Course GetCourseById(int id)
        {
            return this.dao.GetById(id);
        }

        public List<Course> GetAllCourses()
        {
            return this.dao.GetAll();
        }

        public Course UpdateCourse(Course course)
        {
            return this.dao.Update(course);
        }

        public void DeleteCourse(Course course)
        {
            this.dao.Delete(course);
        }

        */
    }
}
