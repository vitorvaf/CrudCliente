using System;
using System.Collections.Generic;
using loja.Models;

namespace loja.Repository
{
    public interface IClienteRepository
    {
        int Cadastrar(Cliente cliente);

        ICollection<Cliente> Listar();

        Cliente ListarPorCpf(string cpf);

        Cliente ListarPorCNPJ(string cnpj);

        Cliente Editar (Cliente cliente);

        bool Deletar(int id);        
        
    }
}