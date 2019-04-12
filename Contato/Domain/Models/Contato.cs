using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contato.Domain.Models
{
    [Table("Contato")]
    public class Contato
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Canal { get; set; }
        [Required]
        public string Valor { get; set; }
        public string Obs { get; set; }
    }
}
