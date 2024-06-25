namespace _25._06
{
    internal class Program
    {
        static void Main()
        {
            Student student = new Student("Иванов", "Иван", "Иванович", new DateTime(2000, 1, 1),"ул. Шевченко, д.1", "+380 97 999 99 99");

            student.SetHomework(new List<int> { 12,11, 7 });
            student.SetCourse(new List<int> { 10, 8 });
            student.SetExam(new List<int> { 9, 11, 11 });
            student.DisplayStudentInfo();
        }
    }
}