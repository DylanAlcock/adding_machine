using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AddingMachine.Tests
{
    [TestClass]
    public class OperatorControllerTest
    {
        /// <summary>
        /// Testing the operator endpoint to make 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Post_SolveEquation_ReturnsCorrectResult()
        {
            string data = "23+7-10*2";
            string json = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, mediaType: "application/json");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync("https://localhost:7166/api/Operator", stringContent);
            dynamic responseBody = await response.Content.ReadAsStringAsync();
            JObject jsonData = JsonConvert.DeserializeObject(responseBody);
            Assert.AreEqual(10, (int)jsonData["calc"]);
        }

        /// <summary>
        /// Testing the sqrt operator endpoint, to make sure values are calculated correctly
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task PostSqrt_SolveSqrt_ReturnsSqrtOfValue()
        {
            string data = "49";
            string json = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, mediaType: "application/json");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync("https://localhost:7166/api/Operator/sqrt", stringContent);
            dynamic responseBody = await response.Content.ReadAsStringAsync();
            JObject jsonData = JsonConvert.DeserializeObject(responseBody);
            Assert.AreEqual(7, (int)jsonData["calc"]);
        }

        /// <summary>
        /// Testing the square operator endpoint, to make sure values are calculated correctly
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task PostSquare_SolveSqrt_ReturnsSquareOfValue()
        {
            string data = "4";
            string json = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, mediaType: "application/json");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync("https://localhost:7166/api/Operator/square", stringContent);
            dynamic responseBody = await response.Content.ReadAsStringAsync();
            JObject jsonData = JsonConvert.DeserializeObject(responseBody);
            Assert.AreEqual(16, (int)jsonData["calc"]);
        }
    }
}