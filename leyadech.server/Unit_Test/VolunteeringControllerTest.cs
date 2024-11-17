using leyadech.server.Controllers;
using leyadech.server.DTO;
using leyadech.server.Service;
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
            _volunteeringController = new VolunteeringController(new VolunteeringService(new FakeContext()));
        }
        [Fact]
        public void Get_ReturnsOk()
        {
            var vols = _volunteeringController.Get();
            Assert.IsType<ActionResult<List<Volunteering>>>(vols);
        }
        [Fact]
        public void GetById_ReturnsOk()
        {
            var id = 1;
            var vol = _volunteeringController.Get(id);
            Assert.IsType<ActionResult<Volunteering>>(vol);
        }
        [Fact]
        public void Add_ReturnsBadRequest_NotValidDate()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var tommorow = today.AddDays(1);
            var vol = new Volunteering() { DateStart = tommorow, DateEnd = today };
            var res = _volunteeringController.Add(vol);
            Assert.IsType<BadRequestResult>(res);
        }
        [Fact]
        public void Add_ReturnsBadRequest_NotValidTime()
        {
            var h1 = TimeOnly.FromDateTime(DateTime.Now);
            var h2 = h1.AddHours(1);
            var vol = new Volunteering() { TimeEnd = h1, TimeStart = h2 };
            var res = _volunteeringController.Add(vol);
            Assert.False(res.Value);
        }
    }
}
