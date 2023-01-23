using Planets.WebAPI.Models;
using Planets.Service;
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

        string connectionString = "server = localhost; database = Planets; trusted_connection=true";



        // GET: api/Planet/get-planet-list
        [HttpGet]
        [Route("api/Planet/get-planet-list")]
        public HttpResponseMessage Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(
                    "SELECT * FROM dbo.Planet", connection
                );

                List<PlanetRest> planetList = new List<PlanetRest>();

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        planetList.Add(new PlanetRest(reader.GetGuid(0), reader.GetString(1), reader.GetString(2),
                                                  reader.GetDecimal(3), reader.GetDecimal(4), reader.GetGuid(5)));
                    }
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, planetList);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "No planets found");
            }
        }



        // GET: api/Planet/search-planet-id/{targetID}
        [HttpGet]
        [Route("api/Planet/search-planet-id/{targetID}")]
        public HttpResponseMessage SearchPlanetId(Guid targetID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(
                "SELECT * FROM dbo.Planet WHERE Id = '" + targetID + "'", connection
                );

                List<PlanetRest> planetList = new List<PlanetRest>();

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        planetList.Add(new PlanetRest(reader.GetGuid(0), reader.GetString(1), reader.GetString(2),
                                                  reader.GetDecimal(3), reader.GetDecimal(4), reader.GetGuid(5)));
                    }

                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, planetList);

                }

                return Request.CreateResponse(HttpStatusCode.NotFound, "No planets found");

            }
        }



        // POST: api/Planet/add-planet-to-list
        [HttpPost]
        [Route("api/Planet/add-planet")]
        public HttpResponseMessage AddPlanet([FromBody] PlanetRest inputPlanet)
        {
                if (inputPlanet.Name == null || inputPlanet.Type == null || inputPlanet.Radius == 0 || inputPlanet.Gravity == 0 || inputPlanet.StarSystemID == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Check inputed parameters");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                var id = Guid.NewGuid();

                string commandString = "INSERT INTO dbo.Planet (Id, Name, Type, Radius, Gravity, StarSystemID) VALUES (@Id, @Name, @Type, @Radius, @Gravity, @StarSystemID);";

                SqlCommand command = new SqlCommand(commandString, connection);

                connection.Open();

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", inputPlanet.Name);
                command.Parameters.AddWithValue("@Type", inputPlanet.Type);
                command.Parameters.AddWithValue("@Radius", inputPlanet.Radius);
                command.Parameters.AddWithValue("@Gravity", inputPlanet.Gravity);
                command.Parameters.AddWithValue("@StarSystemID", inputPlanet.StarSystemID);

                command.ExecuteNonQuery();

                connection.Close();

                }

                return Request.CreateResponse(HttpStatusCode.OK, "Successfully added the planet!");
        }



        // PUT: api/Planet/update-planet-by-id/{TargetID}
        [HttpPut]
        [Route("api/Planet/update-planet-by-id/{targetID}")]
        public HttpResponseMessage Update(Guid targetID, [FromBody] PlanetRest updatedPlanet)
        {
            if (updatedPlanet.Id == null || updatedPlanet.Type == null || updatedPlanet.Radius == 0 || updatedPlanet.Gravity == 0 || updatedPlanet.StarSystemID == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Check inputed parameters");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("UPDATE dbo.Planet SET Name = @Name, Type = @Type, Radius = @Radius, Gravity = @Gravity WHERE Id = '" + targetID + "';", connection);

                SqlCommand commandCheck = new SqlCommand("SELECT * FROM dbo.Planet WHERE Id = '" + targetID + "';", connection);

                connection.Open();

                SqlDataReader reader = commandCheck.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();

                    command.Parameters.AddWithValue("@Name", updatedPlanet.Name);
                    command.Parameters.AddWithValue("@Type", updatedPlanet.Type);
                    command.Parameters.AddWithValue("@Radius", updatedPlanet.Radius);
                    command.Parameters.AddWithValue("@Gravity", updatedPlanet.Gravity);
                    command.Parameters.AddWithValue("@StarSystemID", updatedPlanet.StarSystemID);

                    command.ExecuteNonQuery();
                    
                    connection.Close();

                    return Request.CreateResponse(HttpStatusCode.OK, "Update Successful!");
                }
                    connection.Close();
                    
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Planet found with that ID");
            }
        }

        // DELETE: api/Planet/delete-by-id/{targetID}
        [HttpDelete]
        [Route("api/Planet/delete-planet-by-id/{targetID}")]
        public HttpResponseMessage Delete(Guid targetID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM dbo.Planet WHERE Id = '" +targetID+ "' ;", connection);
                
                SqlCommand commandCheck = new SqlCommand("SELECT * FROM dbo.Planet WHERE Id = '" + targetID + "' ;", connection);

                connection.Open();

                SqlDataReader reader = commandCheck.ExecuteReader();
                
                if (reader.HasRows)
                {
                    reader.Close();

                    reader = command.ExecuteReader();
                    
                    reader.Read();
                    
                    reader.Close();
                    
                    connection.Close();

                    return Request.CreateResponse(HttpStatusCode.OK, "Deletion successful!");

                }
                
                connection.Close();
                
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No planet with that ID");
            }
        }
    }
}
