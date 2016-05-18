using System;
using System.Globalization;
using System.Text;

namespace Locadora.Dominio
{
    public class Jogo : EntidadeBase
    {
        public string Nome { get; set; }

        public Categoria Categoria { get; set; }

        public Cliente ClienteLocacao { get; private set; }

        public int? IdCliente { get; set; }

        public string Descricao { get; set; }

        public Selo Selo { get; set; }

        public string Imagem { get; set; }

        public string Video { get; set; }

        public DateTime? DataDevolucao { get; set; }

        public decimal ValorLocacao { get { return this.GerarValorDaLocacao(); } }

        public Jogo()
        {

        }

        public Jogo(int id, Cliente cliente = null)
        {
            this.Id = id;
            this.ClienteLocacao = cliente;
        }

        public decimal GerarValorDaLocacao()
        {
            var dataAtual = DateTime.Now;
            int diasAtraso = (dataAtual - this.DataDevolucao).Value.Days;
            if (this.Selo == Selo.Bronze)
            {
                if(diasAtraso > 0)
                {
                    return 5 + 5 * diasAtraso;
                }
                return 5;
            }
            else if (this.Selo == Selo.Prata)
            {
                if (diasAtraso > 0)
                {
                    return 10 + 5 * diasAtraso;
                }
                return 10;
            }
            else
            {
                if (diasAtraso > 0)
                {
                    return 15 + 5 * diasAtraso;
                }
                return 15;
            }
        }

        public void LocarPara(Cliente cliente)
        {
            this.ClienteLocacao = cliente;
        }
        public void Devolver()
        {
            this.ClienteLocacao = null;
            this.IdCliente = null;
            this.DataDevolucao = null;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Id: " + this.Id);
            builder.AppendLine("Nome: " + this.Nome);
            builder.AppendLine("Categoria: " + this.Categoria);
            builder.AppendLine("Selo: " + this.Selo);
            builder.AppendLine("Imagem: " + this.Imagem);
            builder.AppendLine("Video: " + this.Video);

            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() == typeof(Jogo))
            {
                Jogo jogoComp = (Jogo)obj;

                return this.Id == jogoComp.Id
                    && this.Nome == jogoComp.Nome
                    && this.Categoria == jogoComp.Categoria
                    && this.ClienteLocacao == jogoComp.ClienteLocacao
                    && this.Selo == jogoComp.Selo
                    && this.Imagem == jogoComp.Imagem
                    && this.Video == jogoComp.Video;
            }

            return false;
        }
    }
}
