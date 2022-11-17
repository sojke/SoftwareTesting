using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PRO2ST2223PE;

public class BoredApiService : IBoredApiService
{
    public BoredResponse GetBoredResponse()
    {
        string url = "https://www.boredapi.com/api/activity";

        using (var httpClient = new HttpClient())
        {
            var httpRespone = httpClient.GetAsync(url).GetAwaiter().GetResult();
            var response = httpRespone.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoredResponse>(response);
        }
    }
}
