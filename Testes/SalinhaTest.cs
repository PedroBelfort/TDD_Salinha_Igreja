using AutoFixture;
using Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    public class SalinhaTest
    {
        private readonly Fixture fixture;

        public SalinhaTest()
        {
                this.fixture = new Fixture();
        }

        [Fact]
        public void Salinha_Instance_Should_Be_Valid()
        {
            //Arrange
            var nome = this.fixture.Create<string>();
            var professor = this.fixture.Create<Professor>();
            var idadeMinima = this.fixture.Create<int>();
            var idadeMaxima = this.fixture.Create<int>();
           
            //Act
            Action action = () => new Salinha(nome, professor, idadeMinima, idadeMaxima);

            //Assert
            action.Should().NotThrow<ValidationException>();
        }

        [Fact]
        public void Salinha_Should_Adicionar_Crianca()
        {
            //Arrange
            var nome = this.fixture.Create<string>();
            var professor = this.fixture.Create<Professor>();
            var idadeMinima = this.fixture.Create<int>();
            var idadeMaxima = this.fixture.Create<int>();
            var salinha = new Salinha(nome, professor, idadeMinima, idadeMaxima);

            var dataAtual = DateTime.Now;
            var identificador = fixture.Create<Guid>();
            var nomeCrianca = fixture.Create<string>();
            var isCrente = fixture.Create<bool>();
            var dataDeNascimento = dataAtual.AddYears(-new Random().Next(10));
            var sala = fixture.Create<Salinha>();
            var responsavel = fixture.Create<Responsavel>();

            var crianca = new Crianca(nomeCrianca, isCrente, dataDeNascimento, sala, responsavel);

            var quantidadeAnteriorDeAlunos = salinha.criancas.Count();
            //Act 
            salinha.AdicionarCrianca(crianca);

            //Assert 
            salinha.criancas.ToList().Count().Should().Be(quantidadeAnteriorDeAlunos +1);
        }

        [Fact]
        public void Salinha_Should_Remover_Crianca()
        {
            //Arrange
            var nome = this.fixture.Create<string>();
            var professor = this.fixture.Create<Professor>();
            var idadeMinima = this.fixture.Create<int>();
            var idadeMaxima = this.fixture.Create<int>();
            var salinha = new Salinha(nome, professor, idadeMinima, idadeMaxima);

            var dataAtual = DateTime.Now;
            var identificador = fixture.Create<Guid>();
            var nomeCrianca = fixture.Create<string>();
            var isCrente = fixture.Create<bool>();
            var dataDeNascimento = dataAtual.AddYears(- new Random().Next(1,10));
            var sala = fixture.Create<Salinha>();
            var responsavel = fixture.Create<Responsavel>();

            var crianca = new Crianca(nomeCrianca, isCrente, dataDeNascimento, sala, responsavel);
            salinha.AdicionarCrianca(crianca);
            salinha.AdicionarCrianca(crianca);

            var quantidadeAnteriorDeAlunos = salinha.criancas.Count();
            //Act 

            salinha.RemoverCrianca(crianca);

            //Assert 
            salinha.criancas.ToList().Count().Should().Be(quantidadeAnteriorDeAlunos -1 );
        }

        [Fact]
        public void Salinha_Should_Not_Remover_Crianca_De_Sala_Vazia()
        {
            //Arrange
            var nome = this.fixture.Create<string>();
            var professor = this.fixture.Create<Professor>();
            var idadeMinima = this.fixture.Create<int>();
            var idadeMaxima = this.fixture.Create<int>();
            var salinha = new Salinha(nome, professor, idadeMinima, idadeMaxima);

            var dataAtual = DateTime.Now;
            var identificador = fixture.Create<Guid>();
            var nomeCrianca = fixture.Create<string>();
            var isCrente = fixture.Create<bool>();
            var dataDeNascimento = dataAtual.AddYears(-new Random().Next(10));
            var sala = fixture.Create<Salinha>();
            var responsavel = fixture.Create<Responsavel>();

            var crianca = new Crianca(nomeCrianca, isCrente, dataDeNascimento, sala, responsavel);
            

            var quantidadeAnteriorDeAlunos = salinha.criancas.Count();
            //Act 

            Action action = () => salinha.RemoverCrianca(crianca);

            //Assert 
            action.Should().Throw<ArgumentException>().WithMessage("Sala Vazia");

        }

    }
}
