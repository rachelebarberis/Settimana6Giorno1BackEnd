using System.ComponentModel.DataAnnotations;

namespace Settimana6Giorno1.ViewModels
{
    public class EditStudentViewModel
    {
      

        public Guid Id { get; set; }

 
        public required string Nome { get; set; }

    
        public required string Cognome { get; set; }

       
        public DateTime DataDiNascita { get; set; }

    
        public required string Email { get; set; }
    }
}
