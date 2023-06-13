using System.ComponentModel.DataAnnotations;

namespace MiniHospitalProject.Models
{
    public class PatientModel
    {
        [Key]
        public int PId { get; set; }
        [Required]
        public string PatientFirstName { get; set; }
        [Required]
        public string PatientLastName { get; set; }
        public string PatientHistory { get; set; }
        public string Contact { get; set; }
        public string PatientAddress { get; set; }

    }
}
