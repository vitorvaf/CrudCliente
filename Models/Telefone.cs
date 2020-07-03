using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loja.Models
{
    public class Telefone
    {
        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage="Por favor insira o telefone do cliente")]
        [MaxLength(20, ErrorMessage="Dados do telefone do cliente incorretos")]        
        public string NumeroTelefone { get; set; }

        [Required(ErrorMessage="")]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

    }
}