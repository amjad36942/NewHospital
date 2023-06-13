using System.ComponentModel.DataAnnotations;

namespace MiniHospitalProject.Models
{
    public class DepartmentModel
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage ="Department can not be null")]
        public string DepartmentName { get; set; }
    }
}
