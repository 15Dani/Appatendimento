using System;
using System.Collections.Generic;
using System.Text;

namespace Appatendimento
{
   public class Cliente
    {
        public string Nome { get; set; }
        public int Cpf { get; set; }

        public int Tempo_de_Atendimento_previsto { get; set; }

        public int Intervalor_de_leitura_seguir { get; set; }
    }
}
