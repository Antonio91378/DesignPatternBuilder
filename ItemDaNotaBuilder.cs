namespace NotaFiscal
{
    public class ItemDaNotaBuilder
    {
        public string Nome { get; set; }
        public double Valor { get; set; }

        public ItemDaNotaBuilder AdicionaNome(string nome)
        {
            this.Nome = nome;
            return this;
        }
        public ItemDaNotaBuilder AdicionaValor(double valor)
        {
            this.Valor = valor;
            return this;
        }
        public ItemDaNota Build()
        {
            return new ItemDaNota(Nome, Valor);
        }
    }
}