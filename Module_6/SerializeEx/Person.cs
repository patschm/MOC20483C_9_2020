using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SerializeEx
{
    [XmlRoot("people")]
    public class Person
    {
        [XmlAttribute("id")]
        public int ID { get; set; }
        [XmlElement("first-name")]
        public string FirstName { get; set; }
        [XmlElement("last-name")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int Age { get; set; }

        public override string ToString()
        {
            return $"[{ID}] {FirstName} {LastName} ({Age})";
        }
    }
}
