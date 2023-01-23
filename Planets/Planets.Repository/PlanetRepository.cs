using Planets.Model;
using Planets.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace Planets.Repository
{
    public class PlanetRepository : IPlanetRepository
    {

        string connectionString = "server = localhost; database = Planets; trusted_connection=true";



        public List<Planet> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(
                    "SELECT * FROM dbo.Planet", connection
                );

                List<Planet> planetList = new List<Planet>();

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        planetList.Add(new Planet(reader.GetGuid(0), reader.GetString(1), reader.GetString(2),
                                                  reader.GetDecimal(3), reader.GetDecimal(4), reader.GetGuid(5)));
                    }
                    connection.Close();
                    return planetList;
                }
                connection.Close();
                return null;
            }
        }



        public Planet SearchPlanetId(Guid targetID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(
                "SELECT * FROM dbo.Planet WHERE Id = '" + targetID + "'", connection
                );

                Planet tempPlanet = new Planet();

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        tempPlanet = new Planet(reader.GetGuid(0), reader.GetString(1), reader.GetString(2),
                                                  reader.GetDecimal(3), reader.GetDecimal(4), reader.GetGuid(5));
                    }

                    connection.Close();
                    return tempPlanet;

                }

                connection.Close();
                
                return null;
            }
        }



        public void AddPlanet(Planet inputPlanet) //use Sql Insert Parameters
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var id = Guid.NewGuid();

                SqlCommand command = new SqlCommand(
                "INSERT PA INTO Planet (Id, Name, Type, Radius, Gravity, StarSystemID) VALUES ( '" + inputPlanet.Name + "', '" + inputPlanet.Type + "', "
                                    + inputPlanet.Radius + ", " + inputPlanet.Gravity + ", '" + inputPlanet.StarSystemID + "');", connection
                );

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                reader.Close();

                connection.Close();
            }
        }



        public bool UpdatePlanet(Guid targetID, Planet updatedPlanet)
        {
            string commandString = "UPDATE Planet SET Name = '" + updatedPlanet.Name + "', Type = '" + updatedPlanet.Type +
                                   "', Radius = " + updatedPlanet.Radius + ", Gravity = " + updatedPlanet.Gravity + ", " +
                                   " WHERE Id = '" + targetID + "';";

            string commandStringCheck = "SELECT * FROM Planet WHERE Id = '" + targetID + "';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(commandString, connection);
                SqlCommand commandCheck = new SqlCommand(commandStringCheck, connection);

                connection.Open();

                SqlDataReader reader = commandCheck.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();

                    reader = command.ExecuteReader();

                    reader.Read();

                    reader.Close();

                    connection.Close();

                    return true;
                }
                connection.Close();

                return false;
            }
        }



        public bool DeletePlanet(Guid targetID)
        {

            string commandString = "DELETE Planet WHERE Id = '" + targetID + "' ;";
            string commandStringCheck = "SELECT * FROM Planet WHERE Id = '" + targetID + "' ;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandString, connection);

                SqlCommand commandCheck = new SqlCommand(commandStringCheck, connection);

                connection.Open();

                SqlDataReader reader = commandCheck.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();

                    reader = command.ExecuteReader();

                    reader.Read();

                    reader.Close();

                    connection.Close();

                    return true;

                }

                connection.Close();

                return false;
            }
        }
    }
}