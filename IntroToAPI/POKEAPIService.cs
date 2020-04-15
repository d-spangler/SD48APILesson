using IntroToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI
{
    public class POKEAPIService //This is us building methods to use with our API. This way we can call a method to do the work for us.
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Pokemon> GetPokemonAsync(string url)
        //This is so we can pass in any of the objects that we call on, not just Bulbasaur like we previously did in Program.
        //Without "Task<>" the async doesn't work. Async returns a task.
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            //Instead of using the .Result like we used on the program page, we're using await to return the outcome.

            if (response.IsSuccessStatusCode)
            {
                Pokemon pokemon = await response.Content.ReadAsAsync<Pokemon>();
                return pokemon;
            }

            return null;
        }

        //Start of the generic method//
        //Create a new file in the Models folder//
        public async Task<T> GetAsync<T>(string url)//We have to establish the type prior to using the Search Result Method
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }

            return default; //With generics you must return "default"
        }



    }
}
