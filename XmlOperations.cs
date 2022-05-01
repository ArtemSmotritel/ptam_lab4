using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace lab4
{
    class XmlOperations
    {
        private static string ReadFileName()
        {
            Console.WriteLine("Enter xml file name with \".xml\" extension:");
            string fileName = Console.ReadLine().Trim();
            return fileName;
        }        
        public static void OverwriteData(List<Student> students)
        {
            string fileName = ReadFileName();
            var xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (var writer = new StreamWriter(fileName, false))
            {
                xmlSerializer.Serialize(writer, students);
            }            
        }
        public static List<Student> ReadData()
        {
            string fileName = ReadFileName();
            if (File.Exists(fileName))
            {
                return TryReadData(fileName);
            }
            else
            {
                Console.WriteLine("This file doesn't exist.");
                return new List<Student>();
            }
        }
        private static List<Student> TryReadData(string fileName)
        {
            List<Student> data = new List<Student>();
            var xmlSerializer = new XmlSerializer(typeof(List<Student>));
            var reader = new StreamReader(fileName);

            try
            {                
                data = (List<Student>)xmlSerializer.Deserialize(reader);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went very wrong...\n" + e.Message);
            }
            finally 
            {
                reader.Close();
            }

            return data;            
        }
    }
}
