using System;
using System.Collections.Generic;
using loja.Models;

namespace loja.Repository
{
    public interface ITelefoneRepository
    {
        int Cadastrar(Telefone telefone);

        ICollection<Telefone> ListarTelefonePorCliente(int idCliente);

        Telefone Editar(Telefone telefone);

        bool Deletar(int id);        
        
    }
}