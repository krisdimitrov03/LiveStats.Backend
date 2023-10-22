using LiveStats.Core.Football.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LiveStats.API.Controllers.Football
{
    public class MatchController : FootballController
    {
        private readonly IFb_MatchService service;

        public MatchController(IFb_MatchService _service)
        {
            service = _service;
        }

        [HttpGet(nameof(All))]
        public async Task<IActionResult> All()
        {
            var data = await service.GetAll();

            return Ok(data);
        }
    }
}
