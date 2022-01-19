using System.ComponentModel.DataAnnotations;

namespace SpeechNet.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
