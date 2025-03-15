﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entites
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Result { get; set; }
        public virtual int PlayerId { get; set; }
    }
}
