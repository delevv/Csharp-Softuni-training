namespace MusicHub.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class ImportProducerDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359\s\d{3}\s\d{3}\s\d{3}$")]
        public string PhoneNumber { get; set; }

        public ImportAlbumDTO[] Albums { get; set; }
    }
}
