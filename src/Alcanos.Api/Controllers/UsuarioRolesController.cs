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
    public class UsuarioRolesController : ControllerBase

    {
        private readonly IUsuarioRolRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioRolesController(IUsuarioRolRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(List<UsuarioRolDto>))]
        public IActionResult GetAll(int usuarioId)
        {
            try
            {
                var result = _repository.GetByUserId(usuarioId);
                return Ok(_mapper.Map<List<UsuarioRolDto>>(result));
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
        [Produces("application/json", Type = typeof(UsuarioRolDto))]
        public IActionResult GetById(int id)
        {
            try
            {
                var dto = _mapper.Map<UsuarioRolDto>(_repository.GetById(id));
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
        [Produces("application/json", Type = typeof(UsuarioRolDto))]
        public IActionResult Insert(UsuarioRolDto dto)
        {
            try
            {
                var entity = _mapper.Map<UsuarioRol>(dto);

                _repository.Insert(entity);
                return Ok(_mapper.Map<UsuarioRolDto>(entity));
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
        public IActionResult Update(UsuarioRolDto dto)
        {
            try
            {
                var entity = _mapper.Map<UsuarioRol>(dto);

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
        public IActionResult Delete(int usuarioId , int rolId)
        {
            try
            {
                _repository.Delete(usuarioId, rolId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}