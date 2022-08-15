using Models;
using StudentSIS.API.Contracts;
using StudentSIS.API.DatabaseContext;
using StudentSIS.API.Transports;

namespace StudentSIS.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IStudentMapper _studentMapper;
        public StudentService(ApplicationDatabaseContext context, IStudentMapper studentMapper)
        {
            _context = context;
            _studentMapper = studentMapper;
        }

        public void Add(StudentTransport entity)
        {
            var student = _studentMapper.StudentTransportToStudent(entity);
            _context.Student.Add(student);
            _context.SaveChanges();
        }

        public IEnumerable<StudentTransport> GetAll()
        {
            var results = _context.Student.ToList();
            return _studentMapper.StudentsToStudentTransports(results);
        }

        public StudentTransport GetById(int id)
        {
            return _studentMapper.StudentToStudentTransport(_context.Student.Where((x) => x.Id == id).First());
        }


        public StudentTransport getByStudentIDNumber(string idNumber)
        {
            return _studentMapper.StudentToStudentTransport(_context.Student.Where((student) => student.IdNumber == idNumber).First());
        }

        public void Update(StudentTransport entity)
        {
            var student = _studentMapper.StudentTransportToStudent(entity);
            _context.Student.Update(student);
            _context.SaveChanges();

        }
    }
}
