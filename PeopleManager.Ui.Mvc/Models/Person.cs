using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Ui.Mvc.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Display(Name ="First name")]
        [Required]
        public required string FirstName { get; set; }
        [Display(Name ="Last name")]
        [Required]
        public required string LastName { get; set; }
        [Display(Name ="Email")]
        [EmailAddress]
        [Required]
        public required string Email { get; set; }
    }
}
