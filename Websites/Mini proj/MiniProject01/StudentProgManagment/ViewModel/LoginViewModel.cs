using System.ComponentModel.DataAnnotations;

namespace StudentProgManagment.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Enter User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }    
    }
}
