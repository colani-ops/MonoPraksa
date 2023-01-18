using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planets.WebAPI
{
    public class Planet
    {
        public Planet() 
        {
            //Constructor
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } //Gas Giant, Rocky
        public int Radius { get; set; }
        StarSystem StarSystem { get; set; } //To which StarSystem does the planet belong to
        bool HasSatelite { get; set; }
        bool HasRing { get; set; }
        public double Gravity { get; set; }
    }
}