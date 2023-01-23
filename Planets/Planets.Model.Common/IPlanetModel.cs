using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Planets.Model.Common
{
    public interface IPlanetModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Type { get; set; } //Gas Giant, Rocky
        decimal Radius { get; set; }
        decimal Gravity { get; set; }
        Guid StarSystemID { get; set; }

    }
}
