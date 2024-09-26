namespace _25._06
{
    internal class Program
    {
        static void Main()
        {
            Student student1 = new Student("Ivanov", "Ivan", "Ivanovich", new DateTime(2000, 1, 1), "Odesa", "1234567890");
            Student student2 = new Student("Petrov", "Petr", "Petrovich", new DateTime(2001, 2, 2), "Chernomorsk", "0987654321");
            Student student3 = new Student("Smirnov", "Sergey", "Sergeevich", new DateTime(1999, 3, 3), "Kyiv", "111222333");

            Student_sMother mother = new Student_sMother();
            Student_sFather father = new Student_sFather();
            student1.HighMarkEvent += mother.Reaction;
            student1.HighMarkEvent += father.Reaction;
            student1.LowMarkEvent += student1.LowMark;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x=random.Next(1,13);
                Console.WriteLine("Mark: "+x);
                student1.AddExamMark(x);
            }

            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(1, 13);
                //Console.WriteLine("Mark: " + x);
                student2.AddExamMark(x);
                x = random.Next(1, 13);
                student3.AddExamMark(x);
            }


            Console.WriteLine("\n\n");
            Group group = new Group();
            group.AddStudent(student1);
            group.AddStudent(student2);
            group.AddStudent(student3);
            foreach(var student in group)
            {
                student.DisplayStudentInfo();
            }
            group.ExpelFailed();
            group.Print();

            
        }
    }
}