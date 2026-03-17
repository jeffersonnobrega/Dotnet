using Microsoft.AspNetCore.Mvc;
using Atendimento.Domain.Interfaces;
using Atendimento.Domain.DTOs;
using Atendimento.Domain.Enums;
using Atendimento.Domain.Services;

namespace Atendimento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpPost("CriarDepartamento")]
        public async Task<IActionResult> AdicionarDepartamento(DepartamentoCreateDto departamentoCreateDto)
        {   
            var resposta = await _departamentoService.CriarDepartamentoAsync(departamentoCreateDto);
            
            if (!resposta.Status) return BadRequest(resposta);
            return CreatedAtAction(nameof(BuscarPorId), new { id = resposta.Dados!.Id }, resposta);
        }
            
        [HttpGet("BuscarPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var resposta = await _departamentoService.ListarDepartamentoPorIdAsync(id);
            
            if (!resposta.Status) return NotFound(resposta);
            
            return Ok(resposta);
        }

         [HttpGet("BuscarTodosDepartamentos")]
        public async Task<IActionResult> BuscarTodosDepartamentos()
        {
            var resposta = await _departamentoService.ListarDepartamentosAsync();

            return resposta.Status ? Ok(resposta) : BadRequest(resposta);
        }       


      
    }
}