using generics.Interfaces;
namespace generics.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private IRepository<Student, int> _students = new InMemoryRepository<Student, int>();

        public void AddStudent(Student s) => _students.Add(s.Id, s);
        public void RemoveStudent(int id) => _students.Remove(id);
        public IEnumerable<Student> GetAllStudents() => _students.GetAll();
        public Student FindStudent(int id) => _students.Get(id);
    }
}