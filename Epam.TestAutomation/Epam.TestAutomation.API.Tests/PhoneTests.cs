﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Epam.TestAutomation.API.Controllers;
using Epam.TestAutomation.API.Models.RequesModels.Phone;
using Epam.TestAutomation.API.Models.ResponseModels.Phone;
using Epam.TestAutomation.API.Models.SharedMoels.Phone;
using NUnit.Framework;
using RestSharp;

namespace Epam.TestAutomation.API.Tests
{
    [TestFixture]
    public class PhoneTests
    {
        [Test]
        public void VerifyAllPhonesResponse()
        {
            var response = new PhoneController(new CustomRestClient()).GetPhones<List<Phone>>();
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code for GET /objects request!");
        }

        [Test]
        public void VerifySinglePhoneResponse()
        {
            var phone = new PhoneController(new CustomRestClient()).GetPhones<List<Phone>>().AllPhones.First();

            var response = new PhoneController(new CustomRestClient()).GetPhone<Phone>(phone.id);
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code for GET /objects/{id} request!");
        }

        [Test]
        public void VerifyAbilityToAddPhone()
        {
            var phoneToCreate = new PhoneModel
            {
                name = "Samsung Galaxy A75",
                data = new PhoneData
                {
                    price = 1700,
                    year = 2049
                }
            };

            var createdPhone = new PhoneController(new CustomRestClient()).AddPhone<Phone>(phoneToCreate).Phone;

            var receivedPhone = new PhoneController(new CustomRestClient()).GetPhone<Phone>(createdPhone.id).Phone;

            Assert.That(receivedPhone, Is.Not.Null, $"Phone with id {createdPhone.id} was not created!");
        }

        [Test]
        public void CreatePhoneWithSpecificCapacity()
        {
            var phoneToCreate = new PhoneModel
            {
                name = "Samsung Galaxy S1212",
                data = new PhoneData
                {
                    CapacityGb = 512,
                }
            };

            var createdPhone = new PhoneController(new CustomRestClient()).AddPhone<Phone>(phoneToCreate).Phone;

            Assert.AreEqual(512, createdPhone.data.CapacityGb);

            var response = new PhoneController(new CustomRestClient()).DeletePhone<RestResponse>(createdPhone.id);
            Assert.AreEqual(HttpStatusCode.OK, response.Response.StatusCode);
        }

        [Test]
        public void CreateAndDeleteRandomPhone()
        {
            var randomPhone = new PhoneModel
            {
                name = "Samsung Galaxy 235G",
                data = new PhoneData
                {
                    CapacityGb = 512,
                    price = new Random().Next(100, 1000),
                    year = new Random().Next(2010, 2023)
                }
            };

            var createdPhone = new PhoneController(new CustomRestClient()).AddPhone<Phone>(randomPhone).Phone;

            var response = new PhoneController(new CustomRestClient()).DeletePhone<RestResponse>(createdPhone.id);
            Assert.AreEqual(HttpStatusCode.OK, response.Response.StatusCode);

            var getResponse = new PhoneController(new CustomRestClient()).GetPhone<Phone>(createdPhone.id);
            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.Response.StatusCode);
        }

        [Test]
        public void UpdatePhoneProperty()
        {
            var phoneToCreate = new PhoneModel
            {
                name = "Samsung Galaxy 1TB",
                data = new PhoneData
                {
                    CapacityGb = 1024,
                    price = 2000,
                    year = 2026

                }
            };

            var createdPhone = new PhoneController(new CustomRestClient()).AddPhone<Phone>(phoneToCreate).Phone;

            var updatedPhoneModel = new PhoneModel
            {
                name = createdPhone.name,
                data = new PhoneData
                {
                    CapacityGb = 1025,
                    price = 3000,
                    year = createdPhone.data.year
                }
            };

            var updateResponse = new PhoneController(new CustomRestClient()).UpdatePhone<Phone>(createdPhone.id, updatedPhoneModel);

            Assert.AreEqual(HttpStatusCode.OK, updateResponse.Response.StatusCode);

            var updatedPhone = new PhoneController(new CustomRestClient()).GetPhone<Phone>(createdPhone.id).Phone;
            Assert.AreEqual(300, updatedPhone.data.CapacityGb, updatedPhone.data.price);

            var deleteResponse = new PhoneController(new CustomRestClient()).DeletePhone<RestResponse>(updatedPhone.id);
            Assert.AreEqual(HttpStatusCode.OK, deleteResponse.Response.StatusCode);
        }
    }
}
