using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.DAL;
using Teams.Models;

namespace Teams.Controllers
{
    [Route("teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private ITeamDAO teamDAO;
        public TeamsController(ITeamDAO teamDAO)
        {
            
            this.teamDAO = teamDAO;
        }

        [HttpGet]
        public List<Team> GetAllTeams()
        {
            return teamDAO.GetAllTeams();
        }
    }
}
