namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using System.Text;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using Castle.Core.Internal;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Microsoft.EntityFrameworkCore.Internal;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectDTO[]), new XmlRootAttribute("Projects"));

            var result = new StringBuilder();

            using (var reader = new StringReader(xmlString))
            {
                var projectsDtos = (ImportProjectDTO[])xmlSerializer.Deserialize(reader);

                var projects = new List<Project>();

                foreach (var projectDto in projectsDtos)
                {
                    if (!IsValid(projectDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime projectOpenDate;

                    var isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                    if (!isProjectOpenDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime? projectDueDate;

                    if (!projectDto.DueDate.IsNullOrEmpty())
                    {
                        DateTime projectDueDateValue;

                        var isProjectDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDateValue);

                        if (!isProjectDueDateValid)
                        {
                            result.AppendLine(ErrorMessage);
                            continue;
                        }

                        projectDueDate = projectDueDateValue;
                    }
                    else
                    {
                        projectDueDate = null;
                    }

                    var currentProject = new Project()
                    {
                        Name = projectDto.Name,
                        OpenDate = projectOpenDate,
                        DueDate = projectDueDate
                    };

                    foreach (var taskDto in projectDto.Tasks)
                    {
                        if (!IsValid(taskDto))
                        {
                            result.AppendLine(ErrorMessage);
                            continue;
                        }

                        DateTime taskOpenDate;

                        var isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                        if (!isTaskOpenDateValid)
                        {
                            result.AppendLine(ErrorMessage);
                            continue;
                        }

                        DateTime taskDueDate;

                        var isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                        if (!isTaskDueDateValid)
                        {
                            result.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (taskOpenDate < projectOpenDate)
                        {
                            result.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (projectDueDate.HasValue)
                        {
                            if (taskDueDate > projectDueDate)
                            {
                                result.AppendLine(ErrorMessage);
                                continue;
                            }
                        }

                        var currentTask = new Task()
                        {
                            Name = taskDto.Name,
                            OpenDate = taskOpenDate,
                            DueDate = taskDueDate,
                            ExecutionType = (ExecutionType)taskDto.ExecutionType,
                            LabelType = (LabelType)taskDto.LabelType,
                        };

                        currentProject.Tasks.Add(currentTask);
                    }

                    projects.Add(currentProject);
                    result.AppendLine(string.Format(SuccessfullyImportedProject, currentProject.Name, currentProject.Tasks.Count));
                }

                context.Projects.AddRange(projects);
                context.SaveChanges();

                return result.ToString().TrimEnd();
            }
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {

            var empoloyeesDtos = JsonConvert.DeserializeObject<ImportEmployeeDTO[]>(jsonString);

            var employees = new List<Employee>();

            var result = new StringBuilder();

            foreach (var employeeDto in empoloyeesDtos)
            {
                if (!IsValid(employeeDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var currentEmployee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskId);

                    if (task == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    currentEmployee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Task = task,
                        Employee = currentEmployee
                    });
                }

                employees.Add(currentEmployee);
                result.AppendLine(string.Format(SuccessfullyImportedEmployee, currentEmployee.Username, currentEmployee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}