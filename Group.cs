using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._06
{
    public enum Specialization
    {
        Mathematics,
        Physics,
        ComputerScience,
        Biology,
        Chemistry
    }

    public class Group
    {
        private List<Student> students;
        private string groupName;
        private Specialization specialization;
        private int countStudent;


        public string GetGroupName() { return groupName; }
        public void SetGroupName(string value) { groupName = value; }

        public Specialization GetSpecialization() { return specialization; }
        public void SetSpecialization(Specialization value) { specialization = value; }

        public int GetCountStudent() { return countStudent; }
        public void SetCountStudent(int value) { countStudent = value; }

        public Group()
        {
            students = new List<Student>();
            groupName = "Default Group";
            specialization = Specialization.ComputerScience;
            countStudent = 0;
        }

        public Group(Group group)
        {
            students = new List<Student>();
            foreach (var student in group.students)
            {
                students.Add(new Student(student.GetSurname(), student.GetName(), student.GetFatherName(), student.GetBirthDate(), student.GetAddress(), student.GetPhoneNumber(), student.GetHomework(), student.GetCourse(), student.GetExam()));
            }

            groupName = group.groupName;
            specialization = group.specialization;
            countStudent = group.countStudent;
        }

        public void Print()
        {
            Console.WriteLine("Группа: {0}, Специализация: {1}, Количество студентов: {2}",groupName, specialization,countStudent);
            Console.WriteLine("Students:");
            Console.WriteLine();
            foreach (var student in students.OrderBy(s => s.GetSurname()))
            {
                student.DisplayStudentInfo();
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
            countStudent++;
        }

        public void EditGroup(string groupName, Specialization specialization, int countStudent)
        {
            groupName = groupName;
            specialization = specialization;
            countStudent = countStudent;
        }

        public void TransferStudent(Group targetGroup, int index)
        {
            if (index >= 0 && index < students.Count)
            {
                var student = students[index];
                targetGroup.AddStudent(student);
                students.RemoveAt(index);
                countStudent--;
            }
            else
            {
                Console.WriteLine("Invalid student index.");
            }
        }

        public void ExpelFailed()
        {
            List<Student> passedStudents = new List<Student>();
            foreach (var student in students)
            {
                if (student.GetExam().Average() >= 7)
                {
                    passedStudents.Add(student);
                }
            }
            students = passedStudents;
            countStudent = students.Count;
        }

        public void ExpelAvg()
        {
            if (students.Count > 0)
            {
                
                double avg = students[0].GetExam().Average();

                for (int i = 0; i < students.Count; i++)
                {
                    double currentAvg = students[i].GetExam().Average();
                    if (currentAvg < avg)
                    {
                        students.RemoveAt(i);
                        countStudent--;
                    }
                }

                
            }
        }

        public void UpdateStudent(int index, string surname, string name, string fatherName, DateTime birthDate, string address, string phoneNumber, List<int> homework, List<int> course, List<int> exam)
        {
            if (index >= 0 && index < students.Count)
            {
                students[index].UpdateStudent(surname, name, fatherName, birthDate, address, phoneNumber, homework, course, exam);
            }
            else
            {
                Console.WriteLine("Invalid student index.");
            }
        }
    }
    
}
