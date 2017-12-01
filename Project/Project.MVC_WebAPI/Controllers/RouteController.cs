using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Project.DAL;
using Project.Service.Common;

namespace Project.MVC_WebAPI.Controllers
{
    [RoutePrefix("api/Route")]
    public class RouteController : ApiController
    {
        private IRouteService rService;
        public RouteController(IRouteService rServ)
        {
            rService = rServ;
        }

        [HttpGet]
        [Route("GetRoutes")]
        public async Task<HttpResponseMessage> GetRoutes()
        {
            var response = await rService.GetAllAsync();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("GetSingleRoute")]
        public async Task<HttpResponseMessage> GetSingleRoute(Guid id)
        {
            var response = await rService.GetAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("AddRoute")]
        public async Task<HttpResponseMessage> AddRoute(Route entity)
        {
            entity.id = Guid.NewGuid();
            var response = await rService.AddAsync(entity);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("DeleteRoute")]
        public async Task<HttpResponseMessage> DeleteRoute(Guid id)
        {
            var response = await rService.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPut]
        [Route("UpdateRoute")]
        public async Task<HttpResponseMessage> UpdateRoute(Route entity)
        {
            var response = await rService.UpdateAsync(entity);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
    }
}