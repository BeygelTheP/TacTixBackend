using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TacTix.WebApi.Services;
using TacTix.WebApi.SQLDbContext;

namespace TacTix.WebApi.Controllers
{
    [ApiController]
    public class PlayersController: ControllerBase
    {
        private readonly PlayersService _playersService;

        public PlayersController(PlayersService playersService)
        {
            this._playersService = playersService;
        }


        [HttpGet("players")]
        public async Task<IEnumerable<Player>> GetAllPlayers(){
            return await _playersService.GetAllPlayers();
        }
    }
}