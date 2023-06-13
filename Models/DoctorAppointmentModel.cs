using System.ComponentModel.DataAnnotations;

namespace MiniHospitalProject.Models
{
    public class DoctorAppointmentModel
    {
        [Key]
        public int AppId { get; set; }
        [Required]
        public string AppointmentDay { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
     
        [Required]
        public int PId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
 
        public int DocId { get; set; }
        public string TotalFee { get; set; }

    }
}
