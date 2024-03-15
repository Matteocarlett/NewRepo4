using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public class Register
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Compare("Password", ErrorMessage = "Le password non corrispondono.")]
        public string ConfirmPassword { get; set; }
    }
}
