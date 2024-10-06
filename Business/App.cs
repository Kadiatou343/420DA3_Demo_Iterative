using _420DA3_Demo_Iterative.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_Demo_Iterative.Business
{
    internal class App
    {
        private StudentService studentService;

        public App() 
        {
            ApplicationConfiguration.Initialize();
            this.studentService = new StudentService();
        }

        public void Start()
        {
            Application.Run(this.studentService.window);
        }
    }
}
