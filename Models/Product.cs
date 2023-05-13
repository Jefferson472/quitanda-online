using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quitanda_online.Models
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(1000)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Column(TypeName = "decimanl(18, 2)")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Estoque")]
        public int Inventory { get; set; }

    }
}
