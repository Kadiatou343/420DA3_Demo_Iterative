using _420DA3_Demo_Iterative.Business.Services;
using _420DA3_Demo_Iterative.Presentation;
using _420DA3_Demo_Iterative.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_Demo_Iterative.Business
{
    public class App
    {
        public StudentService studentService;
        public CourseServices courseServices;
        private MainMemu mainMenu;

        public App() 
        {
            ApplicationConfiguration.Initialize();
            this.studentService = new StudentService();
            this.courseServices = new CourseServices();
            this.mainMenu = new MainMemu(this);
        }

        public void Start()
        {
            Application.Run(this.mainMenu);
        }
    }
}
