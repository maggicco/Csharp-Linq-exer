using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqObjectsAndQueryOperators
{
    class UniversityMenager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityMenager()
        {
            universities = new List<University>();
            students = new List<Student>();

            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Cambright" });

            students.Add(new Student { Id = 1, Name = "Pit", Gender = "male", Age = 35, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Pa", Gender = "female", Age = 20, UniversityId = 2 });
            students.Add(new Student { Id = 3, Name = "Piter", Gender = "male", Age = 20, UniversityId = 1 });
            students.Add(new Student { Id = 4, Name = "Alice", Gender = "female", Age = 19, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Pitt", Gender = "male", Age = 21, UniversityId = 2 });
            students.Add(new Student { Id = 6, Name = "Pitera", Gender = "female", Age = 20, UniversityId = 1 });
            students.Add(new Student { Id = 7, Name = "Yac", Gender = "male", Age = 24, UniversityId = 1 });
        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;

            Console.WriteLine("Male students: ");

            foreach (Student student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "female" select student;

            Console.WriteLine("Female students: ");

            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }

        public void SortStudentsByAge()
        {
            IEnumerable<Student> sortedStudents = from student in students orderby student.Age select student;
            Console.WriteLine("Students sorted by Age: ");

            foreach (Student student in sortedStudents)
            {
                student.Print();
            }
        }

        public void SortUniversity()
        {
            IEnumerable<University> sortedUniversities = from university in universities where university.Name == "Yale" select university;
            foreach (University university in sortedUniversities)
            {
                university.Print();
            }
        }

        public void AllStudentsFromCambright()
        {
            IEnumerable<Student> allStudentsFromCmb = from student in students join university in universities 
                                                       on student.UniversityId equals university.Id
                                                      where university.Name == "Cambright" select student;
            Console.WriteLine("Students from Cambright: ");
            foreach (Student student in allStudentsFromCmb)
            {
                student.Print();
            }
        }

        public void StudentsFromUserInput()
        {
            try
            {
                Console.WriteLine("Chose university id between 1 and 2 !");
                var input = Console.ReadLine();
                int inputId = Convert.ToInt16(input);
                Console.WriteLine("user input ; " + inputId);

                Console.WriteLine("Students from university with id = " + inputId + ":");

                IEnumerable<Student> studentsUserId = from student in students where student.UniversityId == inputId select student;

                foreach (Student student in studentsUserId)
                {
                    student.Print();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("wrong value ");
            }

        }

        public void StudentsUserChoice( int Id)
        {
            IEnumerable<Student> myStudents = from student in students
                                              join university in universities
                              on student.UniversityId equals university.Id
                                              where university.Id == Id
                                              select student;
            Console.WriteLine("Students from that uni: {0}", Id);

            foreach (Student students in myStudents)
            {
                students.Print();
            }
        }

        public void StudentAndUniversityNameCollection()
        {
            var newCollection = from student in students
                                join university in universities
                                on student.UniversityId equals university.Id
                                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };
            Console.WriteLine("New Collection :");

            foreach (var collection in newCollection)
            {
                Console.WriteLine("Student {0} from University {1} ", collection.StudentName, collection.UniversityName);
            }
        }
    }
}
