namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Projection")]
    public class ImportProjectionDTO
    {
        [Range(1, int.MaxValue)]
        public int MovieId { get; set; }

        [Range(1, int.MaxValue)]
        public int HallId { get; set; }

        [Required]
        public string DateTime { get; set; }
    }
}
