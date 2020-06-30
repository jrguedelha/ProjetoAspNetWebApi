using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoAspNetWebApi.Controller
{
    [RoutePrefix("api/meuprojeto")]
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("datahora/get")]
        public HttpResponseMessage GetDataHoraServer()
        {
            try
            {
                var dataHora = DateTime.Now.ToString("dd/MM/yy HH:mm");

                return Request.CreateResponse(HttpStatusCode.OK, dataHora);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
