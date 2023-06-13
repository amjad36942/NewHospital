using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MiniHospitalProject.Models
{
    [NotMapped]
    public class MailContent


    {
        [Key]
       public int Id { get; set; }  
       
        public string ToEmailAddress { get; set; }
        public string SubjectEmail { get; set; }
        public string bodyEmail { get; set; }
        [AllowNull]
        public IFormFileCollection attachement { get; set; }

    }
}
