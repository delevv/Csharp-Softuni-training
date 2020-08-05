namespace MusicHub.DataProcessor.ImportDtos
{
    using Castle.DynamicProxy.Generators.Emitters;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportSongDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        public string Genre { get; set; }

        public int? AlbumId { get; set; }

        [Required]
        public int WriterId { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
