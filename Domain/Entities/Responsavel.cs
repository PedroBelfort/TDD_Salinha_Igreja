using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Responsavel
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public bool IsCrente { get; private set; }
        public IList<Crianca> Criancas { get; private set; }


        public Responsavel(string nome, bool isCrente)
        {
            ValidarNome(nome);
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            IsCrente = isCrente;
            Criancas = new List<Crianca>();
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ValidationException("Nome não pode ser nulo");
        }

        public void Converter()
        {
            if(!this.IsCrente)
                this.IsCrente = true;
        }

        public List<Crianca> GetCriancas()
        {
            return this.Criancas.ToList();
        }



    }
}
