using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PontoId_API.Models
{
    [Table("Escola")]
    public class Escola
    {
        public int EscolaId { get; set; }

        [Required(ErrorMessage = "O nome da escola deve ser informado")]
        [Display(Name = "Nome da Escola")]
        public string NomeEscola { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Bairro")]
        public string BairroEscola { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Cidade")]
        public string CidadeEscola { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Estado")]
        public string EstadoEscola { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "CEP")]
        public int CepEscola { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Complemento")]
        public string ComplementoEscola { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Telefone para Contato")]
        public string TelefoneEscola { get; set; }

        [Display(Name = "Insira o Logo")]
        public string LogoEscola { get; set; }

        public List<Turma> Turmas { get; set; }
    }
}
