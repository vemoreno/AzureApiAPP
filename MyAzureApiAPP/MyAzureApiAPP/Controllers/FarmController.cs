using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using MyAzureApiAPP.Models;

namespace MyAzureApiAPP.Controllers
{
    public class FarmController : ApiController
    {
        private bool LoadedOnce { get; set; }
        private Farm ObjectFarm { get; set; }
        private FarmController()
        {
            this.ObjectFarm = new Farm();
        }

        // GET api/values
        [SwaggerOperation("GetAll")]
        public List<Animal> Get()
        {
            return ObjectFarm.GetAllTheFarm();
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public Animal Get(int id)
        {
            return this.ObjectFarm.GetAnimalByID(id);
        }

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]string value)
        {
            if (value != null && value != "")
            {
                Animal A = new Animal()
                {
                    Fed = false,
                    Type = value,
                    ID = this.ObjectFarm.TheFarm.Select(An => An.ID).Max() + 1,
                };

                this.ObjectFarm.IncludeAnimal(A);
            }
          
        }

        // PUT api/values/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Put(int id, [FromBody]string value)
        {
            if (value != null && value != "")
                this.ObjectFarm.FeedAnimal(id);
         
        }

        // DELETE api/values/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Delete(int id)
        {
            this.ObjectFarm.TakeOutAnimal(id);
        }
    }
}
