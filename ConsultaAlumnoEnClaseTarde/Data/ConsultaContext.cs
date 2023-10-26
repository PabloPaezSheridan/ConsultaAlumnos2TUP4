using ConsultaAlumnoEnClaseTarde.Entities;
using ConsultaAlumnos2TUP4.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaAlumnoEnClaseTarde.Data
{
    public class ConsultaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Question> Questions { get; set; }

        public ConsultaContext(DbContextOptions<ConsultaContext> dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

           modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    LastName = "Bologna",
                    Name = "Nicolas",
                    Email = "nbologna31@gmail.com",
                    UserName = "nbologna_alumno",
                    Password = "123456",
                    Id = 1
                },
                new Student
                {
                    LastName = "Perez",
                    Name = "Juan",
                    Email = "Jperez@gmail.com",
                    UserName = "jperez",
                    Password = "123456",
                    Id = 2
                },
                new Student
                {
                    LastName = "Garcia",
                    Name = "Pedro",
                    Email = "pgarcia@gmail.com",
                    UserName = "pgarcia",
                    Password = "123456",
                    Id = 3
                });

            modelBuilder.Entity<Professor>().HasData(
               new Professor
               {
                   LastName = "Bologna",
                   Name = "Nicolas",
                   Email = "nbologna31@gmail.com",
                   UserName = "nbologna_profesor",
                   Password = "123456",
                   Id = 4
               },
               new Professor
               {
                   LastName = "Paez",
                   Name = "Pablo",
                   Email = "ppaez@gmail.com",
                   UserName = "ppaez",
                   Password = "123456",
                   Id = 5
               });

            modelBuilder.Entity<Subject>().HasData(
                new Subject()
                {
                    Id = 1,
                    Name = "Programacion 3",
                    Room = "103"          
                });

            modelBuilder.Entity<Subject>()
                .HasMany(su => su.Professors)
                .WithMany(p => p.Subjects)
                .UsingEntity(j => j
                    .ToTable("nm  ")
                    .HasData(new[]
                        {
                            new { ProfessorsId = 4, SubjectsId = 1},
                            new { ProfessorsId= 5, SubjectsId = 1}
                        }
                    ));

            modelBuilder.Entity<Subject>()
               .HasMany(su => su.Students)
               .WithMany(st => st.SubjectsAttended)
               .UsingEntity(j => j
                   .ToTable("StudentsSubjectsAttended")
                   .HasData(new[]
                       {
                            new { StudentsId = 1, SubjectsAttendedId = 1},
                            new { StudentsId = 2, SubjectsAttendedId = 1},
                       }
                   ));

        }
    }
}
