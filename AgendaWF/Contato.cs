using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaWF
{
    public class Contato {      // classe com modificador e acesso 'publc' onde todos podem ulilizar, classe 'Contato' representa um contato
        public int Id { get; set; }

        public int Nome { get; set; }       // propriedades

        public int Email { get; set; }
    }
}
