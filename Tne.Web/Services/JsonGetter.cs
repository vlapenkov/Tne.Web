using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tne.Web.Services
{
    public class JsonGetter : IJsonGetter
    {

   public async Task<string>  GetAsync(string url) {

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync(url);
                    return json;
                    // Now parse with JSON.Net
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

    }
}
