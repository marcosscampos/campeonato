using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Campeonato.Domain.Entities
{
    public class Team : Entity
    {
        [Required]
        [Display(Name = "Nome do Time")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Quantidade de gols")]
        public int QuantidadeDeGols { get; set; }

        //Foreing Key

        public long DepartureId { get; set; }

        [ForeignKey(nameof(DepartureId))]
        public Departure Departure { get; set; }
    }
}
