using System;
using System.Xml.Serialization;

namespace lab4
{
    [Serializable]
    [XmlRoot("StudentInfo")]
    public struct Student : IComparable<Student>
    {
        public int id;
        public string fullName;        
        public int birthYear;
        [XmlElement("universityEnterYear")]
        public int enterYear;

        public Student(string lineWithAllData)
        {
            string[] separatedData = lineWithAllData.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            id = int.Parse(separatedData[0]);
            fullName = separatedData.Length == 4 ? fullName = separatedData[1] : separatedData[1] + "_" + separatedData[2]; // check whether fullName is one string or two string
            birthYear = int.Parse(separatedData[separatedData.Length-2]);
            enterYear = int.Parse(separatedData[separatedData.Length-1]);
        }

        public int CompareTo(Student that)
        {
            return this.id.CompareTo(that.id);
        }

        public override string ToString()
        {
            return $"{id} {fullName} {birthYear} {enterYear}";
        }
    }
}
