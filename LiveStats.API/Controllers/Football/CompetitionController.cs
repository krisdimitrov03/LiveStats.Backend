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

        //[HttpGet(nameof(All))]
        //public async Task<IActionResult> All()
        //{
        //    //var data = await service.GetAll();

        //    //return Ok(data);
        //}
    }
}
