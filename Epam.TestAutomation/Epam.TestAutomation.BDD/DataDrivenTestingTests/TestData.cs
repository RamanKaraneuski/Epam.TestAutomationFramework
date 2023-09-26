using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Epam.TestAutomation.BDD
{
    public class TestData
    {
        public static IEnumerable<TestCaseData> GetTestData()
        {
            var testDataJson = System.IO.File.ReadAllText("C:\\Save Visual Studio and Git\\1\\TAF\\Epam.TestAutomation\\Epam.TestAutomation.BDD\\DataDrivenTestingTests\\keywordTestData.json");
            var testData = JArray.Parse(testDataJson);

            foreach (var item in testData)
            {
                var keyword = item["keyword"].ToString();
                var expectedResults = item["expectedResults"].ToObject<List<string>>();

                yield return new TestCaseData(keyword, expectedResults).SetName(keyword);
            }
        }

        public static IEnumerable<TestCaseData> GetLocationTestData()
        {
            var testDataJson = File.ReadAllText("C:\\Save Visual Studio and Git\\1\\TAF\\Epam.TestAutomation\\Epam.TestAutomation.BDD\\DataDrivenTestingTests\\locationTestData.json");
            var testData = JArray.Parse(testDataJson);

            foreach (var item in testData)
            {
                var locationCountry = item["locationCountry"].ToString();
                var locationCity = item["locationCity"].ToString();
                var expectedResults = item["expectedResults"].ToObject<List<string>>();

                yield return new TestCaseData(locationCountry, locationCity, expectedResults)
                    .SetName($"{locationCountry}_{locationCity}");
            }
        }
        public static IEnumerable<TestCaseData> GetSkillsTestData()
        {
            var testDataJson = System.IO.File.ReadAllText("C:\\Save Visual Studio and Git\\1\\TAF\\Epam.TestAutomation\\Epam.TestAutomation.BDD\\DataDrivenTestingTests\\skillsTestData.json");
            var testData = JArray.Parse(testDataJson);

            foreach (var item in testData)
            {
                var skillsOne = item["skillsOne"].ToString();
                var skillsTwo = item["skillsTwo"].ToString();
                var expectedResults = item["expectedResults"].ToObject<List<string>>();

                yield return new TestCaseData(skillsOne, skillsTwo, expectedResults)
                    .SetName($"{skillsOne}_{skillsTwo}");
            }
        }

        public static IEnumerable<TestCaseData> GetCombinedTestData()
        {
            var testDataJson = System.IO.File.ReadAllText("C:\\Save Visual Studio and Git\\1\\TAF\\Epam.TestAutomation\\Epam.TestAutomation.BDD\\DataDrivenTestingTests\\combinedTestData.json");
            var testData = JArray.Parse(testDataJson);

            foreach (var item in testData)
            {
                var keyword = item["keyword"].ToString();
                var locationCountry = item["locationCountry"].ToString();
                var locationCity = item["locationCity"].ToString();
                var skillsOne = item["skillsOne"].ToString();
                var skillsTwo = item["skillsTwo"].ToString();
                var expectedResults = item["expectedResults"].ToObject<List<string>>();

                yield return new TestCaseData(keyword, locationCountry, locationCity, skillsOne, skillsTwo, expectedResults)
                    .SetName($"{keyword}_{locationCountry}_{locationCity}_{skillsOne}_{skillsTwo}");
            }
        }

        public static IEnumerable<TestCaseData> GetCombinedTestDataAndErrorChecking()
        {
            var testDataJson = File.ReadAllText("C:\\Save Visual Studio and Git\\1\\TAF\\Epam.TestAutomation\\Epam.TestAutomation.BDD\\DataDrivenTestingTests\\combinedTestDataErrorChecking.json");
            var testData = JArray.Parse(testDataJson);

            foreach (var item in testData)
            {
                var keyword = item["keyword"].ToString();
                var locationCountry = item["locationCountry"].ToString();
                var locationCity = item["locationCity"].ToString();
                var skillsOne = item["skillsOne"].ToString();
                var skillsTwo = item["skillsTwo"].ToString();
                var expectedResults = item["expectedResults"].ToObject<List<string>>();
                var errorMessage = item["errorMessage"].ToString();

                yield return new TestCaseData(keyword, locationCountry, locationCity, skillsOne, skillsTwo, expectedResults, errorMessage)
                    .SetName($"{keyword}_{locationCountry}_{locationCity}_{skillsOne}_{skillsTwo}_{errorMessage}");
            }
        }
    }
}