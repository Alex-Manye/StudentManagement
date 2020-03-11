using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using log4net;

namespace CodeFirstEntityFramework
{
    public class OperationSQL : SqlServer<StudentDao>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OperationSQL));

        public void ReadStudents()
        {
            using (StudentContext db = new StudentContext())
            {
                try
                {
                    var students = (from student in db.Students
                                    select student).Take(50).ToList();
                    students.ForEach(student => Console.WriteLine(student));
                }
                catch (ArgumentNullException error)
                {
                    log.Error(error);
                    throw;
                } 
                catch (InvalidOperationException error)
                {
                    log.Error(error);
                    throw;
                }
            }
        }

        public void CreateStudent(StudentDao student)
        {
            using (StudentContext db = new StudentContext())
            {
                db.Students.Add(student);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (DbEntityValidationException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (NotSupportedException error)
                {
                    log.Error(error);
                    throw;
                }
                catch(ObjectDisposedException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (InvalidOperationException error)
                {
                    log.Error(error);
                    throw;
                }
            }
        }

        public void UpdateStudent(StudentDao id)
        {
            using (StudentContext db = new StudentContext())
            {
                try
                {
                    var students = db.Students.Where(student => student.StudentId == id.StudentId).ToList();
                    students.ForEach(student => student.StudentName = id.StudentName);
                    db.SaveChanges();
                }
                catch (ArgumentNullException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (DbUpdateException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (DbEntityValidationException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (NotSupportedException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (ObjectDisposedException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (InvalidOperationException error)
                {
                    log.Error(error);
                    throw;
                }
            }
        }
        public void DeleteStudent(StudentDao id)
        {
            using (StudentContext db = new StudentContext())
            {
                try
                {
                    var students = db.Students.Where(student => student.StudentId == id.StudentId).ToList();
                    db.Students.RemoveRange(students);
                    db.SaveChanges();
                }
                catch (ArgumentNullException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (DbUpdateException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (DbEntityValidationException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (NotSupportedException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (ObjectDisposedException error)
                {
                    log.Error(error);
                    throw;
                }
                catch (InvalidOperationException error)
                {
                    log.Error(error);
                    throw;
                }
            }
        }


    }
}