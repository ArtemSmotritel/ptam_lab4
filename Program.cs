using System;
using System.Collections.Generic;

namespace lab4
{    
    class Program
    {        
        public static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            students.Clear();
            RunMenu();
        }

        private static void RunMenu()
        {
            Console.WriteLine("What do you want to do? Press:\n" +
                "1: to add students information from the console\n" +
                "2: to save sorted entered information to text file\n" +
                "3: to save sorted entered information to xml file\n" +
                "4: to save sorted entered information to both text and xml files\n" +
                "5: to clear all temporary students information and read it from text file\n" +
                "6: to clear all temporary students information and read it from xml file\n" +
                "7: to show students with specific birth year\n" +
                "8: to print all students\n" +
                "0: to exit the program");
            int choice;
            do
            {
                choice = int.Parse(Console.ReadLine());
                switch (choice) 
                {
                    case 1:
                        ReadDataFromConsole();
                        break;
                    case 2:                        
                        students.Sort();
                        TextOperations.OverwriteData(students);
                        break;
                    case 3:                        
                        students.Sort();
                        XmlOperations.OverwriteData(students);
                        break;
                    case 4:
                        students.Sort();
                        TextOperations.OverwriteData(students);
                        XmlOperations.OverwriteData(students);
                        break;
                    case 5:
                        students.Clear();
                        HadleInput(TextOperations.ReadData());
                        break;
                    case 6:                        
                        students = XmlOperations.ReadData();
                        break;
                    case 7:                        
                        PrintStudentsWithBirthYear();
                        break;
                    case 8:
                        PrintStudents();
                        break;
                    case 0:
                        Console.WriteLine("Terminating the program");
                        break;
                    default:
                        Console.WriteLine("Wrong choice, enter another value");
                        break;
                }
            } while (choice != 0);
        }
        private static void PrintStudentsWithBirthYear()
        {
            Console.WriteLine("Enter the birth year:");
            int birthYear = int.Parse(Console.ReadLine());
            bool anyStudent = false;

            foreach (Student student in students)
            { 
                if (student.birthYear == birthYear)
                {
                    Console.WriteLine(student);
                    anyStudent = true;
                }                    
            }
            if (!anyStudent)            
                Console.WriteLine("There is no student with this birth year: " + birthYear);            
        }
        private static void HadleInput(string[] rawInput)
        {
            if (rawInput.Length == 0)
            {
                Console.WriteLine("The input is empty.");
            }
            else
            {
                foreach (string line in rawInput)
                {
                    students.Add(new Student(line));
                }
            }            
        }
        private static void PrintStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("There are no students");
            }
            else
            {
                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }                
            }
        }
        private static void ReadDataFromConsole()
        {
            Console.WriteLine("Enter Student info as required. One line for one student. Or 0 to stop");
            string input = Console.ReadLine();
            while (input.Trim() != "0")
            {
                students.Add(new Student(input));
                input = Console.ReadLine();
            }
            Console.WriteLine("Student info has been entered.");
        }
    }
}