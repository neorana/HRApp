using System;
using System.Collections.Generic;
using System.Data.Entity;
using BEEPOApp.Models;

namespace BEEPOApp.DAL
{
    public class HRISInitializer : DropCreateDatabaseIfModelChanges<HRISContext>
    {
        protected override void Seed(HRISContext context)
        {
           
            var departments = new List<Department>
            {
                new Department {Name = "HR"},
                new Department {Name = "Accounting"},
                new Department {Name = "Sales"},
                new Department {Name = "IT Support"},
                new Department {Name = "Dev Group"}
            };

            departments.ForEach(d => context.Departments.Add(d));
            context.SaveChanges();


            var employees = new List<Employee>
            {
                new Employee{FirstName="Tony",Lastname="Dela Cruz", MiddleName= "Alonzo",  BirthDate=DateTime.Parse("1981-02-03"),  DateHired = DateTime.Parse("2016-02-14") },
                new Employee{FirstName="Roy",Lastname="Paguio",MiddleName= "Cruz",  BirthDate=DateTime.Parse("1985-01-16"),  DateHired = DateTime.Parse("2016-01-14")},
                new Employee{FirstName="Mike",Lastname="Rodriguez",MiddleName= "Roxas",  BirthDate=DateTime.Parse("1990-07-24"),  DateHired = DateTime.Parse("2016-03-18")},
                new Employee{FirstName="Mark",Lastname="Hanopol",MiddleName= "Montano",  BirthDate=DateTime.Parse("1994-03-25"),  DateHired = DateTime.Parse("2016-04-10")},
                new Employee{FirstName="Chris",Lastname="Tiu",MiddleName= "Alvarez",  BirthDate=DateTime.Parse("1998-07-21"),  DateHired = DateTime.Parse("2016-03-05")},
                new Employee{FirstName="Jeff",Lastname="Chan",MiddleName= "Lee",  BirthDate=DateTime.Parse("1988-10-28"),  DateHired = DateTime.Parse("2016-05-15")},
                new Employee{FirstName="Naomi",Lastname="Mendoza",MiddleName= "Sison",  BirthDate=DateTime.Parse("1983-09-10"),  DateHired = DateTime.Parse("2016-06-21")},
                new Employee{FirstName="Pinky",Lastname="Webb",MiddleName= "Lopez",  BirthDate=DateTime.Parse("1990-08-01"),  DateHired = DateTime.Parse("2016-05-28")}
            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

           
        }
    }
}