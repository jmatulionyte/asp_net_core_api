using System;
using asp_net_core_rest_api.Data;
using asp_net_core_rest_api.Logging;
using asp_net_core_rest_api.Models;
using asp_net_core_rest_api.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_net_core_rest_api.Controllers
{
    
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        //dependency injection
        public VillaAPIController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        //logger from builder
        //private readonly ILogger<VillaAPIController> _logger;


        //public VillaAPIController(ILogger<VillaAPIController> logger)
        //{
        //    _logger = logger;
        //}


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            //_logger.Log("Getting all villas", "");
            IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();
            //maps from Villa to VillaDTO
            return Ok(_mapper.Map<List<VillaDTO>>(villaList));
        }

        [HttpGet("{id:int}",Name="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        //[ProducesResponseType(200, Type=typeof(VillaDTO))]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if(id == 0)
            {
                //_logger.Log("Id: " + id, "error");
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null)
            {
                //_logger.Log("Id: " + id, "warning");
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDTO>(villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO craeteDTO)
        {
            //optional if [ApiController] is not used
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //tries to fetch recors with posted data, if not found,posted data is unique
            if (await _db.Villas.FirstOrDefaultAsync(u=>u.Name.ToLower() == craeteDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomeError", "Villa already exist");
                return BadRequest(ModelState);
            }
            if (craeteDTO == null)
            {
                return BadRequest(craeteDTO);
            }

            //map values to original model from dto
            Villa model = _mapper.Map<Villa>(craeteDTO);

            await _db.Villas.AddAsync(_mapper.Map<Villa>(craeteDTO));
            await _db.SaveChangesAsync();

            //show route where can fetch resource
            return CreatedAtRoute("GetVilla", new { id = model.Id }, craeteDTO);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody]VillaUpdateDTO updateDTO)
        {
            if(updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }

            Villa model = _mapper.Map<Villa>(updateDTO);
            _db.Villas.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        //https://jsonpatch.com/
        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            //villa.Name = 'sdkvjdxjv';
            //_db.SaveChanges();
            if (villa == null)
            {
                return BadRequest();
            }
            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);

            //takes on dto
            patchDTO.ApplyTo(villaDTO, ModelState);

            //convert again - update takes on model
            Villa model = _mapper.Map<Villa>(villaDTO);

            _db.Villas.Update(model);
            await _db.SaveChangesAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}

