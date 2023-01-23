using Planets.Model;
using Planets.Service.Common;
using Planets.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Planets.Service
{
    public class PlanetService : IPlanetService
    {
        PlanetRepository planetRepository = new PlanetRepository();

        public List<Planet> GetPlanetlist()
        {
            return planetRepository.GetPlanetList();
        }

        public Planet SearchPlanetId(Guid targetID)
        {
            return planetRepository.SearchPlanetId(targetID);
        }

        public void AddPlanet(Planet inputPlanet)
        {
            planetRepository.AddPlanet(inputPlanet);
        }

        public bool UpdatePlanet(Guid targetId, Planet updatedPlanet)
        {
            return planetRepository.UpdatePlanet(targetId, updatedPlanet);
        }

        public bool DeletePlanet(Guid targetId)
        {
            return planetRepository.DeletePlanet(targetId);
        }

    }
}
