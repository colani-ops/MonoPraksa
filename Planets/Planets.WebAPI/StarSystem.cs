using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planets.WebAPI
{
    public class StarSystem
    {
        public StarSystem() 
        { 
            //Constructor
        }

        public int Id { get; set; }
        public string Name { get; set; }
        List<Planet> PlanetList { get; set; } //List of planets in the Star System
    }
}