using IntroToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient(); //Had to ctrl . and eventually add using System.Net.Http;
            var response = httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/1").Result; //When we use GetAsync, in this instance we want to see the result of it.

            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                //We need something to "break down" the JSON, we need it to break down all the pieces and put it together as an object (ReadAsSync is originally made)
                //This is where NuGet Package Manager comes in. Solution Explorer, manage NuGet Packages, Microsoft.AspNet.WebApi.Client
                Pokemon pokemonResponse = response.Content.ReadAsAsync<Pokemon>().Result;
                Console.WriteLine(pokemonResponse.name);

                foreach(var ability in pokemonResponse.abilities)
                {
                    Console.WriteLine(ability.ability.name);
                }

            }

            POKEAPIService service = new POKEAPIService();
            Pokemon numberTwo = service.GetPokemonAsync("https://pokeapi.co/api/v2/pokemon/2").Result;
            if(numberTwo != null)
            {
                Console.WriteLine(numberTwo.name);
            }

            //Instead of doing this for every little thing, we're going to build a generic method -> kinda the point of today's lecture.
            //Return to the Service File


            Pokemon anotherPokemon = service.GetAsync<Pokemon>("https://pokeapi.co/api/v2/pokemon/42").Result;
            var test = service.GetAsync<Move>("https://pokeapi.co/api/v2/pokemon/807").Result;
            Console.WriteLine(anotherPokemon.name);
            Console.WriteLine(test.move);


            //We're gonna play around with the API a little bit...
            var listOfPokemon = service.GetAsync<ListOfPokemon>("https://pokeapi.co/api/v2/pokemon").Result;
            foreach(var pokemon in listOfPokemon.results)
            {
                Console.WriteLine(pokemon.name);
            }
            //This should print off the first 20 pokemon(default). If we want anymore we need to alter the url (offset, limit) accordingly.

            Console.ReadKey();
        }
    }
}
