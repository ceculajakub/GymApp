using GymApp.Models.Api.Exercise;
using GymApp.Services.ExerciseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GymApp.Controllers
{
    // API do zarządzania listą ćwiczeń. Zgodne z zasadą SOLID (głównie Single Responsibility Principle).
    // Jego zadaniem jest jedynie obsługa zapytań dotyczących kontekstu ćwiczeń.
    [ApiController]
    [Route("api/exercise")]
    public class ExerciseController : Controller
    {
        // Dependency Injection - pozwala na uniezależnienie od konkretnej implementacji elementu wykonywującego zamierzone operacje na ćwiczeniach
        private IExerciseService ExerciseService { get; set; }

        // Wstrzykiwanie przez konstruktor
        public ExerciseController(IExerciseService exerciseService)
        {
            ExerciseService = exerciseService;
        }

        // Tworzenie nowego ćwiczenia - przykład użycia zasady Encapsulation,
        // metoda nie udostępnia szczegółów implementacji, ma ona za zasadę przekazanie żądania do odpowiedniego elementu systemu. Kontroler jest odpowiedzialny tylko za obsługę ruchu,
        // bez wiedzy na temat szczegółowej implementacji.
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
        public ActionResult<ExerciseFormModel> Fetch(int id)
        {
            var result = ExerciseService.Fetch(id);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            ExerciseService.Delete(id);

            return Ok();
        }
    }
}
