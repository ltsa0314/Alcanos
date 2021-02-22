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
    public class RolesController : ControllerBase
    {
        private readonly IRolRepository _repository;
        private readonly IRolOpcionRepository _rolOpcionRepository;
        private readonly IMapper _mapper;

        public RolesController(IRolRepository repository, IRolOpcionRepository rolOpcionRepository, IMapper mapper)
        {
            _repository = repository;
            _rolOpcionRepository = rolOpcionRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(List<RolDto>))]
        public IActionResult GetAll()
        {
            try
            {
                var result = _repository.GetAll();
                return Ok(_mapper.Map<List<RolDto>>(result));
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
        [Produces("application/json", Type = typeof(RolDto))]
        public IActionResult GetById(int id)
        {
            try
            {
                var dto = _mapper.Map<RolDto>(_repository.GetById(id));
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
        [Produces("application/json", Type = typeof(RolDto))]
        public IActionResult Insert(RolDto dto)
        {
            try
            {
                var entity = _mapper.Map<Rol>(dto);

                _repository.Insert(entity);
                return Ok(_mapper.Map<RolDto>(entity));
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
        public IActionResult Update(RolDto dto)
        {
            try
            {
                var entity = _mapper.Map<Rol>(dto);

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
                if (_rolOpcionRepository.ExistsOpciones(id))
                {
                    throw new Exception("Existen Opciones Asociadas");
                }
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