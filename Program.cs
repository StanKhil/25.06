namespace _25._06
{
    internal class Program
    {
        static void Main()
        {
            Student student1 = new Student("Ivanov", "Ivan", "Ivanovich", new DateTime(2000, 1, 1), "Odesa", "1234567890", new List<int> { 8, 7, 9 }, new List<int> { 10, 7, 6 }, new List<int> { 6, 7, 5 });
            Student student2 = new Student("Petrov", "Petr", "Petrovich", new DateTime(2001, 2, 2), "Chernomorsk", "0987654321", new List<int> { 10, 8, 9 }, new List<int> { 2, 11, 11 }, new List<int> { 9, 10, 11 });

           Student student3 = new Student("Smirnov", "Sergey", "Sergeevich", new DateTime(1999, 3, 3), "Kyiv", "111222333", new List<int> { 10, 9, 10 }, new List<int> { 9, 12, 11 }, new List<int> { 7, 10, 9 });
            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Sort();
            foreach (Student student in students)
            {
                student.DisplayStudentInfo();
            }
            /*Group group = new Group();
            group.AddStudent(student1);
            group.AddStudent(student2);*/

            /*group.Print();

            group.ExpelFailed();
            group.Print();

            group.UpdateStudent(0, "Smirnov", "Sergey", "Sergeevich", new DateTime(1999, 3, 3), "Kyiv", "111222333", new List<int> { 10, 9, 10 }, new List<int> { 9, 12, 11 }, new List<int> { 7, 10, 9 });
            group.Print();*/

            /*List<Student> list = new List<Student>();
            list = group["Ivan"];
            foreach(Student student in list)
            {
                Console.WriteLine(student.ToString());
            }*/
        }
    }
}