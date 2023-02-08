using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PontoId_API.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "O nome do aluno deve ser informado")]
        [Display(Name = "Nome do Aluno")]
        public string NomeAluno { get; set; }

        [Required(ErrorMessage = "A idade do aluno deve ser informada")]
        [Display(Name = "Idade do Aluno")]
        public int IdadeAluno { get; set; }

        [Required(ErrorMessage = "O endereço do aluno deve ser informado")]
        [Display(Name = "Endereço do Aluno")]
        public string EnderecoAluno { get; set; }

        [Required(ErrorMessage = "O nome do responsável pelo aluno deve ser informado")]
        [Display(Name = "Responsável pelo Aluno")]
        public string ResponsavelAluno { get; set; }

        [Required(ErrorMessage = "Informe o telefone para contato")]
        [Display(Name = "Telefone para contato")]
        public string TelefoneAluno { get; set; }

        [Display(Name = "O aluno é maior de idade?")]
        public bool Maioridade { get; set; }

        [Display(Name = "Imagem do aluno")]
        public string FotoAluno { get; set; }

        public int EscolaId { get; set; }
        public int TurmaId { get; set; }
        public virtual Turma Turma { get; set; }

    }
}
