
namespace NotaFiscal
{
    public class program
    {
        //Programa que utiliza o Design Pattern 'Builder'
        static void Main(string[] args)
        {
            var criador = new CriadorDeNotaFiscal();
            var itemBuilder = new ItemDaNotaBuilder();
            //Utilizando metodo de criacao 'Fluent Interface', tambem chamado de
            //'Method Chaining' para encadear metodos na criacao de um objeto
            itemBuilder.AdicionaNome("item1").AdicionaValor(200);
            itemBuilder.AdicionaNome("item2").AdicionaValor(400);

            ItemDaNota itemN = itemBuilder.Build();
            ItemDaNota itemN2 = itemBuilder.Build();

            criador
            .ParaEmpresa("odtos ensino e inovacao")
            .ComCnpj("23,234,345/0001-12")
            .ComItem(itemN)
            .ComItem(itemN2)
            .ComObservacoes("usuario com deficiencia");
            criador.AdicionaAcao(new EnviarEmail());
            criador.AdicionaAcao(new SalvarBd());
            NotaFiscal nf = criador.Constroi();
            Console.WriteLine(nf.ValorBruto);
        }
    }
}
