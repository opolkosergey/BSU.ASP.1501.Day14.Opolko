using System.ComponentModel.DataAnnotations;

namespace Trainings.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Fill lastname")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Fill E-Mail")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fill university")]
        [Display(Name = "University")]
        public string University { get; set; }

        [Required(ErrorMessage = "Check university class")]
        [Display(Name = "University class")]
        public int UniversityClass { get; set; }
    }
}