using DataFirstEntityFirst.Entity;

namespace DataFirstEntityFirst
{
    interface SqlServer<T>
    {
        void ReadStudents();
        void CreateStudent(T student);
        void UpdateStudent(T id);
        void DeleteStudent(T id);
    }
}
