using LiveStats.Core.Football.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LiveStats.API.Controllers.Football
{
    public class CompetitionController : FootballController
    {
        private readonly IFb_CompetitionService service;

        public CompetitionController(IFb_CompetitionService _service)
        {
            service = _service;
        }

        [HttpGet(nameof(All))]
        public async Task<IActionResult> All()
        {
            var data = await service.GetAll();

            return Ok(data);
        }

        [HttpGet(nameof(ByNationality))]
        public async Task<IActionResult> ByNationality(int? id = null)
        {
            if(id == null)
            {
                var data = await service.GetGroupedByCountry();

                return Ok(data);
            }
            else
            {
                var data = await service.GetByCountry((int)id);

                return Ok(data);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var data = await service.GetDetails(id);

            return Ok(data);
        }
    }
}
