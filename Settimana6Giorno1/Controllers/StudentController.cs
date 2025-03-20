using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Settimana6Giorno1.Services;
using Settimana6Giorno1.ViewModels;
using System;
using System.Threading.Tasks;

namespace Settimana6Giorno1.Controllers
{
    [Authorize(Roles =  "Admin")]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
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

        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
            {
                return RedirectToAction("Index");
            }

            var editStudentViewModel = new EditStudentViewModel()
            {
                Id = student.Id,
                Nome = student.Nome,
                Cognome = student.Cognome,
                DataDiNascita = student.DataDiNascita,
                Email = student.Email
            };

            return PartialView("_EditForm", editStudentViewModel);
        }

        [HttpPost("student/edit/save")]
        public async Task<IActionResult> Edit(EditStudentViewModel editStudentViewModel)
        {
            var result = await _studentService.UpdateStudentAsync(editStudentViewModel);

            if (!result)
            {
                return Json(new
                {
                    success = false,
                    message = "Errore durante l'aggiornamento nel database"
                });
            }

            return Json(new
            {
                success = true,
                message = "Studente aggiornato con successo"
            });
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _studentService.DeleteStudentByIdAsync(id);

            if (!result)
            {
                return Json(new
                {
                    success = false,
                    message = "Errore"
                });
            }
            return Json(new
            {
                success = true,
                message = "Avvenuto con successo"
            });
        }
        public IActionResult Add()
        {
            return PartialView("_AddForm");
        }

        [HttpPost("student/Add")]

        public async Task<IActionResult> Add(AddStudentViewModel addStudentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Errore nei dati inseriti"
                });
            }

            var result = await _studentService.AddStudentAsync(addStudentViewModel);

            if (!result)
            {
                return Json(new
                {
                    success = false,  
                    message = "Errore durante l'aggiunta"
                });
            }

            return Json(new
            {
                success = true,
                message = "Studente aggiunto con successo"
            });
        }

    }
}

