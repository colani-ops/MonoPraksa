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

        //GET Method here
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

        //GET By ID Here

        //GET StarSystem PLANETS Here

        //POST (Add StarSystem) Here

        //UPDATE Here

        //DELETE By ID Here
    }
}
