using Microsoft.AspNetCore.Components;
using OnlineExamAppClient.Pages.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamAppClient.Pages
{
    public partial class Register
    {
        public List<string> Countries = new List<string>();
        public List<string> States = new List<string>();
        public List<string> Cities = new List<string>();
        public string RadioValue = "Admin";
      //  public List<string> UserRoles = new List<string>();
        public Register()
        {
            // Populate contries
            Countries.Add("India");
            Countries.Add("USA");
            Countries.Add("England");
            Countries.Add("France");

            // States 
            Cities.Add("Bangalore");
            Cities.Add("Delhi");
            Cities.Add("Bhubaneswar");
            Cities.Add("Puri");

            // States 
            States.Add("Karnataka");
            States.Add("Odisha");
            States.Add("UP");
            States.Add("MP");

            ////roles
            //UserRoles.Add("Admin");
            //UserRoles.Add("Student");
        }

        void CountryUpdated(ChangeEventArgs e)
        {
            //Update the state list
            this.RegisterModel.Country = e.Value.ToString();
        }
       
        void StatesUpdated(ChangeEventArgs e)
        {
            //Update the state list
            if (e.Value.ToString().Equals("Odisha"))
                this.Cities = CitiesList.GetCitiesInOdisha();
            if (e.Value.ToString().Equals("Karnataka"))
                this.Cities = CitiesList.GetCitiesInKarnataka();

            this.RegisterModel.State = e.Value.ToString();

        }

        void CitiesUpdated(ChangeEventArgs e)
        {
            //Update the state list
            this.RegisterModel.City = e.Value.ToString();
        }

        void RadioSelection(ChangeEventArgs args)
        {
            RadioValue = args.Value.ToString();           
            this.RegisterModel.RoleId = (byte)(Roles)Enum.Parse(typeof(Roles), RadioValue); 
        }

    }
}
