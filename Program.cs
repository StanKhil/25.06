using System.Text.Json.Serialization;
using System.Text.Json;

namespace _25._06
{
    internal class Program
    {
        static void Main()
        {
            var group = new Group("IT-01");
            group.AddStudent(new Student("Ivanov", "Ivan", "Ivanovich", "Odesa", "1234567890"));
            group.AddStudent(new Student("Petrov", "Petr", "Petrovich", "Kyiv", "0987654321"));
            group.AddStudent(new Student("Sidorov", "Sidor", "Sidorovich", "Lviv", "1122334455"));
            group.AddStudent(new Student("Smirnov", "Sergey", "Sergeevich", "Dnipro", "2233445566"));
            group.AddStudent(new Student("Kuznetsov", "Andrey", "Andreevich", "Kharkiv", "3344556677"));

            string jsonString = JsonSerializer.Serialize(group, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString);
            Console.WriteLine("\nDeserialize");
            var deserializedGroup = JsonSerializer.Deserialize<object>(jsonString);
            Console.WriteLine(deserializedGroup);
            
        }
    }
}