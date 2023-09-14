using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Epam.TestAutomation.API.Controllers;
using Epam.TestAutomation.API.Models.ResponseModels;
using NUnit.Framework;
using RestSharp;
using AllBiblesModel = Epam.TestAutomation.API.Models.ResponseModels.Bible.AllBiblesModel;

namespace Epam.TestAutomation.API.Tests
{
    [TestFixture]
    public class BiblesTests
    {
        [Test]
        public void CheckAllBiblesResponseWithValidParamslesson()
        {
            var response = new BiblesController(new CustomRestClient()).GetBibles<RestResponse>();
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Invalid status code was returned while sending GET request to /v1/audio-bibles!");
        }

        [Test]
        public void CheckAllBiblesResponseWithoutAuthorizationlesson()
        {
            var response = new BiblesController(new CustomRestClient(), string.Empty).GetBibles<RestResponse>();
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized),
                "Invalid status code was returned while sending GET request to /v1/bibles without authorization!");
        }

        [Test]
        public void CheckAllBiblesResponseReturnObjectlesson()
        {
            var response = new BiblesController(new CustomRestClient()).GetBibles<AllBiblesModel>();
            Assert.That(response.Bibles.data.Any, Is.True, "GET request to /v1/bibles should return any object!");
        }

        [Test]
        public void CheckSingleBibleResponseWithValidParamslesson()
        {
            var bibles = new BiblesController(new CustomRestClient()).GetBibles<AllBiblesModel>().Bibles.data;

            var response = new BiblesController(new CustomRestClient()).GetBible<RestResponse>(bibles.First().id);

            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Invalid status code was returned while sending GET request to /v1/bibles{id}!");
        }

        [Test]
        public void CheckAllBiblesResponseWithValidParams()
        {
            var response = new BiblesController(new CustomRestClient()).GetBibles<RestResponse>();
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Invalid status code was returned while sending GET request to /v1/audio-bibles!");
        }
        [Test]
        public void CheckSingleBibleResponseWithValidParams()
        {
            var biblesController = new BiblesController(new CustomRestClient());
            var bibles = biblesController.GetBibles<AllBiblesModel>().Bibles.data;

            if (bibles.Length > 0)
            {
                var response = biblesController.GetBible<RestResponse>(bibles[0].id);

                Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Invalid status code was returned while sending GET request to /v1/audio-bibles/{id}!");
            }
            else
            {
                Assert.Ignore("No audio bibles found to test single bible response.");
            }
        }

        [Test]
        public void CheckAllBiblesResponseWithoutAuthorization()
        {
            var response = new BiblesController(new CustomRestClient(), string.Empty).GetBibles<RestResponse>();
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized),
                "Invalid status code was returned while sending GET request to /v1/audio-bibles without authorization!");
        }
        [Test]
        public void CheckResponseToGetObjectsEndpoint()
        {
            var restClient = new CustomRestClient();
            var response = restClient.CreateRestClient(Service.Phones).ExecuteGet(new RestRequest("/objects"));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Invalid status code was returned while sending GET request to /objects!");
        }

        [Test]
        public void CheckObjectListCount()
        {
            var restClient = new CustomRestClient();
            var response = restClient.CreateRestClient(Service.Phones).ExecuteGet(new RestRequest("/objects"));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Invalid status code was returned while sending GET request to /objects!");

            var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<object[]>(response.Content);
            Assert.That(responseObject.Length, Is.GreaterThan(0), "The object list should contain at least one item.");
        }

 
    }
}
