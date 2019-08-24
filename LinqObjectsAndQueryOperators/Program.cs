using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqObjectsAndQueryOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityMenager um = new UniversityMenager();
            um.MaleStudents();
            um.FemaleStudents();
            um.SortStudentsByAge();
            um.SortUniversity();
            um.AllStudentsFromCambright();
            um.StudentsFromUserInput();


            Console.WriteLine("Podaj liczbe od 1 do 2:");
            string input = Console.ReadLine();
            try
            {
                int inputAsInt = Convert.ToInt32(input);

                um.StudentsUserChoice(inputAsInt);
            }
            catch (Exception)
            {

                Console.WriteLine("Check your input:");
            }

            int[] someInts = { 30, 4, 86, 25, 79, 18, 65, 82, 11, 34 };
            IEnumerable<int> sortedInts = from i in someInts orderby i select i;
            foreach (var item in sortedInts)
            {
                Console.WriteLine("ints sorted : {0}", item);
            }

            int[] reversedInts = { 12, 35, 46, 22, 99, 14, 6, 55 };
            IEnumerable<int> revInts = from i in reversedInts orderby i descending select i;
            foreach (var item in revInts)
            {
                Console.WriteLine(item);
            }

            um.StudentAndUniversityNameCollection();
        }



    }

    
}
