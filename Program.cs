
namespace NotaFiscal
{
    public class program
    {
        //Programa que utiliza o Design Pattern 'Builder'
        static void Main(string[] args)
        {
            var criador = new CriadorDeNotaFiscal();
            //Utilizando metodo de criacao 'Fluent Interface', tambem chamado de
            //'Method Chaining' para encadear metodos na criacao de um objeto
            criador
            .ParaEmpresa("odtos ensino e inovacao")
            .ComCnpj("23,234,345/0001-12")
            .ComItem(new ItemDaNota("item 1", 100.0))
            .ComItem(new ItemDaNota("item 2", 200.0))
            .NaDataAtual()
            .ComObservacoes("usuario com deficiencia");

            NotaFiscal nf = criador.Constroi();

            Console.WriteLine(nf.ValorBruto);
        }
    }
}
