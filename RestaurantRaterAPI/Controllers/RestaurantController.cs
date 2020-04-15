using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        //We want to have access/talk to our RestaurantDbContext since that's the link to our database

        private readonly RestaurantDbContext _context = new RestaurantDbContext(); //Now we have an instance of context

        //Now, our first endpoint
        [HttpPost] //We have to say what kind it is. Post is a way for us to create
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if (ModelState.IsValid)//Because of the type of method this is, we can see that if the object being passed in, is valid. It's going to look at the class's properties and compare it to what's coming in. 
            {
                _context.Restaurants.Add(model); //We're looking at the database, then the specific table and then we're adding this model to it. But now we have to tell it to save.
                await _context.SaveChangesAsync(); //Saving the changes/addition.

                return Ok();
            }

            return BadRequest(ModelState);

            //ANY TIME YOU DO ANYTHING TO A DATABASE YOU NEED TO SAVE. THIS GOES FOR ADDING, DELETING, UPDATING, ETC.

        }


        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync(); //Talking to database, making a list and then returning it
            return Ok(restaurants);//Returning both the status code and the object.

        }


    }
}
