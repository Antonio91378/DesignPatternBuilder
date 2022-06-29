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
        public string Cnpj { get;private set; }
        public string RazaoSocial{ private get; set; }
        public string Observacoes { private get; set; }
        private double valorTotal;
        private double impostos;
        private List<ItemDaNota> todosItens = new List<ItemDaNota>();
        public void ParaEmpresa(string razaoSocial)
        {
            this.RazaoSocial = razaoSocial;
        }
        public void ComCnpj(string cnpj)
        {
            this.Cnpj = cnpj;
        }
        public void comItem(ItemDaNota item)
        {
            todosItens.Add(item);
            valorTotal += item.Valor;
            impostos += item.Valor * 0.05;
        }
        public void ComObservacoes(string observacoes)
        {
            this.Observacoes = observacoes;
        }
        public  void NaDataAtual()
        {
            this.Data = DateTime.Now;
        }
    }
}
