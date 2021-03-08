using BTP.Test.JDM.BackEnd.API.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BPT.Test.JDM.FrontEnd.Client.Controllers
{
    class ClientControllerAssignments
    {

        private string url = "https://localhost:44385/api";
        public async Task<Assignment> CreateAssignment(Assignment assignment)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(url + "/Assignments", assignment);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Assignment>();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Assignment>> ReadAssignments()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetJsonAsync<List<Assignment>>(url + "/Assignments");
                return response;
            }
        }

        public async Task<Assignment> ReadAssignment(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetJsonAsync<Assignment>(url + "/Assignments/" + id);
                if (response != null)
                {
                    return response;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Assignment> PutAssignment(Assignment assignment)
        {
            using (var httpClient = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(assignment);
                HttpContent httpContent = new StringContent(jsonString);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PutAsync(url + "/Assignments/" + assignment.Id, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    return assignment;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<int> DeleteAssignment(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(url + "/Assignments/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return id;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
