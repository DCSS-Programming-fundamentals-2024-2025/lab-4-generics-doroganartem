using System;
using System.Collections.Generic;
using generics.Models;
using generics.Interfaces;

class Program
{
    static void Main(string[] args)
    {
                // Створення факультету
        var fpm = new Faculty { Id = 1, Name = "ФПМ" };

        // Додавання груп
        fpm.AddGroup(new Group { Id = 41, Name = "КП-41" });
        fpm.AddGroup(new Group { Id = 42, Name = "КП-42" });

        // Створення студентів
        var student1 = new Student { Id = 1, Name = "Тьома" };
        var student2 = new Student { Id = 2, Name = "Нюся" };

        // Додавання студентів у групу КП-41
        fpm.AddStudentToGroup(41, student1);
        fpm.AddStudentToGroup(41, student2);

        // Вивід студентів з групи КП-41
        Console.WriteLine("Студенти у групі КП-41:");
        foreach (var student in fpm.GetAllStudentsInGroup(41))
        {
            student.SayName();
            student.SubmitWork();
        }

        // Демонстрація коваріантності
        IReadOnlyRepository<Student, int> studRepo = new InMemoryRepository<Student, int>();
        IReadOnlyRepository<Person, int> personRepo = studRepo;

        // Демонстрація контраваріантності
        IWriteRepository<Student, int> studentWrite = new InMemoryRepository<Student, int>();
        //IWriteRepository<Person, int> personWrite = studentWrite;
    }
}