using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace loja.Models
{
    public class Cliente
    {
        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage="Por favor informe o nome do cliente")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string RazaoSocial { get; set; }

        [MaxLength(14,ErrorMessage="Dados do cpf incorretos")]        
        public string CPF { get; set; }

        [MaxLength(18, ErrorMessage="Dados do CNPJ do incorretos")]
        public string CNPJ { get; set; }
        
        [MaxLength(9)]
        public string Cep { get; set; }                
        
        [Required(ErrorMessage="Por favor, informe o email do cliente")]
        public string Email { get; set; }       
        public ICollection<Telefone> Telefones {get; set;} 

        [Required(ErrorMessage="Por favor informe a classificação do cliente")]
        public Classificacao Classificacao { get; set; }

        
        public TipoCliente TipoCliente { get; set; }

    }

    public enum Classificacao 
    {
        Ativo = 1,
        Inativo = 2,
        Preferencial = 3

    }

    public enum TipoCliente
    {
        Fisica = 1,
        Juridica = 2
        
    }

}