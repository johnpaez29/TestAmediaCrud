using System.ComponentModel.DataAnnotations;

namespace TestUserCrud.Models
{
    public class UserModel
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El {0} excede los {1} o el mínimo de {2} caracteres", MinimumLength = 4)]
        [Display(Name = " Nombre Usuario")]
        public string UserName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "El {0} excede los {1}  0 el minimo de {2} caracteres", MinimumLength = 4)]
        [Display(Name = "Tipo de usuario")]
        public string UserType { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "El {0} excede los {1}  0 el minimo de {2} caracteres", MinimumLength = 4)]
        [Display(Name = "Tipo de usuario")]
        public int? IdUserType { get; set; }
    }
}
