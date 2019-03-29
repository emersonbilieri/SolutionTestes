using Apolice.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Apolice.Api.Models;

namespace Apolice.Api.Controllers
{
    public class ApoliceController : ApiController
    {
        private IApoliceService apoliceService;

        
        public ApoliceController(IApoliceService apoliceService)
        {
            this.apoliceService = apoliceService;
        }

        // GET api/apolice
        public IEnumerable<Model.Models.Apolice> Get()
        {
            return apoliceService.GetApolices();
        }

        // GET api/apolice/5
        public Model.Models.Apolice Get(int id)
        {
            Model.Models.Apolice apoliceEntity = null;
            if (id != 0)
            {
                apoliceEntity = apoliceService.GetApolice(id);
            }

            return apoliceEntity;
        }

        // POST api/apolice
        public HttpResponseMessage Post(Model.Models.Apolice apolice)
        {
            apoliceService.Insert(apolice);

            var response = Request.CreateResponse(HttpStatusCode.Created, apolice);

            return response;
        }

        // PUT api/apolice/5
        public HttpResponseMessage Put(Model.Models.Apolice apolice)
        {
            Model.Models.Apolice apoliceDB = apoliceService.GetApolice(apolice.ID);

            if (apolice != null)
            {
                apoliceService.Update(apolice);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, apolice);

                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, apolice);
            }
        }

        // DELETE api/apolice/5
        public HttpResponseMessage Delete(int id)
        {
            Model.Models.Apolice apolice = apoliceService.GetApolice(id);

            if (apolice != null)
            {
                apoliceService.Delete(apolice);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, apolice);

                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, apolice);
            }
        }

    }
}
