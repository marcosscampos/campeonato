using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Campeonato.Domain.Entities
{
    public class Departure : Entity
    {
        public Departure() => Teams = new HashSet<Team>();
        public ICollection<Team> Teams { get; set; }

        //Classes

        [Required]
        public string Partida { get; set; }
    }
}
