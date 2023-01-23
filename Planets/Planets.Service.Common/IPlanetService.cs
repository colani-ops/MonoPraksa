using Planets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Planets.Service.Common
{
    public interface IPlanetService
    {
        List<Planet> GetPlanetlist();
        Planet SearchPlanetId(Guid targetID);
        void AddPlanet(Planet inputPlanet);
        bool UpdatePlanet(Guid targetId, Planet updatedPlanet);
        bool DeletePlanet(Guid targetId);
    }
}
