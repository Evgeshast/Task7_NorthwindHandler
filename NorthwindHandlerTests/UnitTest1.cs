using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NorthwindHandlerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using(var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44300/Report");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "text/xml");
                var status = client.SendAsync(request).Result.StatusCode;
                Assert.AreEqual(HttpStatusCode.OK, status);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44300/Report");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "text/xml");
                var content = client.SendAsync(request).Result.Content;
                Assert.AreNotEqual(0, content.ReadAsStringAsync().Result.Length);
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44300/Report");
                request.Method = HttpMethod.Get;    
                request.Headers.Add("Accept", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                var content = client.SendAsync(request).Result.Content;
                Assert.AreNotEqual(0, content.ReadAsStringAsync().Result.Length);
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44300/Report");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                var content = client.SendAsync(request).Result.Content;
                Assert.AreNotEqual(0, content.ReadAsStringAsync().Result.Length);
            }
        }


        [TestMethod]
        public void TestMethod5()
        {
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44300/Report?dateFrom=7/4/1996");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "text/xml");
                var content = client.SendAsync(request).Result.Content;
                Assert.AreNotEqual(0, content.ReadAsStringAsync().Result.Length);
            }
        }

        [TestMethod]
        public void TestMethod6()
        {
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44300/Report?dateTo=9/17/1997");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "text/xml");
                var content = client.SendAsync(request).Result.Content;
                Assert.AreNotEqual(0, content.ReadAsStringAsync().Result.Length);
            }
        }

        [TestMethod]
        public void TestMethod7()
        {
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44300/Report?take=100");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "text/xml");
                var content = client.SendAsync(request).Result.Content;
                Assert.AreNotEqual(0, content.ReadAsStringAsync().Result.Length);
            }
        }

        [TestMethod]
        public void TestMethod8()
        {
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44300/Report?skip=10");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "text/xml");
                var content = client.SendAsync(request).Result.Content;
                Assert.AreNotEqual(0, content.ReadAsStringAsync().Result.Length);
            }
        }
    }
}
