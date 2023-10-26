using System.Net;
using asp_net_core_rest_api.Data;
using asp_net_core_rest_api.Logging;
using asp_net_core_rest_api.Models;
using asp_net_core_rest_api.Models.Dto;
using asp_net_core_rest_api.Repository.IRepository;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_net_core_rest_api.Controllers
{

    [Route("api/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {   //can be accessed in same class or stuct or derived class
        protected APIResponse _response;
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IMapper _mapper;


        //dependency injection
        public VillaNumberAPIController(IVillaNumberRepository dbVillaNumber, IMapper mapper)
        {
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            this._response = new();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumberList = await _dbVillaNumber.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaNumberList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{villaNo:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int villaNo)
        {
            try
            {
                if (villaNo == 0)
                {
                    return BadRequest();
                }
                var villaNumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == villaNo);
                if (villaNumber == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                        = new List<string>() { ex.ToString()
                    };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO numberCraeteDTO)
        {
            try
            {
                if (await _dbVillaNumber.GetAsync(u => u.VillaNo == numberCraeteDTO.VillaNo) != null)
                {
                    ModelState.AddModelError("CustomeError", "Villa number already exist");
                    return BadRequest(ModelState);
                }
                if (numberCraeteDTO == null)
                {
                    return BadRequest(numberCraeteDTO);
                }

                //map values to original model from dto
                VillaNumber villaNumber = _mapper.Map<VillaNumber>(numberCraeteDTO);

                await _dbVillaNumber.CreateAsync(villaNumber);

                _response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
                _response.StatusCode = HttpStatusCode.Created;
                //show route where can fetch resource
                return CreatedAtRoute("GetVilla", new { id = villaNumber.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                        = new List<string>() { ex.ToString()
                    };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{villaNumber:int}", Name = "DeleteVillaNumber")]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int villaNumber)
        {
            try
            {
                if (villaNumber == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadGateway;
                    return BadRequest(_response);
                }
                var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == villaNumber);

                if (villa == null)
                {
                    return NotFound();
                }
                await _dbVillaNumber.RemoveAsync(villa);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                        = new List<string>() { ex.ToString()
                    };
            }
            return _response;
        }

        [HttpPut("{villaNo:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int villaNo, [FromBody] VillaNumberUpdateDTO numberUpdateDTO)
        {
            try
            {
                if (numberUpdateDTO == null || villaNo != numberUpdateDTO.VillaNo)
                {
                    _response.StatusCode = HttpStatusCode.BadGateway;
                    return BadRequest(_response);
                }

                VillaNumber model = _mapper.Map<VillaNumber>(numberUpdateDTO);
                await _dbVillaNumber.UpdateAsync(model);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                        = new List<string>() { ex.ToString()
                    };
            }
            return _response;
        }
    }
}

