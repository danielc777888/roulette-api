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
    public class BetController : ControllerBase
    {
        private readonly IBetService betService;

        public BetController(IBetService betService)
        {
            this.betService = betService;
        }


        // POST api/<BetController>
        [HttpPost]
        public async Task<Identifier> Post([FromBody] CreateBet bet)
        {
            var result = await betService.Create(bet);
            var identifier = result.Match(
                Left: ex => throw ex,
                Right: r => r
            );
            return identifier;
        }
    }
}