using Castle.DynamicProxy.Contributors;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class ImportBookDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1, 3)]
        [XmlElement("Genre")]
        public int Genre { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        [Range(50, 5000)]
        [XmlElement("Pages")]
        public int Pages { get; set; }

        [XmlElement("PublishedOn")]
        public string PublishedOn { get; set; }
    }
}
