using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campeonato.Domain.Entities;
using Campeonato.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.API.Controllers
{

    [Route("api/departure")]
    [ApiController]
    public class DepartureController : ControllerBase
    {
        private readonly IDeparturesRepository _departuresRepository;

        public DepartureController(IDeparturesRepository departuresRepository)
        {
            _departuresRepository = departuresRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var departures = await _departuresRepository.GetAll();
            return Ok(departures);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody]Departure departure)
        { 
                await _departuresRepository.Add(departure);
                return Ok();

        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Details(long id)
        {
            var departure = await _departuresRepository.GetById(id);

            if (departure != null)
            {
                return Ok(departure);
            }

            return NotFound();
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Edit(long id, [FromBody]Departure departure)
        {
            var editDepartures = await _departuresRepository.GetById(id);

            if (editDepartures != null)
            {
                editDepartures.Partida = departure.Partida;

                await _departuresRepository.Update(editDepartures);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Remove(long id)
        {
            await _departuresRepository.Remove(id);

            return Ok();
        }
    }
}
