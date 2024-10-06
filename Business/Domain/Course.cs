using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_Demo_Iterative.Domain
{
    public class Course
    {
        public const int MaxNameLength = 164;
        public const int MaxCodeLength = 15;

        private string name;
        private string code;
        public int Id { get; set; }
        public string Name { 
            get { return name; }
            set 
            { 
                if (value.Length > MaxNameLength)
                {
                    throw new Exception($"Maximum of Course.Name length is {MaxNameLength}");
                }

                this.name = value;
            }
        }
        public string Code
        {
            get { return code; }
            set
            {
                if( value.Length > MaxCodeLength)
                {
                    throw new Exception($"Maximum of Course.Code length is {MaxCodeLength}");
                }

                this.code = value;
            }
        }
        public int Duration { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Course(string name, string code, int duration)
        {
            this.Name = name;
            this.Code = code;
            this.Duration = duration;
        }

        public Course(int id, string name, string code, int duration,
            DateTime dateCreated, DateTime? dateModified, DateTime? dateDeleted) : this(name, code, duration)
        {
            this.Id = id;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
            this.DateDeleted = dateDeleted;
        }

    }
}
