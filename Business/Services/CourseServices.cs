using _420DA3_Demo_Iterative.Domain;
using Data_Access_Module.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_Demo_Iterative.Business.Services
{
    public class CourseServices
    {
        private CourseDAO dao;

        public CourseServices()
        {
            this.dao = new CourseDAO();
        }

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
    }
}
