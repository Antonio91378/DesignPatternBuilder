using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscal
{
    public class CriadorDeNotaFiscal
    {
        public DateTime Data { get; set; }
        public string Cnpj { get; private set; }
        public string RazaoSocial { private get; set; }
        public string Observacoes { private get; set; }
        private double valorTotal;
        private double impostos;
        private List<ItemDaNota> todosItens = new List<ItemDaNota>();
        private List<AcoesPosCriacaoDeNota> acoes = new List<AcoesPosCriacaoDeNota>();
        public NotaFiscal Constroi()
        {
            if (Data == null)
            {
                Data = DateTime.Now;
            }
            NotaFiscal nf = new NotaFiscal(RazaoSocial, Cnpj, Data, valorTotal, impostos, todosItens, Observacoes);

            foreach (var acao in acoes)
            {
                acao.acao(nf);
            }
            return nf;
        }
        public void AdicionaAcao(AcoesPosCriacaoDeNota novaAcao)
        {
            acoes.Add(novaAcao);
        }
        public CriadorDeNotaFiscal ParaEmpresa(string razaoSocial)
        {
            this.RazaoSocial = razaoSocial;
            return this;
        }
        public CriadorDeNotaFiscal ComCnpj(string cnpj)
        {
            this.Cnpj = cnpj;
            return this;
        }
        public CriadorDeNotaFiscal ComItem(ItemDaNota item)
        {
            todosItens.Add(item);
            valorTotal += item.Valor;
            impostos += item.Valor * 0.05;
            return this;
        }
        public CriadorDeNotaFiscal ComObservacoes(string observacoes)
        {
            this.Observacoes = observacoes;
            return this;
        }
        public CriadorDeNotaFiscal NaData(DateTime data)
        {
            this.Data = data;
            return this;
        }
    }
}
