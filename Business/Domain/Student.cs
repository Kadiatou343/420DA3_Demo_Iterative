using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_Demo_Iterative.Domain
{
    public class Student
    {
        public const int MaxFirstNameLength = 64;
        public const int MaxLastNameLength = 64;
        public const int MaxCodeLength = 15;

        private string firstName;
        private string lastName;
        private string code;
        public int Id { get; set; }
        public string FirstName {
            get { return this.firstName; }
            set {
                if (value.Length > MaxFirstNameLength)
                {
                    throw new Exception($"Maximum of Student.FirstName is {MaxFirstNameLength}");
                }

                this.firstName = value;
            } 
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length > MaxLastNameLength)
                {
                    throw new Exception($"Maximun of Student.LastName is {MaxLastNameLength}");
                }
                this.lastName = value;
            }
        }
        public string Code {
            get { return this.code; }
            set
            {
                if (value.Length > MaxCodeLength)
                {
                    throw new Exception($"MAximum of Student.Code is {MaxCodeLength}");
                }
            }
        }
        public DateTime RegistrationDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Student(string firstName, string lastName, string code, DateTime registrationDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Code = code;
            this.RegistrationDate = registrationDate;
        }

        public Student(int id, 
            string firstName, 
            string lastName, 
            string code, 
            DateTime registrationDate, 
            DateTime dateCreated, 
            DateTime? dateModified, 
            DateTime? dateDeleted) : this(firstName, lastName, code, registrationDate)
        {
            this.Id = id;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
            this.DateDeleted = dateDeleted;
        }
    }
}
