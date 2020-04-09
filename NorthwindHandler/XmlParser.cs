using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NorthwindDAL.Entities;
using NorthwindDAL.Repositories;

namespace NorthwindHandler
{
    public class XmlParser
    {
        public string GetOrdersReportXml(IEnumerable<Order> orders)
        {
            string xmlString;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Order>));
            OrdersRepository ordersRepository = new OrdersRepository();
            using (StringWriter xmlStringWriter = new StringWriter(CultureInfo.CurrentCulture))
            {
                XmlWriter xmlWriter = XmlWriter.Create(xmlStringWriter);
                formatter.Serialize(xmlWriter, orders);
                xmlString = Convert.ToString(xmlStringWriter);
            }
            return xmlString;
        }
    }
}
