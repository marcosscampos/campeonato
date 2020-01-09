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
    public class TeamsRepository : ITeamsRepository
    {
        private readonly CampeonatoDbContext _context;

        public TeamsRepository(CampeonatoDbContext context)
        {
            _context = context;
        }
        public async Task Add(Team entity)
        {
            await _context.Teams.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await Task
                .FromResult(_context.Teams
                .Include(t => t.Departure)
                .OrderBy(t => t.QuantidadeDeGols));
        }

        public async Task<Team> GetById(long id)
        {
            return await _context.Teams
                .Include(t => t.Nome)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Remove(long id)
        {
            var team = await GetById(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Team entity)
        {
            _context.Teams.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
