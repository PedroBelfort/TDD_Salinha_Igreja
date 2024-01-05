using AutoFixture;
using Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    public class ResponsavelTest
    {
        private readonly Fixture fixture;
        public ResponsavelTest()
        {
            this.fixture = new Fixture();     
        }

        [Fact]
        public void Responsavel_Should_Be_Valid()
        {
            //Arrange 
            var nome = this.fixture.Create<string>();
            var isCrente = this.fixture.Create<bool>();

            //Act
            Action act = () => new Responsavel(nome, isCrente);

            //Assert 
            act.Should().NotThrow<ValidationException>();
        }

        [Fact]
        public void Responsavel_Should_Not_Be_Valid()
        {
            //Arrange 
            var nome = string.Empty;
            var isCrente = this.fixture.Create<bool>();

            //Act
            Action act = () => new Responsavel(nome, isCrente);

            //Assert 
            act.Should().Throw<ValidationException>();
        }

        [Fact]
        public void Should_Get_Criancas_de_Responsavel()
        {
            //Arrange 
            var nome = this.fixture.Create<string>();
            var isCrente = this.fixture.Create<bool>();

            var responsavel = new Responsavel(nome, isCrente);

            var dataAtual = DateTime.Now;
            var nomeCrianca = fixture.Create<string>();
            var isCrenteCrianca = fixture.Create<bool>();
            var dataDeNascimento = dataAtual.AddYears(-new Random().Next(10));
            var sala = fixture.Create<Salinha>();
            var responsavelDaCrianca = responsavel;
            var crianca = new Crianca(nomeCrianca, isCrente, dataDeNascimento, sala, responsavel);

            responsavel.Criancas.Add(crianca);
          
            var numeroDeCriancas = responsavel.Criancas.Count();

            //Act 
            var criancasDoResponsavel = responsavel.GetCriancas();

            //Assert
            criancasDoResponsavel.Count().Should().Be(numeroDeCriancas);

        }

        [Fact]
        public void Should_Converter_Responsavel()
        {
            //Arrange 
            var nome = this.fixture.Create<string>();
            var isCrente = false;

            var responsavel = new Responsavel(nome, isCrente);

            //Act 
            responsavel.Converter();

            //Assert
            responsavel.IsCrente.Should().BeTrue(); 
        }
    }
}
