namespace CodeFirstEntityFramework
{
    public interface SqlServer<T>
    {
        void ReadStudents();
        void CreateStudent(T student);
        void UpdateStudent(T id);
        void DeleteStudent(T id);
    }
}
