using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planets.WebAPI
{
    public class Planet //: CelestialBody
    {
        public Planet() 
        {
            //Constructor
        }

        public string Name { get; set; }
        public string Type { get; set; } //Star, Gas, Gas Giant, Rocky
        public int BodyID { get; set; }
        public int Radius { get; set; }
        public int EquadorLength { get; set; }
        
        
        
        //int StarSystemID { get; set; }
        //string StarSystemName { get; set; }
        //int NumberOfSatelites { get; set; }

        //bool HasSatelite = false;
        //bool HasRing = false;

        /*public bool GetHasSatelite()
        {
            return this.HasSatelite;
        }
        public void SetHasSatelite() 
        {
            this.HasSatelite = true;
        }
        public bool GetHasRing()
        {
            return HasRing;
        }
        public void SetHasRing()
        {
            this.HasRing = true;
        }*/

    }
}