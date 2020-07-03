using System;
using System.Collections.Generic;
using loja.Models;
using loja.Data;
using System.Linq;

namespace loja.Repository
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private LojaDataContext _context;

        public TelefoneRepository(LojaDataContext context)
        {
            _context = context;

        }
        public int Cadastrar(Telefone telefone)
        {
            _context.Add(telefone);
            _context.SaveChanges();
            return telefone.Id;

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

        public Telefone Editar(Telefone telefone)
        {
            _context.Update(telefone);
            _context.Entry(telefone);
            _context.SaveChanges();

            return telefone;
                        
        }

        public ICollection<Telefone> ListarTelefonePorCliente(int idCliente)
        {
            return _context.Telefones
                .Where(telefones => telefones.ClienteId == idCliente)
                .ToList();           
            
        }
    }
}