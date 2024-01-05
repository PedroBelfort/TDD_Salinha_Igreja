using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Salinha
    {
      
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Professor professor { get; private set; }
        public int IdadeMinima { get; private set; }
        public int IdadeMaxima { get; private set; }
        public IList<Crianca> criancas { get; private set; }

        public Salinha( string nome, Professor professor, int idadeMinima, int idadeMaxima)
        {
            Id = new Guid();
            Nome = nome;
            this.professor = professor;
            IdadeMinima = idadeMinima;
            IdadeMaxima = idadeMaxima;
            this.criancas = new List<Crianca>();
        }
        public void AdicionarCrianca(Crianca crianca)
        {
            this.criancas.Add(crianca);
        }

        public void RemoverCrianca(Crianca crianca)
        {
            if (this.criancas.Count() > 0)
            {
                this.criancas.Remove(crianca);
            }
            else
            {
                throw new ArgumentException("Sala Vazia");
            }
        }
    }
}
