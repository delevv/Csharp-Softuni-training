using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }

        [Key]
        public int DoctorId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; }
    }
}
