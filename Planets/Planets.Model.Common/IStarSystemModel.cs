using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Planets.Model.Common
{
    public interface IStarSystemModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        //List<Planet> PlanetList { get; set; } //List of planets in the Star System
    }
}
