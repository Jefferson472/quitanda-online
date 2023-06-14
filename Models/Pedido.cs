using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quitanda_online.Models
{
    public class Pedido
    {
        public enum SituacaoPedido
        {
            Cancelado,
            Realizado,
            Verificado,
            Atendido,
            Entregue,
        }

        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [Display(Name = "Data/Hora")]
        public DateTime DataHoraPedido { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [DisplayName("Situação")]
        public SituacaoPedido Situacao { get; set; }

        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; }

        public Endereco Endereco { get; set; }

        public ICollection<ItemPedido> ItemPedido { get; set; }
    }
}
