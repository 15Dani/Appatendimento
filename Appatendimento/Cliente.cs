namespace Appatendimento
{
    public class Cliente
   {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int Tempo_de_Atendimento_previsto { get; set; }
        public int Intervalor_de_leitura_seguir { get; set; }

        public Cliente proximo;

        public Cliente( string cpf, string nome, int tempo_de_Atendimento_previsto, int intervalor_de_leitura_seguir)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Tempo_de_Atendimento_previsto = tempo_de_Atendimento_previsto;
            this.Intervalor_de_leitura_seguir = intervalor_de_leitura_seguir;
            proximo = null;
        }
    }
}
