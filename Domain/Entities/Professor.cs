using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Professor
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        public IList<Salinha> Salinhas { get; private set; }

        public Professor(string nome)
        {
            ValidarNome(nome);
            Nome = nome;
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ValidationException("O nome não pode ser nulo");
        }


    }


}
