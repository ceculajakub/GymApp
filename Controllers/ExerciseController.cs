using GymApp.Models.Api;
using GymApp.Models.Api.Exercise;
using GymApp.Services.ExcerciseService;
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
        public ActionResult Create([FromBody] ExcerciseFormModel model)
        {
            var result = ExerciseService.Create(model);

            if (result == null)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ExcerciseFormModel>> GetList()
        {
            var result = ExerciseService.GetList();

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<ExcerciseFormModel> Fetch(long id)
        {
            var result = ExerciseService.Fetch(id);
            if (result == null)
                return NotFound();

            return result;
        }
    }
}
