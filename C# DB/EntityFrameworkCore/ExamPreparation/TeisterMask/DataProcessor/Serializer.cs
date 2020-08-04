namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(p => p.Tasks.Count > 0)
                .ToArray() // for judje system
                .Select(p => new ExportProjectDTO()
                {
                    Name = p.Name,
                    TasksCount = p.Tasks.Count,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks
                                .Select(t => new ExportTaskDTO()
                                {
                                    Name = t.Name,
                                    LabelType = t.LabelType.ToString()
                                })
                                .OrderBy(t => t.Name)
                                .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.Name)
                .ToArray();

            var result = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDTO[]), new XmlRootAttribute("Projects"));
            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            using (var writter = new StringWriter(result))
            {
                xmlSerializer.Serialize(writter, projects, xmlNamespaces);
            }

            return result.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .AsEnumerable()
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                                .Where(et => et.Task.OpenDate >= date)
                                .OrderByDescending(et => et.Task.DueDate)
                                .ThenBy(et => et.Task.Name)
                                .Select(et => new
                                {
                                    TaskName = et.Task.Name,
                                    OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                    DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                    LabelType = et.Task.LabelType.ToString(),
                                    ExecutionType = et.Task.ExecutionType.ToString()
                                })
                                .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}