using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TacTix.WebApi.SQLDbContext;

namespace TacTix.WebApi.Services
{
    public class PlayersService
    {
        private readonly TacTixDbContext _context;
        public PlayersService(TacTixDbContext context)
        {
            this._context = context;

        }
        internal async Task<IEnumerable<Player>> GetAllPlayers()
        {
            var res = _context.Players.Include(x => x.PlayerPosition).AsNoTracking().ToList();
            return await Task.FromResult(res);
        }
    }
}