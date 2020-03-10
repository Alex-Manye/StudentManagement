using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using DataFirstEntityFirst;
using DataFirstEntityFirst.Entity;
using log4net;

namespace DatabaseFirstEntityFramework.Entity
{
    public class OperationSql : SqlServer<Student>
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

        public void UpdateStudent(Student id)
        {
            using (StudentEntities db = new StudentEntities())
            {
                try
                {
                    var students = db.Student.Where(student => student.Studentid == id.Studentid).ToList();
                    students.ForEach(student => student.Name = id.Name);
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

        public void DeleteStudent(Student id)
        {
            using (StudentEntities db = new StudentEntities())
            {
                try
                {
                    var students = db.Student.Find(id.Studentid);
                    db.Student.Remove(students);
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
