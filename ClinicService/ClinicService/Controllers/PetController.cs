using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicService.Controllers
{
    /// <summary>
    /// ДОМАШНЯЯ РАБОТА: Доработать контроллеры PetController и ConsultationController по образу и подобию контроллера ClientController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "PetCreate")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createPetRequest)
        {
            if (createPetRequest.Birthday < DateTime.Now.AddYears(-25) || createPetRequest.Name.Length < 3)
            {
                return BadRequest(0); // BadRequestObjectResult : 400
            }
            return Ok(1); // OkObjectResult : 200
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "PetUpdate")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updatePetRequest)
        {
            return Ok(1);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "PetDelete")]
        public ActionResult<int> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(0);
            }
            return Ok(1);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "PetGetAll")]
        public ActionResult<List<Pet>> GetAll(int clientId)
        {
            return Ok(new List<Pet>());
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "GetById")]
        public ActionResult<Client> GetById(int id)
        {
            return Ok(new Pet());
        }
    }
}
