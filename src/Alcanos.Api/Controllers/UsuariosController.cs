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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRolRepository _usuarioRolRepository;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository repository, IUsuarioRolRepository usuarioRolRepository, IMapper mapper)
        {
            _repository = repository;
            _usuarioRolRepository = usuarioRolRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(List<UsuarioDto>))]
        public IActionResult GetAll()
        {
            try
            {
                var result = _repository.GetAll();
                return Ok(_mapper.Map<List<UsuarioDto>>(result));
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
        [Produces("application/json", Type = typeof(UsuarioDto))]
        public IActionResult GetById(int id)
        {
            try
            {
                var dto = _mapper.Map<UsuarioDto>(_repository.GetById(id));
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
        [Produces("application/json", Type = typeof(UsuarioDto))]
        public IActionResult Insert(UsuarioDto dto)
        {
            try
            {
                var entity = _mapper.Map<Usuario>(dto);

               _repository.Insert(entity);
                return Ok(_mapper.Map<UsuarioDto>(entity));
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
        public IActionResult Update(UsuarioDto dto)
        {
            try
            {
                var entity = _mapper.Map<Usuario>(dto);

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
                if (_usuarioRolRepository.ExistsRoles(id)) {
                    throw new Exception("Existen Roles Asociados");
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