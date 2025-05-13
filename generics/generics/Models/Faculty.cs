using generics.Interfaces;
namespace generics.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private IRepository<Group, int> _groups = new InMemoryRepository<Group, int>();

        public void AddGroup(Group g) => _groups.Add(g.Id, g);
        public void RemoveGroup(int id) => _groups.Remove(id);
        public IEnumerable<Group> GetAllGroups() => _groups.GetAll();
        public Group GetGroup(int id) => _groups.Get(id);

        public void AddStudentToGroup(int groupId, Student s) => GetGroup(groupId)?.AddStudent(s);
        public void RemoveStudentFromGroup(int groupId, int studentId) => GetGroup(groupId)?.RemoveStudent(studentId);
        public IEnumerable<Student> GetAllStudentsInGroup(int groupId) => GetGroup(groupId)?.GetAllStudents();
        public Student FindStudentInGroup(int groupId, int studentId) => GetGroup(groupId)?.FindStudent(studentId);
    }
}