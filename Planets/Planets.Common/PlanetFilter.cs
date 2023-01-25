using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Common
{
    public class PlanetFilter
    {
        public Guid? PlanetType { get; set; } //Rocky, Gas Giant, Ice Giant, 3 Guids

        public string PlanetName { get; set; }
        public decimal? PlanetRadius { get; set; }
        public decimal? PlanetGravity { get; set; }



        public PlanetFilter()
        {
            //Empty Constructor
        }

        public PlanetFilter(Guid PlanetType, string PlanetName, decimal PlanetRadius, decimal PlanetGravity)
        {
            this.PlanetType = PlanetType;
            this.PlanetName = PlanetName;
            this.PlanetRadius = PlanetRadius;
            this.PlanetGravity = PlanetGravity;
        }

    }
}
