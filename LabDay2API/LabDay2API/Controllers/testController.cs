using LabDay2API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabDay2API.Controllers
{
    public class testController : ApiController
    {
        ITIContext db = new ITIContext();
        public IHttpActionResult get()
        {
            return Ok(db.TbNews.ToList());
        }
    }
}
