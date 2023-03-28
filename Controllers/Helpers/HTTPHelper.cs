using Microsoft.AspNetCore.Mvc;
using Pizzas.API.Models;
using Pizzas.API.Utils;

namespace OMDB.API.Controllers
{
    public static class HTTPHelper
    {
        public static async Task<string> GetContentAsync(string targetURL, string defaultValueOnError)
        {
            string returnValue;
            HttpClient httpClient;
            returnValue = defaultValueOnError;
            httpClient = new HttpClient();
            try
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(targetURL))
                {
                    returnValue = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                returnValue = defaultValueOnError;
            }
            return returnValue;
        }
    }
}