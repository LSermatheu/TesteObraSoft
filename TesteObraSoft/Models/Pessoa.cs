using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace TesteObraSoft.Models
{
    public class Pessoa
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo {0} obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        [Column("Endereco")]
        public string Endereco { get; set; }

        [Display(Name = "Tel. Fixo")]
        [Column("TelefoneFixo")]
        [MaxLength(11)]
        public string TelefoneFixo { get; set; }

        [Display(Name = "Tel. Celular")]
        [Column("TelefoneCelular")]
        [MaxLength(11)]
        public string TelefoneCelular { get; set; }

        [Column("Email")]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo {0} obrigatório.")]
        public string Email { get; set; }

        [Column("Sexo")]
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Campo {0} obrigatório.")]
        public string Sexo { get; set; }

        [Column("EstadoCivil")]
        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "Campo {0} obrigatório.")]
        public string EstadoCivil { get; set; }

        [Column("Salario")]
        [Display(Name = "Salário")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal Salario { get; set; }
    }
}
