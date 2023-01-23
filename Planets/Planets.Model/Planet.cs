using Planets.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Model
{
    public class Planet : IPlanetModel
    {
        private Guid id;
        private string name;
        private string type;
        private decimal radius;
        private decimal gravity;

        private Guid starSystemID;

        public Guid Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Type { get { return type; } set { type = value; } } //Gas Giant, Rocky
        public decimal Radius { get { return radius; }  set { radius = value; } }
        public decimal Gravity { get { return gravity; } set { gravity = value; } }
        public Guid StarSystemID { get { return starSystemID; } set {starSystemID= value; } }

        public Planet()
        {

        }

        public Planet(Guid id, string name, string type, decimal radius, decimal gravity, Guid starSystemID)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.radius = radius;
            this.gravity = gravity;
            this.starSystemID = starSystemID;
        }
    }
}