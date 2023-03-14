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
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }


        // POST api/<PlayerController>
        [HttpPost]
        public async Task<Identifier> Post([FromBody] CreatePlayer player)
        {
            var result = await playerService.Create(player);
            var identifier = result.Match(
                Left: ex => throw ex,
                Right: r => r
            );
            return identifier;
        }
    }
}