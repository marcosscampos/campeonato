using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato.Client.Models
{
    public class CreateTeamViewModel
    {
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public int QuantidadeDeGols { get; set; }

        [Required]
        public long DepartureId { get; set; }

        public SelectList DepartureList { get; set; }
    }
}
