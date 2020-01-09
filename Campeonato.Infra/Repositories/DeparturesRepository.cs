using Campeonato.Data.Contexts;
using Campeonato.Domain.Entities;
using Campeonato.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonato.Infra.Repositories
{
    public class DeparturesRepository : IDeparturesRepository
    {
        private readonly CampeonatoDbContext _context;

        public DeparturesRepository(CampeonatoDbContext context)
        {
            _context = context;
        }

        public async Task Add(Departure entity)
        {
            await _context.Departures.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Departure>> GetAll()
        {
            return await Task
                .FromResult(_context.Departures
                .Include(a => a.Teams)
                .OrderBy(a => a.Partida));
        }

        public async Task<Departure> GetById(long id)
        {
            return await _context.Departures
                .Include(a => a.Teams)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task Remove(long id)
        {
            var departure = await GetById(id);
            _context.Departures.Remove(departure);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Departure entity)
        {
            _context.Departures.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
