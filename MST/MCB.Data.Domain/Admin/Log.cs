using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MCB.Data.Domain.Admin
{
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Exception { get; set; }
        public string LogEvent { get; set; }
        [Column(TypeName = "xml")]
        public string Properties { get; set; }
        [NotMapped]
        public XElement PropertiesXml { get; }
    }
}
