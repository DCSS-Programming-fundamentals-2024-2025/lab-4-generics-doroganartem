using generics.Interfaces;
namespace generics.Models{
    public class Person { 
        public int Id;
        public string Name;
    }
    public class Student : Person {
        public void SubmitWork() => Console.WriteLine($"{Name} подав роботу.");
        public void SayName() => Console.WriteLine($"Я студент: {Name}");
    }

    public class Teacher : Person {
        public void GradeStudent(Student s, int grade) =>
            Console.WriteLine($"{Name} поставив {grade} балів студенту {s.Name}");

        public void ExpelStudent(Student s) =>
            Console.WriteLine($"{Name} вигнав {s.Name}");

        public void ShowPresentStudents() =>
            Console.WriteLine($"{Name} показує присутніх студентів.");
    }
}