using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniHospitalProject.Models;

namespace MiniHospitalProject.Data
{
    public class MiniHospitalProjectContext : DbContext
    {
        public MiniHospitalProjectContext (DbContextOptions<MiniHospitalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<DoctorModel> DoctorTBL { get; set; }
        public DbSet<DepartmentModel> DepartmentTBL { get; set; }
        public DbSet<DoctorAppointmentModel> doctorAppointmentTBL { get; set; }
        public DbSet<DoctorDaysModel> DoctorDaysTBL { get; set; }
        public DbSet<PatientModel> PatientTBL { get; set; }
        public DbSet<UserLoginModel> UserLoginTBL { get; set; }
       
        public DbSet<MailContent> Mailtbl { get; set; }

    }
}
