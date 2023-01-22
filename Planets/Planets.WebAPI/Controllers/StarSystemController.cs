using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Planets.WebAPI.Controllers
{
    public class StarSystemController : ApiController
    {

        string connectionString = "server = localhost; database = Planets; trusted_connection=true";

        [HttpGet] //api/Planet/get-starsystems
        [Route("api/Planet/get-starsystems")]
        public HttpResponseMessage Get()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(
                    "SELECT StarSystem.Id, StarSystem.Name FROM dbo.StarSystem,"
                    + " Planet.Id, Planet.Name, Planet.Type, Planet.Radius, Planet.Gravity FROM StarSystem"
                    + " LEFT JOIN Planet ON StarSystem.Id = Planet.StarSystemId;", connection
                    );

                connection.Open();

                List<StarSystem> starSystemList = new List<StarSystem>();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        StarSystem tempSystem = starSystemList.Find(StarSystem => StarSystem.Id == reader.GetGuid(0));

                        if (tempSystem == null)
                        {
                            starSystemList.Add(new StarSystem(reader.GetGuid(0), reader.GetString(1)));
                        }
                    }

                    reader.Close();

                    connection.Close();

                    return Request.CreateResponse(HttpStatusCode.OK, starSystemList);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Star Systems Found");
            }
        }



        [HttpGet] //api/Planet/get-starsystem-id/{targetId}
        [Route("api/Planet/get-starsystem-id/{targetId}")]
        public HttpResponseMessage GetById(Guid targetId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                StarSystem tempStarSystem;
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.StarSystem WHERE Id = " + targetId + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    tempStarSystem = new StarSystem(reader.GetGuid(0), reader.GetString(1));
                    reader.Close();

                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, tempStarSystem);
                }
                connection.Close();
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no Star System with that Id!");
            }
        }



        [HttpGet] //api/Planet/getstarsystem-planets
        [Route("api/Planet/get-starsystem-planets")]
        public HttpResponseMessage GetStarSystemPlanets(Guid targetId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                StarSystem tempStarSystem = new StarSystem();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (tempStarSystem.Id == null)
                        {
                            tempStarSystem = new StarSystem(reader.GetGuid(0), reader.GetString(1));
                        }
                        //add planet to tempStarSystem
                    }
                    reader.Close();
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, tempStarSystem);
                }
                connection.Close();
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Empty");
            }

        }



        [HttpPost] //POST (Add StarSystem) Here
        [Route("api/Planet/add-starsystem")]
        public HttpResponseMessage AddStarSystem() 
        {

        }
        
        
        
        [HttpPut]//UPDATE Here
        [Route("api/Planet/update-starsystem")]
        public HttpResponseMessage UpdateStarSystem()
        {

        }



        [HttpDelete]
        [Route("api/Planet/delete-starsystem/{targetId}")]
        public HttpResponseMessage DeleteStarSystem(Guid targetId)
        {

        }
    }
}
