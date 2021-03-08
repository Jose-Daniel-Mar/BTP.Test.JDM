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
    class ClientControllerStudents
    {
        private string url = "https://localhost:44385/api";
        public async Task<Student> CreateStudent(Student student)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(url + "/Students", student);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Student>();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Student>> ReadStudents()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetJsonAsync<List<Student>>(url + "/Students");
                return response;
            }
        }

        public async Task<Student> ReadStudent(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetJsonAsync<Student>(url + "/Students/" + id);
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

        public async Task<Student> PutStudent(Student student)
        {
            using (var httpClient = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(student);
                HttpContent httpContent = new StringContent(jsonString);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PutAsync(url + "/students/" + student.Id, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    return student;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<int> DeleteStudent(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(url + "/Students/" + id);
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
