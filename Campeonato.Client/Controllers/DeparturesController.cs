using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campeonato.Client.Models;
using Campeonato.Domain.Entities;
using Campeonato.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Client.Controllers
{
    [Route("departure")]
    public class DeparturesController : Controller
    {
        private readonly ApiService _api;

        public DeparturesController(ApiService api)
        {
            _api = api;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var departures = await _api.GetAll<Departure>("departure");

            return View(departures);
        }

        [HttpGet("new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create(CreateDepartureViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var departure = new Departure
            {
                Partida = vm.Partida
            };

            await _api.Insert<Departure>("departure", departure);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Details(long id)
        {
            var departures = await _api.GetById<Departure>($"departure/{id}");

            return View(departures);
        }

        [HttpGet("{id:long}/edit")]
        public async Task<IActionResult> Edit(long id)
        {
            var departures = await _api.GetById<Departure>($"departure/{id}");

            return View(departures);
        }

        [HttpPost("{id:long}/edit")]
        public async Task<IActionResult> Edit(long id, CreateDepartureViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            await _api.Update<Departure>($"departure/{id}", vm);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet("{id:long}/delete")]
        public async Task<IActionResult> Remove(long id)
        {
            await _api.Remove<Departure>($"departure/{id}");

            return RedirectToAction(nameof(Index));
        }
    }
}