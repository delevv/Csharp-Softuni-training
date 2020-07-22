using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Category")]
    public class ExportCategoryByProductsDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int CountOfProducts { get; set; }

        [XmlElement("averagePrice")]
        public decimal AvgPrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
