using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using DataFirstEntityFirst;
using DataFirstEntityFirst.Entity;
using log4net;

namespace DatabaseFirstEntityFramework.Entity
{
    public class OperationSql : SqlServer
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OperationSql));
        public void ReadStudents()
        {
            using (StudentEntities db = new StudentEntities())
            {
                try
                {
                    var students = (from student in db.Student
                                    select student).ToList();
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

        public void CreateStudent(Student student)
        {
            StudentEntities db = new StudentEntities();
            db.Student.Add(student);
            try
            {
                db.SaveChangesAsync();
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

        public void UpdateStudent(int id, string Name)
        {
            using (StudentEntities db = new StudentEntities())
            {
                try
                {
                    var students = db.Student.Where(student => student.Studentid == id).ToList();
                    students.ForEach(student => student.Name = Name);
                    db.SaveChangesAsync();
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

        public void DeleteStudent(int id)
        {
            using (StudentEntities db = new StudentEntities())
            {
                try
                {
                    var students = db.Student.Find(id);
                    db.Student.Remove(students);
                    db.SaveChangesAsync();
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
