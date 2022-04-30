using GymApp.Models.Api;
using GymApp.Models.Api.Exercise;
using GymApp.Services.ExerciseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GymApp.Controllers
{
    [ApiController]
    [Route("api/exercise")]
    public class ExerciseController : Controller
    {
        private IExerciseService ExerciseService { get; set; }

        public ExerciseController(IExerciseService exerciseService)
        {
            ExerciseService = exerciseService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Create([FromBody] ExerciseFormModel model)
        {
            var result = ExerciseService.Create(model);

            if (result == null)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ExerciseFormModel>> GetList()
        {
            var result = ExerciseService.GetList();

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<ExerciseFormModel> Fetch(long id)
        {
            var result = ExerciseService.Fetch(id);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            ExerciseService.Delete(id);

            return Ok();
        }
    }
}
