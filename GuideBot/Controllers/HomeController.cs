using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuideBot.DAL.Entities;
using GuideBot.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuideBot.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRepository repository;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("/")]
        public ActionResult Get()
        {
            Guide guide = new Guide
            {
                Descripton = "New guide",
                Title = "My first guide",
                Requisites = "Secret"
            };
            Image img = new Image
            {
                Key = "asdasd"
            };
            //repository.AddExemplar(guide);
            //repository.AddExemplar(img);
            repository.DeleteByFilter<Guide>(g => g.Id > 0);
            return Ok();
        }
    }
}
