using Newtonsoft.Json;
using NUnit.Framework;
using ProbeApi.ModelForCats;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace ProbeApi
{
    public class TestsForCats
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void CatFacts()

            // в arrange сделать expectedResult
        {
            // arrange
            RestClient client = new RestClient("https://catfact.ninja");
            RestRequest request = new RestRequest($"/facts", Method.Get);
            request.AddQueryParameter("limit", 5);

            // act
            RestResponse response = client.Execute(request);
            List<FactItem> actualResult = JsonConvert.DeserializeObject<FactsDTO>(response.Content).Data;

            // assert
            //Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
            //actualResult.Should().BeEquivalentTo(expectedResult); //fluent assertion
        }
    }
}