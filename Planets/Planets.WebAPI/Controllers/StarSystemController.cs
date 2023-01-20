using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Planets.WebAPI.Controllers
{
    public class StarSystemController : ApiController
    {

        SqlConnection connection = new SqlConnection(
        "server = localhost; database = Planets; trusted_connection=true"
        );

        //GET Method here

        //GET By ID Here

        //GET StarSystem PLANETS Here

        //POST (Add StarSystem) Here

        //UPDATE Here

        //DELETE By ID Here


    }
}
