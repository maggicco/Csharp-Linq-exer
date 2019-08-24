using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqObjectsAndQueryOperators
{
    class Student
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Gender { get; set; }
        public int Age{ get; set; }

        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine("Student {0} with Id {1}, gender {2} and Age {3} from University {4}",Name, Id, Gender, Age, UniversityId);
        }
    }
}
