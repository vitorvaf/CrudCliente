using System;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using loja.Models;
using loja.Repository;

namespace loja.Controllers
{
    [Route("[controller]")]
    public class TelefoneController : Controller
    {
        private ITelefoneRepository _repository;

        public TelefoneController(ITelefoneRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("selecionar")]
        public IActionResult ListarTelefonesPorCliente(int id)
        {
            var telefones = _repository.ListarTelefonePorCliente(id);

            if (telefones.Count == 0)
                return NotFound();
            else
                return Ok(telefones);

        }
        
        [HttpPost]
        public IActionResult Cadastrar(Telefone telefone)
        {
            if(ModelState.IsValid)
            {
                return BadRequest();
            }

            var telefoneCriado = _repository.Cadastrar(telefone);
            return Ok(telefoneCriado);
            
        }

        [HttpPut]
        public IActionResult Editar(Telefone telefone)
        {
            if(ModelState.IsValid)
                return BadRequest();
            
            _repository.Editar(telefone);
            return Ok();            
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var telefone = _repository.Query()
                .Where(telefone => telefone.Id ==  id)
                .FirstOrDefault();

            if(string.IsNullOrEmpty(telefone.NumeroTelefone))
                return NotFound();

            return Ok(telefone);
            
        }

    }
}