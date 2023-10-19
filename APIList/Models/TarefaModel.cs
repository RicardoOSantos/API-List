using APIList.Enum;
using System.ComponentModel.DataAnnotations;

namespace APIList.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
            public string Tarefa { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
            public string Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
