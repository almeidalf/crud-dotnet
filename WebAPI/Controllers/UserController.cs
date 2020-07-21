using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public UserController(
            )
        {

        }

        [HttpGet]
        public IEnumerable<User> CarregarListaDeUsuarios()
        {
            using (CorretorDBEntities entities = new CorretorDBEntities())
            {
                return entities.Users.ToList();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage UsuarioPorID(int id)
        {
            using (CorretorDBEntities entities = new CorretorDBEntities())
            {
                var entity = entities.Users.FirstOrDefault(x => x.userId == id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Usuário ID: " + id.ToString() + "não foi localizado");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage AdicionarUsuario([FromBody] User user)
        {
            try
            {
                using (CorretorDBEntities entities = new CorretorDBEntities())
                {
                    entities.Users.Add(user);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, user);

                    message.Headers.Location = new Uri(Request.RequestUri + user.userId.ToString());
                    Log.Logger.Information("Novo Usuário Cadastrado: {Nome:l} {UserEmail:l}",
                     user.userName, user.userEmail) ;
                    return message;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Warning(ex,"TESTE SERILOG USER EX");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeletarUsuario(int id)
        {
            try
            {
                using (CorretorDBEntities entities = new CorretorDBEntities())
                {
                    var entity = entities.Users.FirstOrDefault(x => x.userId == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Usuário ID: " + id.ToString() + "não existe");
                    }
                    else
                    {
                        entities.Users.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
        
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage EditarUsuario(int id, User user)
        {
            try
            {
                using (CorretorDBEntities entities = new CorretorDBEntities())
                {
                    var entity = entities.Users.FirstOrDefault(x => x.userId == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Usuário com ID: " + id.ToString() + "não existe!");
                    }
                    else
                    {

                        entity.userName = user.userName;
                        entity.userAddress = user.userAddress;
                        entity.userPhone = user.userPhone;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
