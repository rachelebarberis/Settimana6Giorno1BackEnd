﻿using System.ComponentModel.DataAnnotations;

namespace Settimana6Giorno1.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
