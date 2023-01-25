using Planets.Model;
using Planets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Planets.Repository.Common
{
    public interface IPlanetRepository
    {
        Task<List<Planet>> GetPlanetListAsync(PlanetFilter planetFilter, Paging paging, Sorting sorting);
        Task<Planet> SearchPlanetIdAsync(Guid targetId);
        Task AddPlanetAsync(Planet inputPlanet);
        Task<bool> UpdatePlanetAsync(Guid targetID, Planet updatedPlanet);
        Task<bool> DeletePlanetAsync(Guid targetID);

    }
}
