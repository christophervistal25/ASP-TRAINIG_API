
using Models;
using StudentSIS.API.Transports;

namespace StudentSIS.API.Contracts
{
    public interface IStudentMapper
    {
        public StudentTransport StudentToStudentTransport(Student student);
        public Student StudentTransportToStudent(StudentTransport studentTransport);

        public IEnumerable<StudentTransport> StudentsToStudentTransports(List<Student> students);

    }
}
