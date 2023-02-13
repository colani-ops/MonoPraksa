using Planets.Model;
using Planets.Repository.Common;
using Planets.Common;
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



        public async Task<List<Planet>> GetPlanetListAsync(PlanetFilter planetFilter, Paging paging, Sorting sorting)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string commandString = "SELECT * FROM dbo.Planet";
                
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(commandString);
                
                
                if(planetFilter.PlanetType != null || planetFilter.PlanetGravity != null || planetFilter.PlanetRadius != null)
                {
                    stringBuilder.Append(" WHERE Id != null");

                    if(planetFilter.PlanetType != null)
                    {
                        stringBuilder.Append(" AND Type = " + planetFilter.PlanetType);
                    }
                    if(planetFilter.PlanetGravity != null)
                    {
                        stringBuilder.Append(" AND Gravity BETWEEN 0 AND "+planetFilter.PlanetGravity);
                    }
                    if(planetFilter.PlanetRadius != null)
                    {
                        stringBuilder.Append(" AND Radius BETWEEN 0 AND " + planetFilter.PlanetRadius);
                    }
                }

                int? offset = (paging.PageNumber - 1) * paging.PageSize;
                if(paging.PageNumber != 0 || paging.PageSize != 0)
                { 
                    stringBuilder.Append(" ORDER BY " + sorting.OrderBy + " " + sorting.OrderMode);
                    stringBuilder.Append(" OFFSET " + offset + " ROWS ");
                    stringBuilder.AppendLine(" FETCH NEXT " + paging.PageSize + " ROWS ONLY");
                }

                stringBuilder.Append(";");

                SqlCommand command = new SqlCommand(
                commandString, connection
                );

                commandString = stringBuilder.ToString();

                List<Planet> planetList = new List<Planet>();

                await connection.OpenAsync();

                SqlDataReader readerAsync = await command.ExecuteReaderAsync();

                if (readerAsync.HasRows)
                {

                    while (readerAsync.Read())
                    {

                        planetList.Add(new Planet(readerAsync.GetGuid(0), readerAsync.GetString(1), readerAsync.GetString(2),
                                                  readerAsync.GetDecimal(3), readerAsync.GetDecimal(4), readerAsync.GetGuid(5)));
                    }
                    
                    connection.Close();
                    readerAsync.Close();

                    return planetList;
                
                }
                
                connection.Close();
                readerAsync.Close();

                return null;
            }
        }



        public async Task<Planet> SearchPlanetIdAsync(Guid targetID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(
                "SELECT * FROM dbo.Planet WHERE Id = '" + targetID + "'", connection
                );

                Planet tempPlanet = new Planet();

                await connection.OpenAsync();

                SqlDataReader readerAsync = await command.ExecuteReaderAsync();

                if (readerAsync.HasRows)
                {

                    while (readerAsync.Read())
                    {
                        tempPlanet = new Planet(readerAsync.GetGuid(0), readerAsync.GetString(1), readerAsync.GetString(2),
                                                  readerAsync.GetDecimal(3), readerAsync.GetDecimal(4), readerAsync.GetGuid(5));
                    }

                    connection.Close();

                    return tempPlanet;

                }

                connection.Close();
                
                return null;
            }
        }



        public async Task AddPlanetAsync(Planet inputPlanet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string commandString = "INSERT INTO dbo.Planet (Id, Name, Type, Radius, Gravity, StarSystemID) VALUES (@Id, @Name, @Type, @Radius, @Gravity, @StarSystemID);";

                SqlCommand command = new SqlCommand(commandString, connection);

                await connection.OpenAsync();

                command.Parameters.AddWithValue("@Id", inputPlanet.Id);
                command.Parameters.AddWithValue("@Name", inputPlanet.Name);
                command.Parameters.AddWithValue("@Type", inputPlanet.Type);
                command.Parameters.AddWithValue("@Radius", inputPlanet.Radius);
                command.Parameters.AddWithValue("@Gravity", inputPlanet.Gravity);
                command.Parameters.AddWithValue("@StarSystemID", inputPlanet.StarSystemID);

                await command.ExecuteNonQueryAsync();

                connection.Close();

            }
        }



        public async Task <bool> UpdatePlanetAsync(Guid targetID, Planet updatedPlanet)
        {
            string commandString = "UPDATE dbo.Planet SET Name = @Name, Type = @Type, Radius = @Radius, Gravity = @Gravity WHERE Id = '" + targetID + "';";

            string commandStringCheck = "SELECT * FROM Planet WHERE Id = '" + targetID + "';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(commandString, connection);
                SqlCommand commandCheck = new SqlCommand(commandStringCheck, connection);

                await connection.OpenAsync();

                SqlDataReader readerAsync = await commandCheck.ExecuteReaderAsync();

                if (readerAsync.HasRows)
                {
                    readerAsync.Close();
                    
                    command.Parameters.AddWithValue("@Name", updatedPlanet.Name);
                    command.Parameters.AddWithValue("@Type", updatedPlanet.Type);
                    command.Parameters.AddWithValue("@Radius", updatedPlanet.Radius);
                    command.Parameters.AddWithValue("@Gravity", updatedPlanet.Gravity);
                    command.Parameters.AddWithValue("@StarSystemID", updatedPlanet.StarSystemID);

                    await command.ExecuteNonQueryAsync();

                    readerAsync.Close();

                    connection.Close();

                    return true;
                }

                readerAsync.Close();

                connection.Close();

                return false;
            }
        }



        public async Task <bool> DeletePlanetAsync(Guid targetID)
        {

            string commandString = "DELETE FROM dbo.Planet WHERE Id = '" + targetID + "' ;";
            string commandStringCheck = "SELECT * FROM dbo.Planet WHERE Id = '" + targetID + "' ;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandString, connection);

                SqlCommand commandCheck = new SqlCommand(commandStringCheck, connection);

                await connection.OpenAsync();

                SqlDataReader readerAsync = await commandCheck.ExecuteReaderAsync();

                if (readerAsync.HasRows)
                {
                    readerAsync.Close();

                    readerAsync = await command.ExecuteReaderAsync();

                    readerAsync.Read();

                    readerAsync.Close();

                    connection.Close();

                    return true;

                }

                readerAsync.Close();

                connection.Close();

                return false;
            }
        }
    }
}