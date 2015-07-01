using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Innoventory.Api.Controllers
{
    [RoutePrefix("../api/v1/")]
    public class HomeController : ApiController
    {

        public IHttpActionResult Get()
        {
            return Ok("Success");
        }
    }
}
