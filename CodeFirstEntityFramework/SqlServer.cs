namespace CodeFirstEntityFramework
{
    interface SqlServer
    {
        void ReadStudents();
        void CreateStudent(StudentDao student);
        void UpdateStudent(int id, string Name);
        void DeleteStudent(int id);
    }
}
