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
                studentsList.Students = await _context.Students.ToListAsync();
            }
            catch
            {
                studentsList.Students = null;
            }

            return studentsList;
        }

    }
}
