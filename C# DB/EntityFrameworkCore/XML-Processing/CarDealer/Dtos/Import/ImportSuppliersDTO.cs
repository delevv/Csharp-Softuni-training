using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Supplier")]
    public class ImportSuppliersDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
