using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RestWoodPellets.model;
using WoodPelletsLib.model;
using WoodPelletsLib.repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWoodPellets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WoodPelletsController : ControllerBase
    {
        private readonly   WoodPelletRepository _repo;

        public WoodPelletsController(WoodPelletRepository repo)
        {
            _repo = repo;
        }




        // GET: api/<WoodPelletsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            List<WoodPellet> pellets = _repo.GetAll();
            if (pellets.Count == 0)
            {
                return NoContent();
            }

            return Ok(pellets);
        }

        // GET api/<WoodPelletsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                WoodPellet pellet = _repo.GetById(id);
                return Ok(pellet);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound();
            }
        }

        // POST api/<WoodPelletsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] WoodPelletDTO dto)
        {
            try
            {
                WoodPellet newPellet = WoodPelletConverter.DTO2WoodPellet(dto);

                newPellet = _repo.Add(newPellet);
                return Created($"api/WoodPellets/{newPellet.Id}", newPellet);
            }
            catch(ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        // PUT api/<WoodPelletsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] WoodPelletDTO dto)
        {
            try
            {
                WoodPellet updatePellet = WoodPelletConverter.DTO2WoodPellet(dto);

                try
                {
                    WoodPellet pellet = _repo.Update(id, updatePellet);
                    return Ok(pellet);
                }
                catch(KeyNotFoundException knfe)
                {
                    return NotFound();
                }
            }
            catch(ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        //// DELETE api/<WoodPelletsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
