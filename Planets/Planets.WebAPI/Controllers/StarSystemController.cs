using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Planets.WebAPI.Controllers
{
    public class StarSystemController : ApiController
    {

        public List<StarSystem> StarSystemList = new List<StarSystem>();

        /*public string Get()
        {
            return "Test";
        }*/


        // GET: api/Planet/get-starsystem-list
        [HttpGet]
        [Route("api/Planet/get-starsystem-list")]
        public List<StarSystem> Get()
        {
            if(StarSystemList == null)
            {
                return null;
            }

            return StarSystemList;
        }

        // GET: api/Planet/search-starsystem-id/{TargetID}
        [HttpGet]
        [Route("api/Planet/search-starsystem-id/{TargetID}")]
        public HttpResponseMessage SearchStarSystemId(int TargetID)
        {
            StarSystem tempStarSystem = StarSystemList.Find(StarSystem => StarSystem.Id == TargetID);

            if(StarSystemList == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, TargetID);
            }

            return Request.CreateResponse(HttpStatusCode.OK, TargetID);

        }

        // POST: api/Planet/add-starsystem-to-list
        [HttpPost]
        [Route("api/Planet/add-starsystem-to-list")]
        public HttpResponseMessage AddStarSystem([FromBody]StarSystem inputStarSystem)
        {
            if (inputStarSystem.Name == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, inputStarSystem.Id);
            }

            inputStarSystem.Id = StarSystemList.Last().Id + 1;
            StarSystemList.Add(inputStarSystem);

            return Request.CreateResponse(HttpStatusCode.OK);           
        }

        // PUT: api/Planet/update-starsystem-by-id/{TargetID}
        [HttpPut]
        [Route("api/Planet/update-starsystem-by-id/{TargetID}")]
        public HttpResponseMessage Update(int TargetID, StarSystem updatedStarSystem)
        {

            StarSystem tempStarSystem = StarSystemList.Find(StarSystem => StarSystem.Id == TargetID);

            if(tempStarSystem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, TargetID);
            
            } else if (updatedStarSystem.Name == null)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, updatedStarSystem.Id);
            }

            StarSystemList.RemoveAt(TargetID);
            StarSystemList.Insert(TargetID, updatedStarSystem);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        // DELETE: api/Planet/delete-starsystem-by-id/{TargetID}
        [HttpDelete]
        [Route("api/Planet/delete-starsystem-by-id/{TargetID}")]
        public HttpResponseMessage Delete(int TargetID)
        {
            StarSystem tempStarSystem = StarSystemList.Find(StarSystem => StarSystem.Id == TargetID);
            
            if (tempStarSystem != null)
            {
                StarSystemList.RemoveAt(TargetID);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, TargetID);
            }
        }
    }
}
