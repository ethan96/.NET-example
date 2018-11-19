using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PlayersController : ApiController
    {
        Player[] players = new Player[]
        {
            new Player(){ ID = 1, Name = "Brian" },
            new Player(){ ID = 2, Name = "Barry" },
            new Player(){ ID = 3, Name = "Michael" }
        };

        public IEnumerable<Player> GetAllPlayer()
        {
            return players;
        }

        public IHttpActionResult GetPlayer(int id)
        {
            var player = players.Where(p => p.ID == id).FirstOrDefault();
            if (player != null)
                return Ok(player);
            else
                return NotFound();
        }
    }
}
