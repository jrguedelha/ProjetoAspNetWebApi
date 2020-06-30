using ProjetoAspNetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoAspNetWebApi.Controller
{
    [RoutePrefix("api/pj")]
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

        [HttpGet]
        [Route("consulta/cliente/{id:int}")]
        public HttpResponseMessage GetClientePorId(int id)
        {
            try
            {
                var clientes = new[]
                {
                    new { Id = 1, Nome = "Pedro", DataNascimento = new DateTime(1954, 2, 1) },
                    new { Id = 2, Nome = "Paulo", DataNascimento = new DateTime(1944, 4, 12) },
                    new { Id = 3, Nome = "Fernando", DataNascimento = new DateTime(1963, 5, 9) },
                    new { Id = 4, Nome = "Maria", DataNascimento = new DateTime(1984, 4, 30) },
                    new { Id = 5, Nome = "Joao", DataNascimento = new DateTime(1900, 3, 14) },
                    new { Id = 6, Nome = "Joana", DataNascimento = new DateTime(1974, 6, 19) }
                };

                var cliente = clientes.Where(x => x.Id == id).FirstOrDefault();

                if (cliente == null) throw new Exception("Cliente nao encontrado");

                return Request.CreateResponse(HttpStatusCode.OK, cliente);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage PostCadastro(Cliente cliente)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro do ususario " + cliente.Nome + " realizado,");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
