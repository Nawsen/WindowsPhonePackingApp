using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using windowsprojectService.DataObjects;
using windowsprojectService.Models;

namespace windowsprojectService.Controllers
{
    public class TripsssController : TableController<Tripsss>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            windowsprojectContext context = new windowsprojectContext();
            DomainManager = new EntityDomainManager<Tripsss>(context, Request, Services);
        }

        // GET tables/Tripsss
        public IQueryable<Tripsss> GetAllTripsss()
        {
            return Query(); 
        }

        // GET tables/Tripsss/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Tripsss> GetTripsss(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Tripsss/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Tripsss> PatchTripsss(string id, Delta<Tripsss> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Tripsss
        public async Task<IHttpActionResult> PostTripsss(Tripsss item)
        {
            Tripsss current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Tripsss/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTripsss(string id)
        {
             return DeleteAsync(id);
        }

    }
}