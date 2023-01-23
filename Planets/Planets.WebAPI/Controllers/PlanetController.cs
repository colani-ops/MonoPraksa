using Planets.WebAPI.Models;
using Planets.Service;
using Planets.Model;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;



namespace Planets.WebAPI.Controllers
{
    public class PlanetController : ApiController
    {

        //string connectionString = "server = localhost; database = Planets; trusted_connection=true";

        PlanetService planetService = new PlanetService();


        // GET: api/Planet/get-planet-list
        [HttpGet]
        [Route("api/Planet/get-planet-list")]
        public HttpResponseMessage GetPlanetList()
        {
            List<Planet> planetList = planetService.GetPlanetList();

            List<PlanetRest> planetRestList = new List<PlanetRest>();

            foreach(Planet planet in planetList)
            {
                planetRestList.Add(new PlanetRest(planet));
            }
            if (planetRestList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No planets loaded");
            }

            return Request.CreateResponse(HttpStatusCode.OK, planetRestList);
        }



        // GET: api/Planet/search-planet-id/{targetID}
        [HttpGet]
        [Route("api/Planet/search-planet-id/{targetID}")]
        public HttpResponseMessage SearchPlanetId(Guid targetID)
        {

            Planet targetPlanet = planetService.SearchPlanetId(targetID);

            PlanetRest targetPlanetRest = new PlanetRest(targetPlanet);

            if(targetPlanetRest == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Planet with that ID");
            }
            return Request.CreateResponse(HttpStatusCode.OK, targetPlanetRest);
        }



        // POST: api/Planet/add-planet
        [HttpPost]
        [Route("api/Planet/add-planet")]
        public HttpResponseMessage AddPlanet([FromBody] PlanetRest inputPlanetRest)
        {
            //Could turn this into a seperate method
            if (inputPlanetRest.Name == null || inputPlanetRest.Type == null || inputPlanetRest.Radius == 0 || inputPlanetRest.Gravity == 0 || inputPlanetRest.StarSystemID == null)
            {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Check inputed parameters!");
            }

            var Id = Guid.NewGuid();

            inputPlanetRest.Id=Id;

            Planet inputPlanet = new Planet(inputPlanetRest.Id, inputPlanetRest.Name, inputPlanetRest.Type, inputPlanetRest.Radius, inputPlanetRest.Gravity, inputPlanetRest.StarSystemID);
            
            planetService.AddPlanet(inputPlanet);

            return Request.CreateResponse(HttpStatusCode.OK, "Successfully added the planet!");
        }



        // PUT: api/Planet/update-planet-by-id/{targetID}
        [HttpPut]
        [Route("api/Planet/update-planet-by-id/{targetID}")]
        public HttpResponseMessage Update(Guid targetID, [FromBody] PlanetRest updatedPlanetRest)
        {
            //Could turn this into a seperate method
            if (updatedPlanetRest.Id == null || updatedPlanetRest.Type == null || updatedPlanetRest.Radius == 0 || updatedPlanetRest.Gravity == 0 || updatedPlanetRest.StarSystemID == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Check inputed parameters!");
            }

            Planet updatedPlanet = new Planet(updatedPlanetRest.Id, updatedPlanetRest.Name, updatedPlanetRest.Name, updatedPlanetRest.Radius, updatedPlanetRest.Gravity, updatedPlanetRest.StarSystemID);
            
            if (planetService.UpdatePlanet(targetID, updatedPlanet))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Update Successful!");
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No planet with that ID!");           
        }



        // DELETE: api/Planet/delete-by-id/{targetID}
        [HttpDelete]
        [Route("api/Planet/delete-planet-by-id/{targetID}")]
        public HttpResponseMessage Delete(Guid targetID)
        {

            if (planetService.DeletePlanet(targetID))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deletion successful!");
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No planet with that ID!");
        }
    }
}
