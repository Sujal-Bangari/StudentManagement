using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StudentLibrary;

namespace StudentManagement
{
    class Program
    {
        static StudentRepository repo = new StudentRepository();


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("==============  STUDENT MANAGEMENT SYSTEM  =============\n1.ADD STUDENT\n2.VIEW STDUENTS\n3.UPDATE STUDENTS\n4.DELETE STUDENT\n5.EXIT\n-------------------------------------------------------");
                Console.Write("ENTER YOUR CHOICE:");
                string choice = Console.ReadLine();
                switch (choice) {
                    case "1":

                        AddStudents();
                        break;
                    case "2":

                        ViewStudents();
                        break;
                    case "3":

                        UpdateStudents();
                        break;
                    case "4":

                        DeleteStudents();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("CHECK THE OPTION");
                        break;


                }



            }
        }
        static void AddStudents()
        {
            Console.WriteLine("ENTER NAME:");
            string name = Console.ReadLine();
            Console.WriteLine("ENTER AGE:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTER EMAIL:");
            string email = Console.ReadLine();
            Student st = new Student { Name = name, Age = age, Email = email };
            repo.AddStudent(st);
            Console.WriteLine("STUDENT ADDED SUCCESFULLY");
            Console.WriteLine("----------------------------------------------------------");




        }
        static void ViewStudents()
        {
            List<Student> stu = repo.GetAllStudents();
            Console.WriteLine("========STUDENT LIST========");
            foreach (var student in stu)
            {
                Console.WriteLine($"ID: {student.Id}\nNAME: {student.Name}\nAGE: {student.Age}\nEMAIL: {student.Email} ");
                Console.WriteLine("----------------------------------------------------------");
            }

        }
        static void UpdateStudents()
        {
            Console.WriteLine("ENTER STUDENT ID TO UPDATE: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTER THE NEW NAME: ");
            string name = Console.ReadLine();
            Console.WriteLine("ENTER NEW AGE: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTER THE NEW EMAIL: ");
            string email = Console.ReadLine();
            Student st = new Student { Id = id, Name = name, Age = age, Email = email };
            repo.UpdateStudent(st);
            Console.WriteLine("STUDENT UPDATED SUCCESFULLY");
            Console.WriteLine("----------------------------------------------------------");




        }
        static void DeleteStudents()
        {
            Console.WriteLine("ENTER THE STUDENT ID TO DELETE:");
            int id = int.Parse(Console.ReadLine());
            repo.DeleteStudent(id);
            Console.WriteLine("STUDENT DELETED SUCCESSFULLY");
            Console.WriteLine("----------------------------------------------------------");

        }
    }
}
