using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Common
{
    public class Sorting
    {

        public string OrderBy;
        public string OrderMode;

        public Sorting()
        {
            this.OrderBy = "Name"; //Ordering by name default
            this.OrderMode = "DESC"; //Descending default
        }

        public Sorting(string OrderBy, string OrderMode)
        {
            this.OrderBy = OrderBy;
            this.OrderMode = OrderMode;
        }

    }
}
