using quitanda_online.Pages.Shared.DisplayTemplates;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace quitanda_online.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo {0} deve conter uma data válida.")]
        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [MaxLength(11, ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [RegularExpression(@"[0-9]{11}$", ErrorMessage = "O campo {0} deve ser preenchido com 11 dígitos numéricos.")]
        [UIHint("_CustomCPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} deve conter um endereço de email válido.")]
        public string Email { get; set; }

    }
}
