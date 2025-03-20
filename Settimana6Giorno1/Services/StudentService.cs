using Settimana6Giorno1.Data;
using Settimana6Giorno1.Models;
using Settimana6Giorno1.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace Settimana6Giorno1.Services
{
    public class StudentService
    {


        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            this._context = context;
        }

        public async Task<StudentListViewModel> GetAllStudentsAsync()
        {
            var studentsList = new StudentListViewModel();

            try
            {
                studentsList.Students = await _context.Students.Include(s =>s.User).ToListAsync();
            }
            catch
            {
                studentsList.Students = null;
            }

            return studentsList;
        }

        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);

            try { return student; } catch { return null; }
        }

        public async Task<bool> UpdateStudentAsync(EditStudentViewModel editStudentViewModel)
        {
            var student = await _context.Students.FindAsync(editStudentViewModel.Id);

            if (student == null)
            {
                return false;
            }


            student.Nome = editStudentViewModel.Nome;
            student.Cognome = editStudentViewModel.Cognome;
            student.DataDiNascita = editStudentViewModel.DataDiNascita;
            student.Email = editStudentViewModel.Email;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteStudentByIdAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) { return false; }
            _context.Students.Remove(student);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> AddStudentAsync(AddStudentViewModel addStudentViewModel)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Cognome = addStudentViewModel.Cognome,
                Nome = addStudentViewModel.Nome,
                DataDiNascita = addStudentViewModel.DataDiNascita,
                Email = addStudentViewModel.Email,
            };
            _context.Students.Add(student);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
