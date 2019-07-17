using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
    class Department
    {
        public string Name { get; set; }
        public double AvgSalary { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Employee> employers = new List<Employee>();
            List<Department> departments = new List<Department>();

            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine().Split();

                Employee currentEmployee = new Employee();
                currentEmployee.Name = info[0];
                currentEmployee.Salary = double.Parse(info[1]);
                currentEmployee.Department = info[2];
                employers.Add(currentEmployee);

                if(!departments.Any(x => x.Name == currentEmployee.Department))
                {
                    Department department = new Department();
                    department.Name = currentEmployee.Department;
                    departments.Add(department);
                }
            }

            foreach (var department in departments)
            {
                double avgSalary = 0;
                foreach (var employee in employers)
                {
                    if (employee.Department == department.Name)
                    {
                        avgSalary += employee.Salary;
                    }
                }
                department.AvgSalary = avgSalary;
            }

            departments = departments.OrderBy(x => x.AvgSalary).ToList();
            employers = employers.OrderByDescending(x => x.Salary).ToList();
            Console.WriteLine($"Highest Average Salary: {departments[departments.Count-1].Name}");
            foreach (var employee in employers)
            {
                if (employee.Department == departments[departments.Count - 1].Name)
                {
                    Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
                }
            }
        }
    }
}
