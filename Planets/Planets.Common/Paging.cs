using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Common
{
    public class Paging
    {

        public int PageSize;
        public int PageNumber;

        public Paging() //Default constructor
        {
            this.PageSize = 10;
            this.PageNumber = 1;
        }

        public Paging(int PageSize, int PageNumber)
        {
            this.PageSize = PageSize;
            this.PageNumber = PageNumber;
        }
    }


}
