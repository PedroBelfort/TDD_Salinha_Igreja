using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Crianca
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public bool IsCrente { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public Salinha Sala { get; private set; }
        public Responsavel Responsavel { get; private set; }

        public Crianca(string nome, bool isCrente, DateTime dataDeNascimento, Salinha sala, Responsavel responsavel)
        {
            ValidarNome(nome);
            ValidarResponsavel(responsavel);
            ValidarDataDeNascimento(dataDeNascimento);
            ValidarSala(sala);

            Id = new Guid();
            Nome = nome;
            IsCrente = isCrente;
            DataDeNascimento = dataDeNascimento;
            Sala = sala;
            Responsavel = responsavel;
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("O nome não pode ser nulo");

        }

        private void ValidarDataDeNascimento(DateTime dataDeNascimento)
        {
            if (dataDeNascimento > DateTime.Today || dataDeNascimento == default)
                throw new ValidationException("Data invalida");
        }

        private void ValidarResponsavel(Responsavel responsavel)
        {
            if (responsavel == null)
                throw new ValidationException("Responsavel não pode ser nulo");
        }

        private void ValidarSala(Salinha sala)
        {
            if (sala == null)
                throw new ValidationException("A Sala não pode ser nula");
        }

        public void Converter()
        {
            if (!IsCrente)
                IsCrente = true;
        }

        public int GetIdade()
        {
            var dataDeHoje = DateTime.Now;
            int idade = dataDeHoje.Year - DataDeNascimento.Year;
            return idade;
        }
    }
}
