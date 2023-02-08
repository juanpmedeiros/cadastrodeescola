using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PontoId_API.Models
{
    [Table("Turma")]
    public class Turma
    {
        public int TurmaId { get; set; }

        [Required(ErrorMessage = "A turma deve ser informada")]
        [Display(Name = "Insira a Turma do aluno")]
        public int TurmaNumero { get; set; }

        [Required(ErrorMessage = "O período de aulas deve ser informado")]
        [Display(Name = "Período das Aulas")]
        public string PeriodoAula { get; set; }

        public int EscolaId { get; set; }

        public int QuantidadeAlunos { get; set; }

        public virtual Escola Escola { get; set; }

        public List<Aluno> Alunos { get; set; }

    }
}
