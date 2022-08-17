using NUnit.Framework;
using RestSharp;
using System.Net;

namespace ProbeApi
{
    public class TestsForCats
    {
        [SetUp]
        public void Setup()
        {
        }
        [TestCase( HttpStatusCode.OK)]
        [TestCase( HttpStatusCode.OK)]
        public void CatFacts(HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            RestClient client = new RestClient("https://catfact.ninja");
            RestRequest request = new RestRequest($"/facts", Method.Get);
            
            // act
            var response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }
    }
}