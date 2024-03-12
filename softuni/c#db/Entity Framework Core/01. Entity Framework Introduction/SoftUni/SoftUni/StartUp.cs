using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            Console.WriteLine(RemoveTown(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            }).ToList();

            string result = string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"));

            return result;
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new
            {
                e.FirstName,
                e.Salary
            }).Where(e => e.Salary > 50000)
              .OrderBy(e => e.FirstName)
              .ToList();

            string result = string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} - {e.Salary:f2}"));

            return result;
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var rndEmployees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            string result = string.Join(Environment.NewLine,
                rndEmployees.Select(e => $"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}"));

            return result;
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = address;
            context.SaveChanges();

            var employees = context.Employees.Select(e => new
            {
                e.AddressId,
                e.Address.AddressText
            })
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .ToList();

            return string.Join(Environment.NewLine, employees.Select(e => $"{e.AddressText}"));
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var EmployeeInfo = context.Employees
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Where(ep => ep.Project.StartDate.Year >= 2001 & ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate != null
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                : "not finished"
                        })
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in EmployeeInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                if (e.Projects.Any())
                {
                    sb.AppendLine(String.Join(Environment.NewLine, e.Projects
                        .Select(p => $"--{p.ProjectName} - {p.StartDate} - {p.EndDate}")));
                }
            }

            return sb.ToString().TrimEnd();
    }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    a.Town.Name,
                    a.Employees.Count
                })
                .ToList();
            return string.Join(Environment.NewLine, addresses.Select(a => $"{a.AddressText}, {a.Name} - {a.Count} employees"));
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .FirstOrDefault(e => e.EmployeeId == 147);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var ep in employee.EmployeesProjects.OrderBy(x => x.Project.Name))
            {
                sb.AppendLine(ep.Project.Name);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        EmployeeJobTitle = e.JobTitle
                    })
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} – {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.EmployeeJobTitle}");
                }
            }
                return sb.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString().TrimEnd();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var salaries = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                e.Department.Name == "Tool Design" ||
                e.Department.Name == "Marketing" ||
                e.Department.Name == "Information Services")
                .ToList();

            foreach (var salary in salaries)
            {
                salary.Salary *= 1.12m;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in salaries.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
            {
                var employees = context.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle,
                            e.Salary
                        })
                        .Where(e => e.FirstName.StartsWith("Sa"))
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToList();

                return string.Join(Environment.NewLine, 
                    employees.Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})"));
            }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDelete = context.Projects.FirstOrDefault(p => p.ProjectId == 2);

            var employeesToBeDeleted = context.EmployeesProjects
                .Where(ep => ep.ProjectId == projectToDelete.ProjectId)
                .ToList();

            context.EmployeesProjects.RemoveRange(employeesToBeDeleted);

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects
               .Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }
        public static string RemoveTown(SoftUniContext context)
        {
            var townToRemove = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            var addressesToDelete = context.Addresses.Where(a => a.TownId == townToRemove.TownId);

            int countOfDeletedAddresses = addressesToDelete.Count();

            var employees = context.Employees
                .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToDelete);

            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            return $"{countOfDeletedAddresses} addresses in Seattle were deleted";

        }
    }
}