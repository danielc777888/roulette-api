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
    public class SpinController : ControllerBase
    {
        private readonly ISpinService spinService;

        public SpinController(ISpinService spinService)
        {
            this.spinService = spinService;
        }


        // POST api/<SpinController>
        [HttpPost]
        public async Task<Identifier> Post([FromBody] CreateSpin spin)
        {
            var result = await spinService.Create(spin);
            var identifier = result.Match(
                Left: ex => throw ex,
                Right: r => r
            );
            return identifier;
        }
    }
}