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
    public class ClientController : ControllerBase
    {
        private IClientRepository _clientRepository;


        public ClientController(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        }


        [HttpPost("create")]
        [SwaggerOperation(OperationId = "ClientCreate")]
        public ActionResult<int> Create([FromBody]  CreateClientRequest createClientRequest)
        {
            Client client = new Client();
            client.SurName = createClientRequest.SurName;
            client.FirstName = createClientRequest.FirstName;
            client.Patronymic = createClientRequest.Patronymic;
            client.Document = createClientRequest.Document; 
            client.Birthday = createClientRequest.Birthday;
            return Ok(_clientRepository.Create(client));
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "ClientUpdate")]
        public ActionResult<int> Update([FromBody]  UpdateClientRequest updateClientRequest)
        {
            Client client = new Client();
            client.ClientId = updateClientRequest.ClientId;
            client.SurName = updateClientRequest.SurName;
            client.FirstName = updateClientRequest.FirstName;
            client.Patronymic = updateClientRequest.Patronymic;
            client.Document = updateClientRequest.Document;
            client.Birthday = updateClientRequest.Birthday;
            return Ok(_clientRepository.Update(client));
        }


        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "ClientDelete")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_clientRepository.Delete(id));
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "ClientGetAll")]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_clientRepository.GetAll());

            //return Ok(new List<Client>()
            //{
            //    new Client(),
            //    new Client()
            //});
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "ClientGetById")]
        public ActionResult<Client> GetById(int id)
        {
            return Ok(_clientRepository.GetById(id));
        }

    }
}
