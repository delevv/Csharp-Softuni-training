using System;
using System.Linq;

namespace P04_Hospital
{
    public class Engine
    {
        private Hospital hospital;

        public Engine()
        {
            this.hospital = new Hospital();
        }

        public void Run()
        {
            var command = Console.ReadLine();

            while (command != "Output")
            {
                var arguments = command.Split();

                var department = arguments[0];

                var doctorFirstName = arguments[1];
                var doctorSecondName = arguments[2];
                var doctorFullName = doctorFirstName + " " + doctorSecondName;

                var patientName = arguments[3];

                this.hospital.AddDoctor(doctorFirstName, doctorSecondName);
                this.hospital.AddDepartment(department);
                this.hospital.AddPatient(department, doctorFullName, patientName);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                var arguments = command.Split();

                if (arguments.Length == 1)
                {
                    var departmentName = arguments[0];
                    var department = this.hospital.Departmens.FirstOrDefault(de => de.Name == departmentName);

                    Console.WriteLine(department);
                }
                else
                {
                    var isRoom = int.TryParse(arguments[1], out int resultRoom);

                    if (isRoom)
                    {
                        var departmentName = arguments[0];
                        var department = this.hospital.Departmens.FirstOrDefault(de => de.Name == departmentName);

                        var currentRoom = department.Rooms[resultRoom-1];

                        Console.WriteLine(currentRoom);
                    }
                    else
                    {
                        var firstName = arguments[0];
                        var lastName = arguments[1];

                        var fullName = firstName + " " + lastName;
                        var doctor = this.hospital.Doctors.FirstOrDefault(d => d.FullName == fullName);

                        Console.WriteLine(doctor);
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
