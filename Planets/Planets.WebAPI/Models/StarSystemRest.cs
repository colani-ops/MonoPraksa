using Planets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Planets.WebAPI.Models
{
    public class StarSystemRest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private List<Planet> PlanetList { get { return PlanetList; } } //List of planets in the Star System



        public StarSystemRest() 
        { 
            //Constructor
        }

        public StarSystemRest(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        
    }
}