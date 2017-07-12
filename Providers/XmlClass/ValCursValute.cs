using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExchangeRate.XmlClass
{
    public class ValCursValute
    {
        [XmlElementAttribute("CharCode")]
        public string ValuteStringCode;

        [XmlElementAttribute("Name")]
        public string ValuteName;

        [XmlElementAttribute("Value")]
        public string ExchangeRate;
    }
}
