using System.ComponentModel.DataAnnotations;



namespace MiniHospitalProject.Models
{
    public class DoctorDaysModel
    {
        [Key]
        public int ScheduleId { get; set; }

        public string DoctorDay { get; set; }
        public string TimeSlot { get; set; }

        public DateTime DoctorDate { get; set; }

        public bool Isavailable { get; set; }
        [Required]
        public string DoctorFirstName { get; set; }
        [Required]
        public string DoctorLastName { get; set; }
       
    }
}
