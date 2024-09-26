using System;
using System.Collections;
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

    public class Group : ICloneable, IComparable<Group>,IEnumerable
    {
        private List<Student> students;
        private string groupName;
        private Specialization specialization;
        private int countStudent;

        public event EventHandler<Student> StudentAdded;
        public event EventHandler<Student> StudentRemoved;
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
            OnStudentAdded(student);
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
                OnStudentRemoved(student);
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
                else
                {
                    OnStudentRemoved(student); 
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
                        OnStudentRemoved(students[i]);
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

        public static bool operator ==(Group g1, Group g2)
        {
            if (ReferenceEquals(g1, g2)) return true;
            if (ReferenceEquals(g1, null) || ReferenceEquals(g2, null)) return false;

            return g1.groupName == g2.groupName && g1.specialization == g2.specialization && g1.countStudent == g2.countStudent && g1.students.SequenceEqual(g2.students);
        }

        public static bool operator !=(Group g1, Group g2)
        {
            return !(g1 == g2);
        }

        public Student this[int index]
        {
            get 
            {
                if (index >= students.Count() || index < 0)
                    return students[index];
                else
                    return students[0];
            }

            set 
            { 
                if(index>=students.Count() ||  index < 0)
                students[index] = value;
            }
        }

        public List<Student> this[string name]
        {
            get
            {
                List<Student> stud = new List<Student>();
                foreach (var student in students)
                {
                    //Console.WriteLine(student.GetName());
                    if(name == student.GetName()) stud.Add(student);

                }
                return stud;
            }
        }
        public object Clone()
        {
            return new Group(this); 
        }


        public int CompareTo(Group other)
        {
            if (other == null) return 1;
            return this.countStudent.CompareTo(other.countStudent);
        }

        public class GroupEnum : IEnumerator
        {
            public List<Student> studs;
            int ind = -1;

            public GroupEnum(List<Student> list)
            {
                studs = list;
            }

            public bool MoveNext()
            {
                ind++;
                return (ind < studs.Count());
            }

            public void Reset()
            {
                ind = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Student Current
            {
                get
                {
                    try
                    {
                        return studs[ind];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public GroupEnum GetEnumerator()
        {
            return new GroupEnum(students);
        }

        protected virtual void OnStudentAdded(Student student)
        {
            Console.WriteLine("welcome");
        }

        protected virtual void OnStudentRemoved(Student student)
        {
            Console.WriteLine("unluck");
        }
    }

}
