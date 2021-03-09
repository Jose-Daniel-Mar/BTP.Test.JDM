using BTP.Test.JDM.BackEnd.API.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BPT.Test.JDM.FrontEnd.Client.Controllers
{
    class ClientControllerAssign
    {

        private string url = "https://localhost:44385/api";
        public async Task<AssignmentsStudent> CreateAssign(int idS, int idA)
        {
            AssignmentsStudent assignmentsStudent = new AssignmentsStudent();
            assignmentsStudent.IdStudent = idS;
            assignmentsStudent.IdAssignment = idA;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(url + "/AssignmentsStudents", assignmentsStudent);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<AssignmentsStudent>();
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<List<AssignmentsStudent>> ReadAssigns(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetJsonAsync<List<AssignmentsStudent>>(url + "/AssignmentsStudents");
                response = response.Where(x => x.IdStudent == id).ToList();
                return response;
            }
        }
        public async Task<AssignmentsStudent> ReadAssign(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetJsonAsync<AssignmentsStudent>(url + "/AssignmentsStudents/" + id);
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
        public async Task<int> DeleteAssign(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(url + "/AssignmentsStudents/" + id);
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
