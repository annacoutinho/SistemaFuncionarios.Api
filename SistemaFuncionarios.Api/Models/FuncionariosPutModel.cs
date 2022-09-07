using System.ComponentModel.DataAnnotations;

namespace SistemaFuncionarios.Api.Models
{
    public class FuncionariosPutModel

    {
      [Required(ErrorMessage = "Por favor, informe o id do funcionario")]
       public Guid IdFunionario { get; set; }
        

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do funcionário")]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor, informe 11 dígitos numéricos.")]
        [Required(ErrorMessage = "Por favor, informe o cpf do funcionário")]
        public string Cpf { get; set; }


        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a matricula do funcionário")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de admissão do funcionário")]
        public DateTime DataAdmissao { get; set; }
    }
}
