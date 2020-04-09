using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using NorthwindDAL.Entities;
using NorthwindDAL.Repositories;

namespace NorthwindHandler
{
    public class ExcelParser
    {
        public XLWorkbook GetOrderExcelFile(List<Order> orders)
        {
            OrdersRepository ordersRepository = new OrdersRepository();
            var excel = new XLWorkbook();
            var worksheet = excel.Worksheets.Add("OrdersReport");
            worksheet.Cell("A1").Value = "OrderID";
            worksheet.Cell("B1").Value = "CustomerID";
            worksheet.Cell("C1").Value = "EmployeeID";
            worksheet.Cell("D1").Value = "OrderDate";
            worksheet.Cell("E1").Value = "RequiredDate";
            worksheet.Cell("F1").Value = "ShippedDate";
            worksheet.Cell("G1").Value = "ShipVia";
            worksheet.Cell("H1").Value = "Freight";
            worksheet.Cell("I1").Value = "ShipName";
            worksheet.Cell("J1").Value = "ShipAddress";
            worksheet.Cell("K1").Value = "ShipCity";
            worksheet.Cell("M1").Value = "ShipRegion";
            worksheet.Cell("N1").Value = "ShipPostalCode";
            worksheet.Cell("L1").Value = "ShipCountry";
            foreach (var order in orders)
            {
                int index = orders.IndexOf(order) + 2;
                worksheet.Cell($"A{index}").Value = order.OrderID;
                worksheet.Cell($"B{index}").Value = order.CustomerID;
                worksheet.Cell($"C{index}").Value = order.EmployeeID;
                worksheet.Cell($"D{index}").Value = order.OrderDate;
                worksheet.Cell($"E{index}").Value = order.RequiredDate;
                worksheet.Cell($"F{index}").Value = order.ShippedDate;
                worksheet.Cell($"G{index}").Value = order.ShipVia;
                worksheet.Cell($"H{index}").Value = order.Freight;
                worksheet.Cell($"I{index}").Value = order.ShipName;
                worksheet.Cell($"J{index}").Value = order.ShipAddress;
                worksheet.Cell($"K{index}").Value = order.ShipCity;
                worksheet.Cell($"M{index}").Value = order.ShipRegion;
                worksheet.Cell($"N{index}").Value = order.ShipPostalCode;
                worksheet.Cell($"L{index}").Value = order.ShipCountry;
            }
            return excel;
        }
    }
}
