﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Campeonato.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}
