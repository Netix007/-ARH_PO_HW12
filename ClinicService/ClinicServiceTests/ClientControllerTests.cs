using ClinicService.Controllers;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServiceTests
{
    public class ClientControllerTests
    {
        private ClientController _clientController;
        private Mock<IClientRepository> _mocClientRepository;

        public ClientControllerTests()
        {
            _mocClientRepository = new Mock<IClientRepository>();
            _clientController = new ClientController(_mocClientRepository.Object);
        }

        [Fact]
        public void GetAllClientsTest()
        {
            //[1] Подготовка данных для тестирования
            _mocClientRepository.Setup(repository =>
            repository.GetAll()).Returns(new List<Client>()
            {
                new Client(),
                new Client(),
                new Client()
            });

            ActionResult<List<Client>> operationResult = _clientController.GetAll();
            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.IsAssignableFrom<List<Client>>(((OkObjectResult)operationResult.Result).Value);


            _mocClientRepository.Verify(repository => repository.GetAll(), Times.Once);

        }

    }
}
