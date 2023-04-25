﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySP1_Cantallops
{
    public class ClsRepuesto
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public decimal precio { get; set; }

        public string origen { get; set; }

        public List<ClsRepuesto> Listado { get; set; }
    }
}
