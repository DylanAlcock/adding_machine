using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AddingMachine.Tests
{
    [TestClass]
    public class HistoryControllerTest
    {
        /// <summary>
        /// Tests the delete history method to check if correct status code is returned
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task DeleteHistory_DeletesAllHistoryEntries_ReturnsOKStatus()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync("https://localhost:7166/api/History");
            string responseBody = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Tests the add history method to check if the correct status code is returned
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task AddHistory_AddHistoryEntry_ReturnsOKStatus()
        {
            string data = "23+7 = 30";
            string json = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, mediaType: "application/json");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync("https://localhost:7166/api/History", stringContent);
            string responseBody = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        /// <summary>
        /// Tests the get history method to check if the correct status code is returned
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetHistory_ReturnsAllEntries_ReturnsOKStatus()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7166/api/History");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}