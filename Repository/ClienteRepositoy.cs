using System;
using System.Collections.Generic;
using System.Linq;
using loja.Models;
using loja.Data;

namespace loja.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private LojaDataContext _context;

        public ClienteRepository(LojaDataContext context)
        {
            _context = context;
        }
        public int Cadastrar(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
            return cliente.Id;

        }

        public bool Deletar(int id)
        {
            try
            {
                _context.Remove(id);
                _context.SaveChanges();
                return true;

            }
            catch (System.Exception)
            {
                return false;

            }

        }

        public Cliente Editar(Cliente cliente)
        {
            _context.Update(cliente);
            _context.Entry(cliente);
            _context.SaveChanges();

            return cliente;                
        }

        public ICollection<Cliente> Listar()
        {
            return _context.Clientes.ToList();
        }

        public Cliente ListarPorCNPJ(string cnpj)
        {
            return _context.Clientes
                .Where(clientes=> clientes.CNPJ == cnpj)
                .FirstOrDefault();
        }

        public Cliente ListarPorCpf(string cpf)
        {
            return _context.Clientes
                .Where(clientes=> clientes.CPF == cpf)
                .FirstOrDefault();
        }

        public IQueryable<Cliente> Query()
        {
            return _context.Clientes.AsQueryable();
        }
    }


}