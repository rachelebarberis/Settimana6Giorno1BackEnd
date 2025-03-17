using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Settimana6Giorno1.Models
{
    public class Student
    {
        [Key]
       
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public required string Cognome { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataDiNascita { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
