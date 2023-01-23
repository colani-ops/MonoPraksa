using Planets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Planets.Repository.Common
{
    public interface IPlanetRepository
    {
        List<Planet> GetPlanetList();
        Planet SearchPlanetId(Guid targetId);
        void AddPlanet(Planet inputPlanet);
        bool UpdatePlanet(Guid targetID, Planet updatedPlanet);
        bool DeletePlanet(Guid targetID);

    }
}
