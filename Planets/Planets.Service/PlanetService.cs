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

        public List<Planet> GetPlanetList() //turn into async, add await
        {
            return planetRepository.GetPlanetList();
        }

        public Planet SearchPlanetId(Guid targetID) //turn into async, add await
        {
            return planetRepository.SearchPlanetId(targetID);
        }

        public void AddPlanet(Planet inputPlanet) //turn into async, add await
        {
            planetRepository.AddPlanet(inputPlanet);
        }

        public bool UpdatePlanet(Guid targetId, Planet updatedPlanet) //turn into async, add await
        {
            return planetRepository.UpdatePlanet(targetId, updatedPlanet);
        }

        public bool DeletePlanet(Guid targetId) //turn into async, add await
        {
            return planetRepository.DeletePlanet(targetId);
        }

    }
}
