using System.Threading.Tasks;
using Campeonato.Client.Models;
using Campeonato.Domain.Entities;
using Campeonato.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Campeonato.Client.Controllers
{
    [Route("team")]
    public class TeamsController : Controller
    {
        private readonly ApiService _api;

        public TeamsController(ApiService api)
        {
            _api = api;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var teams = await _api.GetAll<Team>("team");

            return View(teams);
        }

        [HttpGet("new")]
        public async Task<IActionResult> Create()
        {
            var teams = await _api.GetAll<Departure>("departure");

            var vm = new CreateTeamViewModel
            {
                DepartureList = new SelectList(teams, "Id", "Partida")
            };
            return View(vm);
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create(CreateTeamViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var team = new Team
            {
                Nome = vm.Nome,
                QuantidadeDeGols = vm.QuantidadeDeGols,
                DepartureId = vm.DepartureId
            };

            await _api.Insert<Team>("team", team);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Details(long id)
        {
            var team = await _api.GetById<Team>($"team/{id}");

            return View(team);
        }

        //[HttpGet("{id:long}/edit")]
        //public async Task<IActionResult> Edit(long id)
        //{
        //    var team = await _api.GetById<Team>($"team/{id}");

        //    return View(team);
        //}

        //[HttpPost("{id:long}/edit")]
        //public async Task<IActionResult> Edit(long id, CreateTeamViewModel vm)
        //{
        //    if (!ModelState.IsValid) return View(vm);

        //    await _api.Update<Team>($"team/{id}", vm);

        //    return RedirectToAction(nameof(Details), new { id });
        //}

        [HttpGet("{id:long}/delete")]
        public async Task<IActionResult> Remove(long id)
        {
            await _api.Remove<Team>($"team/{id}");

            return RedirectToAction(nameof(Index));
        }
    }
}