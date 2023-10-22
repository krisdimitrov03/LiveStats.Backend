using LiveStats.Core.Shared.Contracts;
using LiveStats.Core.Shared.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveStats.API.Controllers.Shared
{
    public class NationalityController : BaseController
    {
        private readonly ISh_NationalityService service;

        public NationalityController(ISh_NationalityService _service)
        {
            service = _service;
        }

        [HttpGet(nameof(All))]
        public async Task<IActionResult> All()
        {
            var data = await service.GetAll();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Single(int id)
        {
            var data = await service.GetById(id);

            if(data == null)
                return NotFound(data);

            return Ok(data);
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] Sh_NationalityCreateModel data)
        {
            var (result, error) = await service.Create(data);

            if (result)
                return Ok(new { Success = result });

            return BadRequest(new { Error = error });
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update(int id, [FromBody] Sh_NationalityUpdateModel data)
        {
            var (result, error) = await service.Update(id, data);

            if (result)
                return Ok(new { Success = result });

            return BadRequest(new { Error = error });
        }

        [HttpDelete(nameof(Delete) + "/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);

            if (result)
                return Ok(new { Success = result });

            return BadRequest(new { Success = result });
        }
    }
}
