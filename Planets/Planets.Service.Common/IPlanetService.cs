using Planets.Model;
using Planets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Planets.Service.Common
{
    public interface IPlanetService
    {
        Task<List<Planet>> GetPlanetListAsync(PlanetFilter planetFilter, Paging paging, Sorting sorting); 
        Task<Planet> SearchPlanetIdAsync(Guid targetID);
        Task AddPlanetAsync(Planet inputPlanet);
        Task <bool> UpdatePlanetAsync(Guid targetId, Planet updatedPlanet);
        Task <bool> DeletePlanetAsync(Guid targetId);
    }
}
