using DataFirstEntityFirst.Entity;

namespace DataFirstEntityFirst
{
    interface SqlServer
    {
        void ReadStudents();
        void CreateStudent(Student student);
        void UpdateStudent(int id, string Name);
        void DeleteStudent(int id);
    }
}
