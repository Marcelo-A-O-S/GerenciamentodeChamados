using System.ComponentModel.DataAnnotations;

namespace gerenciamentodechamados.Models
{
    public class Chamado
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tecnico { get; set; }
        public DateTime dataDeVencimento { get; set; }
        public string nivelPrioridade { get; set; }
        public string status { get; set; }
        public string notas { get; set;  }
        public DateTime dataDeConclusao { get; set; }
        public string tipoDeManutenção { get; set; }
        public Chamado()
        {

        }
        public Chamado(int id, string nome, string descricao, string tecnico, DateTime dataDeVencimento, string nivelPrioridade, string status, string notas, DateTime dataDeConclusao, string tipoDeManutenção)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Tecnico = tecnico;
            this.dataDeVencimento = dataDeVencimento;
            this.nivelPrioridade = nivelPrioridade;
            this.status = status;
            this.notas = notas;
            this.dataDeConclusao = dataDeConclusao;
            this.tipoDeManutenção = tipoDeManutenção;
        }
    }

}
