using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI.Models
{
    //Continuing to create the generic method, with T (meaning generic TYPE)
    public class SearchResult<T>
    {
        public int Count { get; set; }
        public List<T> Results { get; set; } = new List<T>(); //T means that the list can hold any result
    }
}
