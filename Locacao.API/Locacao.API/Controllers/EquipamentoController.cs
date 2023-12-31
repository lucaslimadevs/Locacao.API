﻿using Locacao.Commands.Equipamentos.Command;
using Locacao.Queries.Equipamentos.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Locacao.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EquipamentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EquipamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InserirEquipamento([FromBody] InserirEquipamentoCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipamentos = await _mediator.Send(new BuscarEquipamentoQuery());

            return Ok(equipamentos);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarEquipamento([FromBody] AtualizarEquipamentoCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeletarEquipamento([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeletarEquipamentoCommand { Id = id });

            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
