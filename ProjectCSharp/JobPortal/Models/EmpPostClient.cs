using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using EmpRepoService;
using EmpPostRepository;
using System.Text;

namespace EmpPostMVC.Models
{
    public class EmpPostClient
    {
        public HttpClient webApi;
        public EmpPostClient()
        {
            webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:64058/api/emppostapi/");
        }
        public async Task DeleteEmpAsync(string postId)
        {
            await webApi.DeleteAsync("" + postId);
        }
        public async Task<List<EmpPost>> GetAllEmpPost()
        {
            HttpResponseMessage response = await webApi.GetAsync("");
            string str = await response.Content.ReadAsStringAsync();
            List<EmpPost> Emps = JsonConvert.DeserializeObject<List<EmpPost>>(str);
            return Emps;
        }
        public async Task<EmpPost> GetEmpByIdAsync(string postId)
        {
            try
            {
                HttpResponseMessage response = await webApi.GetAsync("" + postId);
                string str = await response.Content.ReadAsStringAsync();
                EmpPost epost = JsonConvert.DeserializeObject<EmpPost>(str);
                return epost;
            }
            catch (Exception)
            {
                throw new Exception("No such post id");
            }
        }





        public async Task InsertEmpAsync(EmpPost Emp)
        {
            var json = JsonConvert.SerializeObject(Emp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PostAsync("", data);



        }

        public async Task UpdateEmpAsync(string postId, EmpPost Emp)
        {
            var json = JsonConvert.SerializeObject(Emp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PutAsync("" + postId, data);
        }
    }
}
