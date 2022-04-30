using GymApp.Models.Api.Training;
using GymApp.Services.TrainingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymApp.Controllers
{
    [ApiController]
    [Route("api/training")]
    public class TrainingController : Controller
    {
        private ITrainingService trainingService { get; set; }

        public TrainingController(ITrainingService training)
        {
            trainingService = training;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] TrainingFormModel model)
        {
            var result = trainingService.Create(model);

            if (result == null)
                return BadRequest();

            return Accepted();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TrainingViewModel> Fetch(int id)
        {
            var entity = trainingService.Fetch(id);

            if (entity == null)
                return NotFound();

            return entity;
        }

        [HttpPost("{id}/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Update(int id, [FromBody] TrainingFormModel model)
        {
            var result = trainingService.Update(model, id);


            if (result == null)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            trainingService.Delete(id);

            return Ok();
        }

    
    }
}