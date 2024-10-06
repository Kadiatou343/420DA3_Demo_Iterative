using _420DA3_Demo_Iterative.Domain;
using _420DA3_Demo_Iterative.Presentation.Views;
using Data_Access_Module.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_Demo_Iterative.Services
{
    public class StudentService
    {
        private StudentDAO dao;
        public StudentView window;

        public StudentService()
        {
            this.dao = new StudentDAO();
            this.window = new StudentView(this);
        }

        public void OpenStudentWindow()
        {
            this.window.Show();
        }

        public DataTable GetStudentTable()
        {
            return this.dao.GetDataTable();
        }

        public void ReloadStudentTable()
        {
            this.dao.ReloadDataTable();
        }

        public void SaveChanges()
        {
            this.dao.SaveChanges();
        }

        /*
        public Student CreateStudent(String firstName, String lastName, String code, DateTime registrationDate)
        {
            Student student = new Student(firstName, lastName, code, registrationDate);
            return this.dao.Create(student);
        }

        public Student GetStudentById(int id)
        {
            return this.dao.GetById(id);
        }

        public List<Student> GetAllStudents() 
        {
            return this.dao.GetAll();
        }

        public Student UpdateStudent(Student student)
        {
            return this.dao.Update(student);
        }

        public void DeleteStudent(Student student)
        {
            this.dao.Delete(student);
        }

        */
    }
}
