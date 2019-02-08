﻿using System.ComponentModel.DataAnnotations;

namespace Web.Server.Dtos.AuthData
{
    public class RegisterDto
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Password { get; set; }
    }
}
