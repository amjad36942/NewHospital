using System.ComponentModel.DataAnnotations;

namespace MiniHospitalProject.Models
{
    public class DoctorModel
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        public string DoctorFirstName { get; set;}
        [Required]
        public string DoctorLastName { get; set; }
        [Required]
        public int Contact { get; set;}
        [Required]
        public string Email { get; set;}
        [Required]
        public string Fees { get; set;}

        public int DepartmentId { get; set; }
//this is not correct
        public string abc { get; set; }

        public DepartmentModel Department { get; set; }
    }
}
