using System;
using System.Collections.Generic;
using System.EnterpriseServices;
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
        public HttpResponseMessage SearchPlanetId(int TargetID)
        {
            Planet tempPlanet = PlanetsList.Find(Planet => Planet.BodyID == TargetID);

            if(PlanetsList == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, TargetID);
            }

            return Request.CreateResponse(HttpStatusCode.OK, TargetID);

        }

        // POST: api/Planet/add-planet-to-list
        [HttpPost]
        [Route("api/Planet/add-planet-to-list")]
        public HttpResponseMessage AddPlanet([FromBody]Planet inputPlanet)
        {
            if (inputPlanet.Name == null || inputPlanet.Type == null || inputPlanet.Radius == 0 || inputPlanet.EquadorLength == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, inputPlanet.BodyID);
            }

            inputPlanet.BodyID = PlanetsList.Last().BodyID + 1;
            PlanetsList.Add(inputPlanet);

            return Request.CreateResponse(HttpStatusCode.OK);           
        }

        // PUT: api/Planet/update-planet-by-id/{TargetID}
        [HttpPut]
        [Route("api/Planet/update-planet-by-id/{TargetID}")]
        public HttpResponseMessage Update(int TargetID, Planet updatedPlanet)
        {

            Planet tempPlanet = PlanetsList.Find(Planet => Planet.BodyID == TargetID);

            if(tempPlanet == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, TargetID);
            
            } else if (updatedPlanet.Name == null || updatedPlanet.Type == null || updatedPlanet.Radius == 0 || updatedPlanet.EquadorLength == 0)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, updatedPlanet.BodyID);
            }

            PlanetsList.RemoveAt(TargetID);
            PlanetsList.Insert(TargetID, updatedPlanet);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        // DELETE: api/Planet/delete-by-id/{TargetID}
        [HttpDelete]
        [Route("api/Planet/delete-by-id/{TargetID}")]
        public HttpResponseMessage Delete(int TargetID)
        {
            Planet tempPlanet = PlanetsList.Find(Planet => Planet.BodyID == TargetID);

            if (PlanetsList != null)
            {
                PlanetsList.RemoveAt(TargetID);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, TargetID);
            }
        }
    }
}
