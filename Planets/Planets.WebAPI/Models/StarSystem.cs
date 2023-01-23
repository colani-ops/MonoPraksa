using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planets.WebAPI
{
    public class StarSystem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private List<Planet> PlanetList { get { return PlanetList; } } //List of planets in the Star System



        public StarSystem() 
        { 
            //Constructor
        }

        public StarSystem(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        
    }
}