using AutoMapper;
using DaniloTest.Models.Requests;
using DaniloTest.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Test.Domain.DTO;
using Test.Domain.Interface;

namespace DaniloTest.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoService _lancamentoService;

        public LancamentoController(ILancamentoService lancamentoService) => _lancamentoService = lancamentoService;                    

        [HttpPost]
        [Route("SaveLancamento")]        
        [SwaggerResponse(statusCode: 200, type: typeof(LancamentoResponse))]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 500, description: "Internal Server Error")]
        public Task<IActionResult> SaveLancamento([FromBody]LancamentoRequest request) => DoSave(request);

        private async Task<IActionResult> DoSave(LancamentoRequest request)
        {
            var saved = await _lancamentoService.SaveLancamento(Mapper.Map<LancamentoDTO>(request));
                
            return Ok(new LancamentoResponse(saved));
        }
    }
}