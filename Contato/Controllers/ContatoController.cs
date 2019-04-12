using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contato.Domain;

namespace Contato.Controllers
{
    [Produces("application/json")]
    [Route("api/Contato")]
    public class ContatoController : Controller
    {
        private readonly ContatoDbContext _db;

        public ContatoController(ContatoDbContext contatoDbContext)
        {
            _db = contatoDbContext;
        }

        [HttpGet]
        public object Get()
        {
            var contatos = _db.Contatos.ToList();

            if (contatos.Count == 0)
                return NoContent();

            return Ok(contatos);
        }

        [HttpGet("{id}", Name = "Get")]
        public object Get(int id)
        {
            var contato = _db.Contatos.Where(x => x.Id == id).FirstOrDefault();

            if (contato == null)
                return NoContent();

            return Ok(contato);
        }

        [HttpPut("{id}", Name = "Put")]
        public object Put(int id, [FromBody]Domain.Models.Contato contato)
        {
            var _contato = _db.Contatos.Where(x => x.Id == id).FirstOrDefault();

            if (contato == null)
                return NoContent();
            
            _contato.Canal = contato.Canal;
            _contato.Nome = contato.Nome;
            _contato.Obs = contato.Obs;
            _contato.Valor = contato.Valor;

            _db.Contatos.Update(contato);
            _db.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}", Name = "Put")]
        public object Delete(int id)
        {
            var _contato = _db.Contatos.Where(x => x.Id == id).FirstOrDefault();

            if (_contato == null)
                return NoContent();

            _db.Contatos.Remove(_contato);
            _db.SaveChanges();

            return Ok();
        }


        [HttpPost]
        public object Post([FromBody]Domain.Models.Contato contato)
        {
            if (!ModelState.IsValid)
                return BadRequest("Campos necessários null");
            
            _db.Contatos.Add(contato);
            _db.SaveChanges();

            return Ok();

        }
    }
}