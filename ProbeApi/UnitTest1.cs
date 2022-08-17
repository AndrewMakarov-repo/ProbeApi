using NUnit.Framework;
using RestSharp;
using System.Net;

namespace ProbeApi
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [TestCase("nl", "1020", HttpStatusCode.OK)]
        [TestCase("lt", "00001", HttpStatusCode.OK)]
        [TestCase("li", "0005", HttpStatusCode.NotFound)]
        [TestCase("ru", "1000", HttpStatusCode.NotFound)]
        [TestCase("ru", "5", HttpStatusCode.NotFound)]
        public void StatusCodeVerification(string countryCode, string zipCode, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest($"{countryCode}/{zipCode}", Method.Get);
            
            // act
            var response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }
    }
}