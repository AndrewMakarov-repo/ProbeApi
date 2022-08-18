using FluentAssertions;
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

            // в arrange сделать expectedResult (необходимо прописать структуру json//см.в инете)
        {
            // arrange
            var expectedResult = new List<FactItem>()
            {
                new FactItem {Fact="Unlike dogs, cats do not have a sweet tooth. Scientists believe this is due to a mutation in a key taste receptor.", Length = 114},
                new FactItem {Fact="When a cat chases its prey, it keeps its head level. Dogs and humans bob their heads up and down.", Length = 97},
                new FactItem {Fact="The technical term for a cat’s hairball is a “bezoar.”", Length = 54},
                new FactItem {Fact="A group of cats is called a “clowder.”", Length = 38},
                new FactItem {Fact="A cat can’t climb head first down a tree because every claw on a cat’s paw points the same way. To get down from a tree, a cat must back down.", Length = 142}
            };
            
            RestClient client = new RestClient("https://catfact.ninja");
            RestRequest request = new RestRequest($"/facts", Method.Get);
            request.AddQueryParameter("limit", 5);

            // act
            RestResponse response = client.Execute(request);
            List<FactItem> actualResult = JsonConvert.DeserializeObject<FactsDTO>(response.Content).Data;

            // assert
            //Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
            actualResult.Should().BeEquivalentTo(expectedResult); //fluent assertion
        }
    }
}