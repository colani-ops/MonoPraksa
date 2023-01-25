using Planets.WebAPI.Models;
using Planets.Service;
using Planets.Model;
using Planets.Common;
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
using System.Threading.Tasks;
using Planets.Service.Common;

namespace Planets.WebAPI.Controllers
{
    public class PlanetController : ApiController
    {
        protected IPlanetService planetService { get; private set; }
        public PlanetController(IPlanetService planetService)
        {
            this.planetService = planetService;
        }



        // GET: api/Planet/get-planet-list
        [HttpGet]
        [Route("api/Planet/get-planet-list")]
        public async Task<HttpResponseMessage> GetPlanetListAsync(Guid? planetType, string planetName, decimal? planetRadius, decimal? planetGravity, int pageSize, int pageNumber, string orderBy, string orderMode)
        {
            PlanetFilter planetFilter = new PlanetFilter(planetType, planetName, planetRadius, planetGravity);
            Paging paging = new Paging(pageSize, pageNumber);
            Sorting sorting = new Sorting(orderBy, orderMode);

            List<Planet> planetList = await planetService.GetPlanetListAsync(planetFilter, paging, sorting);

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
        public async Task<HttpResponseMessage> SearchPlanetIdAsync(Guid targetID)
        {

            Planet targetPlanet = await planetService.SearchPlanetIdAsync(targetID);

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
        public async Task<HttpResponseMessage> AddPlanetAsync([FromBody] PlanetRest inputPlanetRest)
        {
            //Could turn this into a seperate method
            if (inputPlanetRest.Name == null || inputPlanetRest.Type == null || inputPlanetRest.Radius == 0 || inputPlanetRest.Gravity == 0 || inputPlanetRest.StarSystemID == null)
            {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Check inputed parameters!");
            }

            var Id = Guid.NewGuid();

            inputPlanetRest.Id=Id;

            Planet inputPlanet = new Planet(inputPlanetRest.Id, inputPlanetRest.Name, inputPlanetRest.Type, inputPlanetRest.Radius, inputPlanetRest.Gravity, inputPlanetRest.StarSystemID);
            
            await planetService.AddPlanetAsync(inputPlanet);

            return Request.CreateResponse(HttpStatusCode.OK, "Successfully added the planet!");
        }



        // PUT: api/Planet/update-planet-by-id/{targetID}
        [HttpPut]
        [Route("api/Planet/update-planet-by-id/{targetID}")]
        public async Task<HttpResponseMessage> UpdateAsync(Guid targetID, [FromBody] PlanetRest updatedPlanetRest)
        {
            //Could turn this into a seperate method
            if (updatedPlanetRest.Id == null || updatedPlanetRest.Type == null || updatedPlanetRest.Radius == 0 || updatedPlanetRest.Gravity == 0 || updatedPlanetRest.StarSystemID == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Check inputed parameters!");
            }

            Planet updatedPlanet = new Planet(updatedPlanetRest.Id, updatedPlanetRest.Name, updatedPlanetRest.Name, updatedPlanetRest.Radius, updatedPlanetRest.Gravity, updatedPlanetRest.StarSystemID);
            
            if (await planetService.UpdatePlanetAsync(targetID, updatedPlanet))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Update Successful!");
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No planet with that ID!");           
        }



        // DELETE: api/Planet/delete-by-id/{targetID}
        [HttpDelete]
        [Route("api/Planet/delete-planet-by-id/{targetID}")]
        public async Task <HttpResponseMessage> DeleteAsync(Guid targetID)
        {

            if (await planetService.DeletePlanetAsync(targetID))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deletion successful!");
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No planet with that ID!");
        }
    }
}
