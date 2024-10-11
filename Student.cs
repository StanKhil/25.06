using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _25._06
{
    public class Student : ICloneable, IComparable<Student>
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string fatherName { get; set; }
        //public DateTime birthDate { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public List<int> homework { get; set; } = new List<int>();
        public List<int> course { get; set; } = new List<int>();
        public List<int> exam { get; set; } = new List<int>();

        Student_sMother Mother;
        Student_sFather Father;

        public delegate void StudentDelegate();
        public event StudentDelegate HighMarkEvent;
        public event StudentDelegate LowMarkEvent;

        public class SurnameCompare : IComparer<Student>
        {
            public int Compare(Student? a, Student? b)
            {
                return a.surname.CompareTo(b.surname);
            }
        }
        public class AvgMarkCompare : IComparer<Student>
        {
            public int Compare(Student? a,Student? b)
            {
                if (a.exam.Average() > b.exam.Average()) return 1;
                else if (a.exam.Average() < b.exam.Average()) return -1;
                return 0;
            }
        }
        public Student()
        {
            SetHomework(new List<int>());
            SetCourse(new List<int>());
            SetExam(new List<int>());

        }

        public override string ToString()
        {
            return name + " " + surname;
        }
        public Student(string surname, string name, string fatherName/*, DateTime birthDate*/,string address, string phoneNumber) : this()
        {
            SetSurname(surname);
            SetName(name);
            SetFatherName(fatherName);
            //SetBirthDate(birthDate);
            SetAddress(address);
            SetPhoneNumber(phoneNumber);
        }


        public Student(string surname, string name, string fatherName/*, DateTime birthDate*/,string address, string phoneNumber, List<int> homework, List<int> course,List<int> exam) : this(surname, name, fatherName/*, birthDate*/, address, phoneNumber)
        {
            if (homework != null) SetHomework(homework);
            else SetHomework(new List<int>());

            if (course != null) SetCourse(course);
            else SetCourse(new List<int>());

            if (exam != null) SetExam(exam);
            else SetExam(new List<int>());
        }


        public string GetSurname() { return surname; }
        public void SetSurname(string x) { surname = x; }

        public string GetName() { return name; }
        public void SetName(string x) { name = x; }

        public string GetFatherName() { return fatherName; }
        public void SetFatherName(string x) { fatherName = x; }

        //public DateTime GetBirthDate() { return birthDate; }
        //public void SetBirthDate(DateTime x) { birthDate = x; }

        public string GetAddress() { return address; }
        public void SetAddress(string x) { address = x; }

        public string GetPhoneNumber() { return phoneNumber; }
        public void SetPhoneNumber(string x) { phoneNumber = x; }

        public List<int> GetHomework() { return homework; }
        public void SetHomework(List<int> x) { homework = x; }

        public List<int> GetCourse() { return course; }
        public void SetCourse(List<int> x) { course = x; }

        public List<int> GetExam() { return exam; }
        public void SetExam(List<int> x) { exam = x; }

        public void DisplayStudentInfo()
        {
            Console.WriteLine("Фамилия: {0}",surname);
            Console.WriteLine("Имя: {0}", name);
            Console.WriteLine("Отчество: {0}", fatherName);
            //Console.WriteLine("Дата рождения: {0}", birthDate.ToShortDateString());
            Console.WriteLine("Домашний адрес: {0}", address);
            Console.WriteLine("Телефон: {0}", phoneNumber);
            Console.WriteLine("Оценки за дз:");
            foreach (var item in homework)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Курсовые оценки:");
            foreach (var item in course)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Оценки за экзамены:");
            foreach (var item in exam)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public void UpdateStudent(string surname, string name, string fatherName, DateTime birthDate, string address, string phoneNumber, List<int> homework, List<int> course, List<int> exam)
        {
            SetSurname(surname);
            SetName(name);
            SetFatherName(fatherName);
            //SetBirthDate(birthDate);
            SetAddress(address);
            SetPhoneNumber(phoneNumber);
            SetHomework(homework);
            SetCourse(course);
            SetExam(exam);
        }


        public static bool operator ==(Student s1, Student s2)
        {
            if (ReferenceEquals(s1, s2)) return true;
            if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null)) return false;

            return s1.surname == s2.surname && s1.name == s2.name && s1.fatherName == s2.fatherName;
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }

        public static bool operator >(Student s1, Student s2)
        {
            return (s1.homework.Sum()+s1.course.Sum() + s2.exam.Sum()) > (s2.homework.Sum() + s2.course.Sum() + s2.exam.Sum());
        }

        public static bool operator <(Student s1, Student s2)
        {
            return !(s1>s2);
        }

        public static bool operator true(Student s)
        {
            return s.homework.Count > 0 || s.course.Count > 0 || s.exam.Count > 0;
        }

        public static bool operator false(Student s)
        {
            return s.homework.Count == 0 || s.course.Count == 0 || s.exam.Count == 0;
        }

        public object Clone()
        {
            return new Student(surname, name, fatherName/*, birthDate*/, address, phoneNumber,
                new List<int>(homework), new List<int>(course), new List<int>(exam));
        }

        public int CompareTo(Student other)
        {
            if (other == null) return 1;

            int thisSum = homework.Sum() + course.Sum() + exam.Sum();
            int otherSum = other.homework.Sum() + other.course.Sum() + other.exam.Sum();

            return thisSum.CompareTo(otherSum);
        }


        public void AddParents(Student_sFather father,Student_sMother mother)
        {
            this.Mother=mother;
            this.Father=father;
        }

        public void AddExamMark(int mark)
        {
            this.exam.Add(mark);
            if (mark == 12 && HighMarkEvent != null)
            {
                HighMarkEvent();
            }
            else if (mark < 4 && LowMarkEvent != null)
            {
                LowMarkEvent();
            }
        }
        public void LowMark()
        {
            this.surname = "I am stupid :(";
        }
        public void AddHomeWorkMark(int mark)
        {
            this.homework.Add(mark);
        }
        public void AddCourseMark(int mark)
        {
            this.course.Add(mark);
        }
    }
}
