﻿using System.ComponentModel.DataAnnotations;

namespace SpeechNet.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "ФИО")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Номер")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
