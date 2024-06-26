﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._06
{
    public class Student
    {
         string surname;
         string name;
         string fatherName;
         DateTime birthDate;
         string address;
         string phoneNumber;
         List<int> homework;
         List<int> course;
         List<int> exam;


        public Student()
        {
            SetHomework(new List<int>());
            SetCourse(new List<int>());
            SetExam(new List<int>());

        }


        public Student(string surname, string name, string fatherName, DateTime birthDate,string address, string phoneNumber) : this()
        {
            SetSurname(surname);
            SetName(name);
            SetFatherName(fatherName);
            SetBirthDate(birthDate);
            SetAddress(address);
            SetPhoneNumber(phoneNumber);
        }


        public Student(string surname, string name, string fatherName, DateTime birthDate,string address, string phoneNumber, List<int> homework, List<int> course,List<int> exam) : this(surname, name, fatherName, birthDate, address, phoneNumber)
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

        public DateTime GetBirthDate() { return birthDate; }
        public void SetBirthDate(DateTime x) { birthDate = x; }

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
            Console.WriteLine("Дата рождения: {0}", birthDate.ToShortDateString());
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
    }
}
