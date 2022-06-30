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
        public NotaFiscal Constroi()
        {
            return new NotaFiscal(RazaoSocial, Cnpj, Data, valorTotal, impostos, todosItens, Observacoes);
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
        public CriadorDeNotaFiscal NaDataAtual()
        {
            this.Data = DateTime.Now;
            return this;
        }
    }
}
