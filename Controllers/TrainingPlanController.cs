using GymApp.Models.Api.TrainingPlan;
using GymApp.Services;
using GymApp.Services.TrainingPlanService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    [ApiController]
    [Route("api/training-plan")]
    public class TrainingPlanController : ControllerBase
    {
        private ITrainingPlanService TrainingPlanService { get; set; }

        public TrainingPlanController(ITrainingPlanService training)
        {
            TrainingPlanService = training;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Create([FromBody] TrainingPlanFormModel model)
        {
            var result = TrainingPlanService.Create(model);

            if (result == null)
                return BadRequest();

            return Ok();
        }
    }
}
