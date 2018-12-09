using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.ProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Data
{
    public class MyContext : DbContext

    {
        // configuration constructor
        public MyContext(DbContextOptions<MyContext> Options)

        : base(Options)

        {
        }
        public DbSet<Models.Patient> Patients { get; set; }
        public DbSet<Models.Doctor> Doctors { get; set; }
        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.Room> Rooms { get; set; }
        public DbSet<Models.Patient_Department> Patient_Departments { get; set; }
        public DbSet<Models.Patient_Doctor> Patient_Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Patient_Department>()
                .HasKey(pd => new { pd.pid, pd.deptno });
            modelBuilder.Entity<Models.Patient_Department>()
             .HasOne(pd => pd.patient)
             .WithMany(b => b.Departmentlist)
             .HasForeignKey(pd => pd.pid);

            modelBuilder.Entity<Models.Patient_Department>()
           .HasOne(pd => pd.department)
           .WithMany(c => c.patientlist)
           .HasForeignKey(pd => pd.deptno);

            modelBuilder.Entity<Models.Patient_Doctor>()
              .HasKey(pr => new { pr.pid, pr.Did });
            modelBuilder.Entity<Models.Patient_Doctor>()
             .HasOne(pr => pr.patient)
             .WithMany(b => b.doctorlist)
             .HasForeignKey(pr => pr.pid);
            modelBuilder.Entity<Models.Patient_Doctor>()
            .HasOne(pr => pr.doctor)
            .WithMany(b => b.patientlist)
          .HasForeignKey(pr => pr.Did);
        }

    }
}







