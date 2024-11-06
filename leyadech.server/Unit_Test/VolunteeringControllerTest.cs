using leyadech.server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    public class VolunteeringControllerTest
    {
        private readonly VolunteeringController _volunteeringController;
        public VolunteeringControllerTest()
        {
            _volunteeringController = new VolunteeringController();
        }
        [Fact]
        public void Get_ReturnsOk()
        {
            var vols=_volunteeringController.Get();
            Assert.IsType<OkObjectResult>(vols);
        }
        [Fact]
        public void GetById_ReturnsOk()
        {
            var id = 1;
            var vol = _volunteeringController.Get(id);
            Assert.IsType<OkObjectResult>(vol);
        }

    }
}
