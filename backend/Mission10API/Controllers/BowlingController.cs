using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission10API.Data;

namespace Mission10API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private IBowlingLeagueRepository _bowlingLeagueRepository;

        public BowlingController(IBowlingLeagueRepository temp) 
        {
            _bowlingLeagueRepository = temp;
        }

        public IEnumerable<object> Get()
        {

            var joinedData = from bowler in _bowlingLeagueRepository.Bowlers
                             join team in _bowlingLeagueRepository.Teams
                             on bowler.TeamID equals team.TeamID
                             where team.TeamName == "Marlins" || team.TeamName == "Sharks"
                             select new
                             {
                                 BowlerFirstName = bowler.BowlerFirstName,
                                 BowlerLastName = bowler.BowlerLastName,
                                 BowlerMiddleInit = bowler.BowlerMiddleInit,
                                 BowlerAddress = bowler.BowlerAddress,
                                 BowlerCity = bowler.BowlerCity,
                                 BowlerState = bowler.BowlerState,
                                 BowlerZip = bowler.BowlerZip,
                                 BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                                 TeamName = team.TeamName
                             };

            var joinedList = joinedData
                .ToArray();

            return joinedList;
        }
    }
}
