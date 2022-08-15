using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentSIS.API.Contracts;
using StudentSIS.API.DatabaseContext;
using StudentSIS.API.Services;
using StudentSIS.API.Transports;

namespace StudentSIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet(template: nameof(Students), Name = nameof(Students))]
        public IActionResult Students()
        {

            var students = _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet(template: nameof(Student), Name = nameof(Student))]
        public IActionResult Student(int id)
        {
            var student = _studentService.GetById(id);
            return Ok(student);
        }


        [HttpPost]
        public ActionResult AddStudent([FromBody] StudentTransport student)
        {
            _studentService.Add(student);
            return CreatedAtAction(nameof(Student), student.Id);
        }

        [HttpPatch]
        public ActionResult UpdateStudent([FromBody] StudentTransport student)
        {
            _studentService.Update(student);
            return CreatedAtAction(nameof(Student), student.Id);
        }
    }
}
