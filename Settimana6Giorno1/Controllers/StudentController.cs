using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Settimana6Giorno1.Services;


namespace Settimana6Giorno1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            this._studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("student/get-all")]
        public async Task<IActionResult> ListStudents()
        {
            var studentsList = await _studentService.GetAllStudentsAsync();

            return PartialView("_StudentsList", studentsList);
        }
    }
}
