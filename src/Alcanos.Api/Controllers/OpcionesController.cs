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
    public class OpcionesController : ControllerBase

    {
        private readonly IOpcionRepository _repository;
        private readonly IMapper _mapper;

        public OpcionesController(IOpcionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(List<OpcionDto>))]
        public IActionResult GetAll()
        {
            try
            {
                var result = _repository.GetAll();
                return Ok(_mapper.Map<List<OpcionDto>>(result));
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
        [Produces("application/json", Type = typeof(OpcionDto))]
        public IActionResult GetById(int id)
        {
            try
            {
                var dto = _mapper.Map<OpcionDto>(_repository.GetById(id));
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
        [Produces("application/json", Type = typeof(OpcionDto))]
        public IActionResult Insert(OpcionDto dto)
        {
            try
            {
                var entity = _mapper.Map<Opcion>(dto);

                _repository.Insert(entity);
                return Ok(_mapper.Map<OpcionDto>(entity));
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
        public IActionResult Update(OpcionDto dto)
        {
            try
            {
                var entity = _mapper.Map<Opcion>(dto);

                _repository.Update(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
