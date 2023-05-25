using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quitanda_online.Models
{
    public class ItemPedido
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public float Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }

        [ForeignKey("IdProduto")]
        public Product Produto { get; set; }

    }
}
