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
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamsRepository _teamRepository;
        private readonly IDeparturesRepository _departuresRepository;

        public TeamController(ITeamsRepository teamsRepository, IDeparturesRepository departuresRepository)
        {
            _teamRepository = teamsRepository;
            _departuresRepository = departuresRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var teams = await _teamRepository.GetAll();
            return Ok(teams);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(Team teams)
        {
            var departure = await _departuresRepository.GetById(teams.DepartureId);

            if(departure != null){
                await _teamRepository.Add(teams);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Details(long id)
        {
            var teams = await _teamRepository.GetById(id);

            if(teams != null)
            {
                return Ok(teams);
            }

            return NotFound();
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Edit(long id, [FromBody]Team team)
        {
            var editTeam = await _teamRepository.GetById(id);

            if(editTeam != null)
            {
                editTeam.Nome = team.Nome;
                editTeam.QuantidadeDeGols = team.QuantidadeDeGols;
                editTeam.DepartureId = team.DepartureId;

                await _teamRepository.Update(editTeam);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Remove(long id)
        {
            await _teamRepository.Remove(id);

            return Ok();
        }
    }
}
