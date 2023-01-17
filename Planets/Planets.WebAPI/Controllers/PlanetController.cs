using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Planets.WebAPI.Controllers
{
    public class PlanetController : ApiController
    {

        static List<Planet> PlanetsList = new List<Planet>();

        /*public string Get()
        {
            return "Test";
        }*/


        // GET: api/Planet/get-planet-list
        [HttpGet]
        [Route("api/Planet/get-planet-list")]
        public List<Planet> Get()
        {
            if(PlanetsList == null)
            {
                return null; //Nisam siguran kako ovdje dodati da se pojavi poruka da je lista prazna, buduci da je metoda tipa List<Planet>...
            }

            return PlanetsList;
        }

        // GET: api/Planet/search-planet-id/{TargetID}
        [HttpGet]
        [Route("api/Planet/search-planet-id/{TargetID}")]
        public Planet SearchPlanetId(int TargetID)
        {
            if(PlanetsList == null)
            {
                return null;
            }
            
            return PlanetsList.Find(Planet => Planet.BodyID == TargetID);

        }

        // POST: api/Planet/add-planet-to-list
        [HttpPost]
        [Route("api/Planet/add-planet-to-list")]
        public void Post(string Name, string Type, int Radius, int EquadorLength, int BodyID)
        {
            Planet inputPlanet = new Planet();

            inputPlanet.Name = Name;
            inputPlanet.Type = Type;
            inputPlanet.Radius = Radius;
            inputPlanet.EquadorLength = EquadorLength;
            inputPlanet.BodyID = BodyID;

            PlanetsList.Add(inputPlanet);
        }

        //ID has to be unique, add ID-Checker!!!


        // PUT: api/Planet/update-planet-by-id/{TargetID}
        [HttpPut]
        [Route("api/Planet/update-planet-by-id/{TargetID}")]
        public void Put(int TargetID)
        {

        }

        // DELETE: api/Planet/delete-by-id/{TargetID}
        [HttpDelete]
        [Route("api/Planet/delete-by-id/{TargetID}")]
        public string Delete(int TargetID)
        {
            if (PlanetsList != null)
            {
                PlanetsList.Remove(PlanetsList.Where(Planet => Planet.BodyID==TargetID).FirstOrDefault());

                return "Successfully deleted the planet with the inputed ID!" +TargetID;
            }else
            {
                return "List is empty!";
            }
        }
    }
}
