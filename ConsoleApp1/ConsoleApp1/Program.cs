using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1

{
    public class ReverseComparer : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }
    abstract class Person
    {
        public string name { get; set; }
        public Person(string name)
        {
            this.name = name;
        }
    }
     class Student : Person
    {
       
        public string course { get; set; }
        public int number { get; set; }

        public Student(string name, string course, int number):base(name)
        {
           
            this.course = course;
            this.number = number;
        }
        public virtual void Print()
        {
            Console.WriteLine($"Last name : {name}\tCourse of Study : {course}\tGrade book number : {number}");
        }
    }
    class Aspirant : Student
    {
        public string thesisTitle { get; set; }
        public Aspirant(string name, string course, int number, string thesisTitle):base(name,course,number)
        {
            this.thesisTitle = thesisTitle;
        }

        public override void Print()
        {
            Console.WriteLine($"Last name : {name}\tCourse of Study : {course}\tGrade book number : {number}\tThe Thesis title is : {thesisTitle}");
        }
    }
    class Program
    {
       static ArrayList students = new ArrayList();
       static ArrayList aspirants = new ArrayList();
        static LinkedList<Student> lstudents = new LinkedList<Student>();
        static LinkedList<Aspirant> laspirants = new LinkedList<Aspirant>();
      //static  IComparer revComparer = new ReverseComparer();
        static void Main(string[] args)
        {
            
            int menu = -1;
            while (menu != 0)
            {
                Console.WriteLine("0. Exit application\n" +
            "1. Create Student \n" +
            "2. Create Aspirant \n" +
            "3. List of all Students\n" +
            "4. List of all Aspirants\n" +
            "5. List of all Students by ListLinked\n" +
            "6. List of all Aspirants by ListLinked\n"
            //"7. Sort List of Students\n +" +
            /*"8. Sort List of Aspirants\n"*/);


                menu = InputNumber();
                switch (menu)
                {
                    case 1:
                        CreateStudent();
                        break;
                    case 2:
                        CreateAspirant();
                        break;
                    case 3:
                        PrintAllStudents(students);
                        break;
                    case 4:
                        PrintAllAspirants(aspirants);
                        break;
                    case 5:
                        PrintAllStudentsByLinkedList(lstudents);
                        break;
                    case 6:
                        PrintAllAspirantsByLinkedList(laspirants);
                        break;
                    //case 7:
                    //    SortAllStudents(students);
                    //    break;
                        //case 8:
                        //    //SortAllAspirants();
                        //    break;

                }

            }
        }
        static void CreateStudent()
        {
            string name, course;
            int number;
            
            Console.WriteLine("Enter name of the Student:");
            name = Console.ReadLine();
            Console.WriteLine("Enter course of the Student (Example:History):");
            course = Console.ReadLine();
            Console.WriteLine("Enter Grade book number of the Student:");
            for (; ; )
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out number))
                {
                    number = Convert.ToInt32(number);

                    Student student = new Student(name, course, number);
                    students.Add(student);
                    lstudents.AddLast(student);

                    return;
                }
                else
                {
                    Console.WriteLine("Enter a number");
                }
            }
        }
        static void CreateAspirant()
        {
            string name, course, thesisTitle;
            int number;

            Console.WriteLine("Enter name of the Aspirant:");
            name = Console.ReadLine();
            Console.WriteLine("Enter course of the Aspirant (Example:History)");
            course = Console.ReadLine();
            Console.WriteLine("Enter Grade book number of the Aspirant:");
            for (; ; )
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out number))
                {
                    number = Convert.ToInt32(number);

                    Console.WriteLine("Enter title of the Aspirant's thesis:");
                    thesisTitle = Console.ReadLine();
                    Student student = new Student(name, course, number);
                    Aspirant aspirant = new Aspirant(name, course, number, thesisTitle);
                   
                    students.Add(student);
                    aspirants.Add(aspirant);
                    lstudents.AddLast(student);
                    laspirants.AddLast(aspirant);
                    return;
                }
                else
                {
                    Console.WriteLine("Enter a number");
                }
            }
        }

        static int InputNumber()
        {
            for (; ; )
            {
                int result;
                string message = Console.ReadLine();
                if (Int32.TryParse(message, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Enter correct number");
                }
            }
        }

       public static void PrintAllStudents(ArrayList myList)
        {
            
            if (myList == null)
            {
                Console.WriteLine("There are no students yet!");
            }
            else
            {
                foreach (Student s in myList )
                {

                    s.Print();
                    
                }
            }
        }
        public static void PrintAllAspirants(ArrayList myList)
        {

            if (myList == null)
            {
                Console.WriteLine("There are no aspirants yet!");
            }
            else
            {
                foreach (Aspirant a in myList)
                {

                    a.Print();
                }
            }
        }
        public static void PrintAllStudentsByLinkedList(IEnumerable List)
        {
            if (List == null)
            {
                Console.WriteLine("There are no students yet!");
            }
            else
            {
                foreach (Student s in List)
                {

                    s.Print();

                }
            }
        }
       public static void PrintAllAspirantsByLinkedList(IEnumerable List)
        {
            if (List == null)
            {
                Console.WriteLine("There are no students yet!");
            }
            else
            {
                foreach (Aspirant a in List)
                {

                    a.Print();

                }
            }
        }

        /* public static void SortAllStudents(ArrayList students)
         {
             //    students.Sort();
             //    PrintAllStudents(students);
             //foreach (Object obj in students)
             //    Console.WriteLine("   {0}", obj);
             //Console.WriteLine();
             {
                 for (int i = students.GetLowerBound(0); i <= students.GetUpperBound(0);
                       i++)
                 {
                     Console.WriteLine("   [{0}] : {1}", i, students[i]);
                 }
                 Console.WriteLine();
             }
         }*/

    }

}
