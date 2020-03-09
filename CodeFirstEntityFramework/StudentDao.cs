using System.ComponentModel.DataAnnotations;
namespace CodeFirstEntityFramework
{
    public class StudentDao
    {
      [Key] 
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public System.DateTime BirthDate { get; set; }

    }
}
