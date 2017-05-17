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
using FeatureTrackerService.Models;

namespace FeatureTrackerService.Controllers
{
    public class FeaturesController : ApiController
    {
        private FeatureTrackerServiceContext db = new FeatureTrackerServiceContext();

        // GET: api/Features
        public IQueryable<FeatureDTO> GetFeatures()
        {
            var feats = from f in db.Features
                        select new FeatureDTO()
                        {
                            Id = f.Id,
                            FeatName = f.FeatName,
                            isComplete = f.isComplete
                        };

            return feats;
        }

        // GET: api/Features/5
        [ResponseType(typeof(FeatureDTO))]
        public async Task<IHttpActionResult> GetFeature(int id)
        {
            var feature = await db.Features.Include(f => f.Author).Select(f =>
                new FeatureDetailDTO()
                {
                    Id = f.Id,
                    FeatName = f.FeatName,
                    isComplete = f.isComplete,
                    Description = f.Description,
                    AuthorName = f.Author.Name,
                    Priority = f.Priority
                }).SingleOrDefaultAsync(f => f.Id == id);


            if (feature == null)
            {
                return NotFound();
            }

            return Ok(feature);
        }

        // PUT: api/Features/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFeature(int id, Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feature.Id)
            {
                return BadRequest();
            }

            db.Entry(feature).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Features
        [ResponseType(typeof(Feature))]
        public async Task<IHttpActionResult> PostFeature(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Features.Add(feature);
            await db.SaveChangesAsync();

            // new code
            // load author name
            db.Entry(feature).Reference(x => x.Author).Load();

            var dto = new FeatureDTO()
            {
                Id = feature.Id,
                FeatName = feature.FeatName,
                isComplete = feature.isComplete
            };


            return CreatedAtRoute("DefaultApi", new { id = feature.Id }, dto);
        }

        // DELETE: api/Features/5
        [ResponseType(typeof(Feature))]
        public async Task<IHttpActionResult> DeleteFeature(int id)
        {
            Feature feature = await db.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            db.Features.Remove(feature);
            await db.SaveChangesAsync();

            return Ok(feature);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeatureExists(int id)
        {
            return db.Features.Count(e => e.Id == id) > 0;
        }
    }
}