

using Models;
using StudentSIS.API.Contracts;
using StudentSIS.API.Transports;

namespace StudentSIS.API.Mapper
{
    public class StudentMapper : IStudentMapper
    {
        public IEnumerable<StudentTransport> StudentsToStudentTransports(List<Student> students)
        {
            var studentTransports = new List<StudentTransport>();

            students.ForEach((student) =>
            {
                studentTransports.Add(new StudentTransport()
                {
                    Id = student.Id,
                    IdNumber = student.IdNumber,
                    FirstName = student.FirstName,
                    MiddleName = student.MiddleName,
                    LastName = student.LastName,
                    Suffix = student.Suffix,
                    Course = student.Course,
                    CreatedAt = student.CreatedAt,
                    UpdatedAt = student.UpdatedAt
                });
            });

            return studentTransports;
        }

        public StudentTransport StudentToStudentTransport(Student student)
        {
            var studentTransport = new StudentTransport()
            {
                Id = student.Id,
                IdNumber = student.IdNumber,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                Suffix = student.Suffix,
                Course = student.Course,
                CreatedAt = student.CreatedAt,
                UpdatedAt = student.UpdatedAt,
            };

            return studentTransport;
        }


        public Student StudentTransportToStudent(StudentTransport studentTransport)
        {
                var student = new Student()
                {
                    Id = studentTransport.Id,
                    IdNumber = studentTransport.IdNumber,
                    FirstName = studentTransport.FirstName,
                    MiddleName = studentTransport.MiddleName,
                    LastName = studentTransport.LastName,
                    Suffix = studentTransport.Suffix,
                    Course = studentTransport.Course,
                    CreatedAt = studentTransport.CreatedAt,
                    UpdatedAt = studentTransport.UpdatedAt,
                };

                return student;
            }
    }
}
