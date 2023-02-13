using Planets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Planets.WebAPI.Models
{
    public class PlanetRest
    {
        private Guid id;
        private string name;
        private string type;
        private decimal radius;
        private decimal gravity;

        private Guid starSystemID;
        //private string starName;

        public Guid Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Type { get { return type; } set { type = value; } } //Gas Giant, Rocky
        public decimal Radius { get { return radius; }  set { radius = value; } }
        public decimal Gravity { get { return gravity; } set { gravity = value; } }
        public Guid StarSystemID { get { return starSystemID; } set {starSystemID= value; } }
        //public string StarName { get { return starName; } set { starName = value; } }

        public PlanetRest(Planet inputPlanet) 
        {
            this.id = inputPlanet.Id;
            this.name = inputPlanet.Name;
            this.type = inputPlanet.Type;
            this.radius = inputPlanet.Radius;
            this.gravity = inputPlanet.Gravity;
            this.StarSystemID = inputPlanet.StarSystemID;
            //this.starName = inputPlanet.StarName;
        }

        public PlanetRest()
        {

        }

    }
}