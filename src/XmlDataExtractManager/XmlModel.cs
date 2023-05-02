using System.Xml.Serialization;

namespace XmlDataExtractManager
{
    [XmlRoot(ElementName = "FullAddress")]
    public class FullAddress
    {

        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }

        [XmlElement(ElementName = "City")]
        public string City { get; set; }

        [XmlElement(ElementName = "Region")]
        public string Region { get; set; }

        [XmlElement(ElementName = "PostalCode")]
        public int PostalCode { get; set; }

        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
    }

    [XmlRoot(ElementName = "Customer")]
    public class Customer
    {

        [XmlElement(ElementName = "CompanyName")]
        public string CompanyName { get; set; }

        [XmlElement(ElementName = "ContactName")]
        public string ContactName { get; set; }

        [XmlElement(ElementName = "ContactTitle")]
        public string ContactTitle { get; set; }

        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }

        [XmlElement(ElementName = "FullAddress")]
        public FullAddress FullAddress { get; set; }

        [XmlAttribute(AttributeName = "CustomerID")]
        public string CustomerID { get; set; }

        //[XmlText]
        //public string Text { get; set; }

        [XmlElement(ElementName = "Fax")]
        public string Fax { get; set; }
    }

    [XmlRoot(ElementName = "Customers")]
    public class Customers
    {

        [XmlElement(ElementName = "Customer")]
        public List<Customer> Customer { get; set; }
    }

    [XmlRoot(ElementName = "ShipInfo")]
    public class ShipInfo
    {

        [XmlElement(ElementName = "ShipVia")]
        public int ShipVia { get; set; }

        [XmlElement(ElementName = "Freight")]
        public double Freight { get; set; }

        [XmlElement(ElementName = "ShipName")]
        public string ShipName { get; set; }

        [XmlElement(ElementName = "ShipAddress")]
        public string ShipAddress { get; set; }

        [XmlElement(ElementName = "ShipCity")]
        public string ShipCity { get; set; }

        [XmlElement(ElementName = "ShipRegion")]
        public string ShipRegion { get; set; }

        [XmlElement(ElementName = "ShipPostalCode")]
        public int ShipPostalCode { get; set; }

        [XmlElement(ElementName = "ShipCountry")]
        public string ShipCountry { get; set; }

        [XmlAttribute(AttributeName = "ShippedDate")]
        public DateTime ShippedDate { get; set; }

        //[XmlText]
        //public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Order")]
    public class Order
    {

        [XmlElement(ElementName = "CustomerID")]
        public string CustomerID { get; set; }

        [XmlElement(ElementName = "EmployeeID")]
        public int EmployeeID { get; set; }

        [XmlElement(ElementName = "OrderDate")]
        public DateTime OrderDate { get; set; }

        [XmlElement(ElementName = "RequiredDate")]
        public DateTime RequiredDate { get; set; }

        [XmlElement(ElementName = "ShipInfo")]
        public ShipInfo ShipInfo { get; set; }
    }

    [XmlRoot(ElementName = "Orders")]
    public class Orders
    {

        [XmlElement(ElementName = "Order")]
        public List<Order> Order { get; set; }
    }

    [XmlRoot(ElementName = "Root")]
    public class Root
    {

        [XmlElement(ElementName = "Customers")]
        public Customers Customers { get; set; }

        [XmlElement(ElementName = "Orders")]
        public Orders Orders { get; set; }
    }    
}