using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<User> Get()
        {
            using (CorretorDBEntities entities = new CorretorDBEntities())
            {
                return entities.Users.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
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

        public HttpResponseMessage Post([FromBody] User user)
        {
            try
            {
                using (CorretorDBEntities entities = new CorretorDBEntities())
                {
                    entities.Users.Add(user);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, user);

                    message.Headers.Location = new Uri(Request.RequestUri + user.userId.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
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

        public HttpResponseMessage Put(int id, User user)
        {
            try
            {
                using (CorretorDBEntities entities = new CorretorDBEntities())
                {
                    var entity = entities.Users.FirstOrDefault(x => x.userId == id);
                       
                    if(entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Usuário com ID: " + id.ToString() + "não existe!");
                    } else
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
