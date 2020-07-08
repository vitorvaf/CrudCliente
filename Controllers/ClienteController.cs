using System;
using System.Collections.Generic;
using System.Linq;
using loja.Repository;
using Microsoft.AspNetCore.Mvc;
using loja.Models;

namespace loja.Controllers
{

    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private IClienteRepository _repository;
    
        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
            
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody]Cliente cliente)
        {
            Console.WriteLine("chegou por aqui: " +  DateTime.Now.ToLongTimeString());
            if(!ModelState.IsValid)
            {
                return BadRequest("erro: requisição inválida");
            }

            _repository.Cadastrar(cliente);
            return Created("/cliente/",cliente);
        }


        [HttpGet("listar")]
        public IActionResult Listar()
        {            
            var listaClientes = _repository.Listar();
            return Ok(listaClientes);
            
        }

        [HttpGet("buscaporcpf")]
        public IActionResult BuscarPorCpf(string cpf)
        {
            var cliente = _repository.ListarPorCpf(cpf);

            if(string.IsNullOrEmpty(cliente.Nome))
            {
                return NotFound();
            }
            
            return Ok(cliente);
        }


        [HttpGet("buscasporcnpj")]
        public IActionResult BuscarPorCnpj(string cnpj)
        {
            var cliente = _repository.ListarPorCNPJ(cnpj);

            if(string.IsNullOrEmpty(cliente.Nome))
            {
                return NotFound();
            }
            
            return Ok(cliente);
        }


        [HttpPut]
        public IActionResult Editar([FromBody]Cliente cliente)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _repository.Editar(cliente);            
            return Accepted();
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var cliente = _repository.Query().Where(cliente => cliente.Id == id).FirstOrDefault();

            if(string.IsNullOrEmpty(cliente.Nome))
            {
                return NotFound();
            }

            if(_repository.Deletar(id))
                return Ok();
            else
                throw new Exception(); 
        }
        
    }
}
