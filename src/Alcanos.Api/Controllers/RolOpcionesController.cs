using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alcanos.Api.Dtos;
using Alcanos.Domain.Models;
using Alcanos.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alcanos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolOpcionesController : ControllerBase
    {
        private readonly IRolOpcionRepository _repository;
        private readonly IMapper _mapper;

        public RolOpcionesController(IRolOpcionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(List<RolOpcionDto>))]
        public IActionResult GetAll(int rolId)
        {
            try
            {
                var result = _repository.GetByRolId(rolId);
                return Ok(_mapper.Map<List<RolOpcionDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(RolOpcionDto))]
        public IActionResult GetById(int id)
        {
            try
            {
                var dto = _mapper.Map<RolOpcionDto>(_repository.GetById(id));
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(RolOpcionDto))]
        public IActionResult Insert(RolOpcionDto dto)
        {
            try
            {
                var entity = _mapper.Map<RolOpcion>(dto);

                _repository.Insert(entity);
                return Ok(_mapper.Map<RolOpcionDto>(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(void))]
        public IActionResult Update(RolOpcionDto dto)
        {
            try
            {
                var entity = _mapper.Map<RolOpcion>(dto);

                _repository.Update(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        public IActionResult Delete(int rolId , int opcionId)
        {
            try
            {
                _repository.Delete(rolId, opcionId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}