using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

    

    public class DevisesController : ControllerBase
    {

        private List<Devise> lesDevises = new List<Devise>();
       
        public DevisesController() 
        {
            lesDevises.Add(new Devise(1, "Dollar", 1.08));
            lesDevises.Add(new Devise(2, "Franc Suisse", 1.07));
            lesDevises.Add(new Devise(3, "Yen", 120));
        }

        // GET: api/<DevisesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return lesDevises;
        }

         /// <summary>
         /// Get a single currency
         /// </summary>
         /// <returns>Http response</returns>
         /// <param name="id">The id of the currency</param>
         /// <returns code="200"> When teh currency id is found</returns>
         /// <returns code="404">When the currency id is not found</returns>

        // GET api/<DevisesController>/5
        [HttpGet("{id}", Name ="GetDevise")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Devise> GetById([FromRoute]int id)
        {
            Devise? devise = lesDevises.FirstOrDefault((d) => d.Id == id);

            if (devise == null)
            {
                return NotFound();
            }

            return devise;
        }

        /// <summary>
        /// Post a Devise
        /// </summary>
        /// <param name="devise">the new devise created</param>
        /// <returns> new route with id currency created</returns>
        /// <returns>if Model is not valid return bad request</returns>

        // POST api/<DevisesController>
        [HttpPost]
        public ActionResult<Devise> Post([FromBody] Devise devise)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            lesDevises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        /// <summary>
        /// Put a devise
        /// </summary>
        /// <param name="id"> find id to modify id currency</param>
        /// <param name="devise"> add new devise </param>
        /// <returns></returns>

        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = lesDevises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            lesDevises[index] = devise;
            return NoContent();
        }

        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Devise> Delete([FromRoute] int id)
        {
            Devise? devise = lesDevises.FirstOrDefault(d => d.Id == id);

            if (devise == null)
            {
                return NotFound();
            }
            lesDevises.Remove(devise);
            return NoContent();
        }
    }
}
