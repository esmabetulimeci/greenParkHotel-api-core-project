using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RapidApiConsume.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {

            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "d3a0d8f338mshc4b0fb870141aeap1e2c55jsn3cc2fa7846bf" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(model.Take(1).ToList());
                }
            }
            else
            {
                List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Paris&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "d3a0d8f338mshc4b0fb870141aeap1e2c55jsn3cc2fa7846bf" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(model.Take(1).ToList());
                }
            }

        }

    }
    
}

