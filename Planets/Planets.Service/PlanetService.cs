using Planets.Model;
using Planets.Service.Common;
using Planets.Repository;
using Planets.Repository.Common;
using Planets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Planets.Service
{
    public class PlanetService : IPlanetService
    {
        protected IPlanetRepository planetRepository { get; private set; }
        public PlanetService (IPlanetRepository planetRepository)
        {
            this.planetRepository = planetRepository;
        }



        public async Task<List<Planet>> GetPlanetListAsync(PlanetFilter planetFilter, Paging paging, Sorting sorting)
        { 
            return await planetRepository.GetPlanetListAsync(planetFilter, paging, sorting);
        }

        public async Task<Planet> SearchPlanetIdAsync(Guid targetID)
        {
            return await planetRepository.SearchPlanetIdAsync(targetID);
        }

        public async Task AddPlanetAsync(Planet inputPlanet)
        {
            await planetRepository.AddPlanetAsync(inputPlanet);
        }

        public async Task <bool> UpdatePlanetAsync(Guid targetId, Planet updatedPlanet)
        {
            return await planetRepository.UpdatePlanetAsync(targetId, updatedPlanet);
        }

        public async Task<bool> DeletePlanetAsync(Guid targetId)
        {
            return await planetRepository.DeletePlanetAsync(targetId);
        }

    }
}
