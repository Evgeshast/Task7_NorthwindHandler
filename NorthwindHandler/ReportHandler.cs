using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using NorthwindDAL.Entities;
using NorthwindDAL.Repositories;

namespace NorthwindHandler
{
    public class ReportHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string dateFrom = context.Request.QueryString["dateFrom"];
            string dateTo = context.Request.QueryString["dateTo"];
            string take = context.Request.QueryString["take"];
            string skip = context.Request.QueryString["skip"];
            string customerId = context.Request.QueryString["customerId"];
            List<Order> orders = GetFilteredOrdersList(dateFrom, dateTo, take, skip, customerId);
            HttpResponse httpResponse;
            switch (context.Request.Headers.Get("Accept"))
            {
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                {
                    httpResponse = CreateExcelContentTypeResponse(context, orders);
                    break;
                }
                case "text/xml":
                {
                    httpResponse = CreateXmlContentTypeResponse(context, orders);
                    break;
                }
                default:
                {
                    httpResponse = CreateExcelContentTypeResponse(context, orders);
                    break;
                }
            }
        }

        private HttpResponse CreateXmlContentTypeResponse(HttpContext context, List<Order> orders)
        {
            HttpResponse httpResponse = context.Response;
            httpResponse.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "text/xml;charset=utf-8";
            XmlParser xmlParser = new XmlParser();
            string xmlString = xmlParser.GetOrdersReportXml(orders);
            httpResponse.Output.Write(xmlString);
            return httpResponse;
        }

        private HttpResponse CreateExcelContentTypeResponse(HttpContext context, List<Order> orders)
        {
            HttpResponse httpResponse = context.Response;
            httpResponse.StatusCode = (int)HttpStatusCode.OK;
            ExcelParser parser = new ExcelParser();
            var workbook = parser.GetOrderExcelFile(orders);
            httpResponse.Clear();
            httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            httpResponse.AddHeader("content-disposition", "attachment;filename=\"OrderReport.xlsx\"");
            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(httpResponse.OutputStream);
                memoryStream.Close();
            }
            httpResponse.End();
            return httpResponse;
        }

        private List<Order> GetFilteredOrdersList(string dateFrom, string dateTo, string take, string skip, string customerId)
        {
            OrdersRepository ordersRepository = new OrdersRepository();
            IEnumerable<Order> orders = ordersRepository.GetAll();

            if (dateFrom != null)
            {
                orders = orders.Where(x => x.OrderDate > DateTime.Parse(dateFrom));
            }

            if (dateTo != null)
            {
                orders = orders.Where(x => x.OrderDate < DateTime.Parse(dateTo));
            }

            if (skip != null)
            {
                orders = orders.Skip(int.Parse(skip));
            }

            if (take != null)
            {
                orders = orders.Take(int.Parse(take));
            }
            
            if (customerId != null)
            {
                orders = orders.Where(x => x.CustomerID == customerId);
            }

            return orders.OrderBy(x => x.OrderID).ToList();
        }

        public bool IsReusable => false;
    }
}
