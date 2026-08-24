using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class Student
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; } = "";

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [Phone]
        public string Phone { get; set; } = "";

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; } = "";

        [Required]
        public string Course { get; set; } = "";

        [Required]
        public string Semester { get; set; } = "";

        [Required]
        [Display(Name = "Student ID")]
        public string StudentId { get; set; } = "";

        [Required]
        public string Address { get; set; } = "";

        [Required]
        public string City { get; set; } = "";

        [Required]
        public string Country { get; set; } = "";

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = "";

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Previous Education")]
        public string PreviousEducation { get; set; } = "";

        public string Skills { get; set; } = "";

        [Display(Name = "About Student")]
        public string AboutStudent { get; set; } = "";

        [Display(Name ="Accept Team")]
        public bool AcceptTerms { get; set; }
    }
}
