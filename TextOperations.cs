using System;
using System.Collections.Generic;
using System.IO;

namespace lab4
{
    class TextOperations
    {
        private static string ReadFileName()
        {
            Console.WriteLine("Enter text file name with \".txt\" extension:");
            string fileName = Console.ReadLine().Trim();
            return fileName;
        }
        public static void OverwriteData(List<Student> students)
        {          
            string fileName = ReadFileName();
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach (Student student in students)
                {
                    sw.WriteLine(student);
                }
            }
        }
        public static string[] ReadData()
        {
            string fileName = ReadFileName();
            if (File.Exists(fileName))
            {
                return TryReadFile(fileName);
            }
            else
            {
                Console.WriteLine("This file doesn't exist.");
                return new string[] {};
            }
        }
        private static string[] TryReadFile(string fileName)
        {
            string[] data = new string[] { };
            try
            {
                data = File.ReadAllLines(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went very wrong...\n" + e.Message);
            }
            return data;
        }
    }
}