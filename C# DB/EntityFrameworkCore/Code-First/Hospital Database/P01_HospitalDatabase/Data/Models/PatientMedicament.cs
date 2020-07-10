using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Medicament")]
        public int MedicamentId { get; set; }
        public Medicament Medicament { get; set; }
    }
}
