using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
       
        public IEnumerable<Evento> _evento = new Evento[]
        {
                new Evento()
                {
                    EventoId = 1,
                    Tema = "ee",
                    Local = "dsd",
                    Lote = "asdasd",
                    QtdPessoas = 2,
                    DataEvento = DateTime.Now.AddHours(2).ToString("dd/MM/yyyy"),
                    ImagemUrl = "foto.png"
                },
                new Evento()
                {
                    EventoId = 2,
                    Tema = "ee",
                    Local = "dsd",
                    Lote = "asdasd",
                    QtdPessoas = 2,
                    DataEvento = DateTime.Now.AddHours(2).ToString("dd/MM/yyyy"),
                    ImagemUrl = "foto.png"
                }
            };

            public EventoController(){}
        

            [HttpGet("{id}")]
            public IEnumerable<Evento> GetById(int id)
            {
                return _evento.Where(e => e.EventoId == id);           
            }

            [HttpGet]
            public IEnumerable<Evento> Get(int id)
            {
                return _evento;
                
            }
    }
}
