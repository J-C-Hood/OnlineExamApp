using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamAppClient.Pages.Address
{
    public class CitiesList
    {
        // Cites in Odisha
        public static List<string> GetCitiesInOdisha()
        {
            List<string> cities = new List<string>();
            cities.Add("Bhubaneswar");
            cities.Add("Cuttack");
            return cities;
        }

        public static List<string> GetCitiesInKarnataka()
        {
            List<string> cities = new List<string>();
            cities.Add("Bangalore");
            cities.Add("Mangalore");
            return cities;
        }
    }
}
