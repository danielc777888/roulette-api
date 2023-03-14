using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RouletteService.Services;
using RouletteService.Services.Data;
using RData = RouletteService.Repositories.Data;

namespace RouteService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }


        // GET: api/<GameController>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await gameService.Get(id);
            if (result.IsNone)
            {
                return NotFound();
            }
            return Ok(result.Head<RData.Game>());
        }


        // POST api/<GameController>
        [HttpPost]
        public async Task<Identifier> Post([FromBody] CreateGame game)
        {
            var result = await gameService.Create(game);
            var identifier = result.Match(
                Left: ex => throw ex,
                Right: r => r
            );
            return identifier;
        }
    }
}