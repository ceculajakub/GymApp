using GymApp.Models.Api.UserMeasurements;
using GymApp.Services.UserMeasurementsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace GymApp.Controllers
{
    [ApiController]
    [Route("api/userMeasurement")]

    public class UserMeasurementsController : ControllerBase
    {
        private IUserMeasurementsService UserMeasurementsService { get; set; }

        public UserMeasurementsController(IUserMeasurementsService userMeasurementsService)
        {
            this.UserMeasurementsService = userMeasurementsService;
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] UserMeasurementsFormModel model)
        {
            var result = UserMeasurementsService.Create(model);

            if (result == null)
                return BadRequest();

            return Accepted();
        }

        [HttpGet("{uid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<UserMeasurementsViewModel>> Fetch(long uid)
        {
            var entity = UserMeasurementsService.Fetch(uid);

            if (entity == null)
                return NotFound();
            
            return entity;
        }

        [HttpPost("{id}/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Update(long id, [FromBody] UserMeasurementsFormModel model)
        {
            var result = UserMeasurementsService.Update(model, id);

            if (result == null)
                return BadRequest();

            return Ok();

        }


    }

}
