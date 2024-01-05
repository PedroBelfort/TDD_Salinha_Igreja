using AutoFixture;
using Bogus;
using Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    public class CriancaTest
    {
        private readonly Fixture fixture;

        public CriancaTest()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void Should_Be_Valid()
        {
            //Arrange
            var identificador = fixture.Create<Guid>();
            var nome = fixture.Create<string>();
            var isCrente = fixture.Create<bool>();
            var dataDeNascimento = fixture.Create<DateTime>();
            var sala = fixture.Create<Salinha>();
            var responsavel = fixture.Create<Responsavel>();

            //Act 
            Action action = () => new Crianca(nome, isCrente, dataDeNascimento, sala, responsavel);

            //Assert 
            action.Should().NotThrow<ValidationException>();
            
        }

        [Fact]
        public void Invalid_Constructor_Crianca_Should_Throw_Validation_Exception()
        {
            //Arrange
            var identificador = fixture.Create<Guid>();
            var nome = string.Empty;
            var isCrente = fixture.Create<bool>();
            var dataDeNascimento = fixture.Create<DateTime>();
            var sala = fixture.Create<Salinha>();
            var responsavel = fixture.Create<Responsavel>();

            //Act 
            Action action = () => new Crianca(nome, isCrente, dataDeNascimento, sala, responsavel);

            //Assert 
            action.Should().NotThrow<ValidationException>();
        }


        [Fact]
        public void Should_GetGetIdade()
        {
            //Arrange
            var dataAtual = DateTime.Now;
            var identificador = fixture.Create<Guid>();
            var nome = fixture.Create<string>();
            var isCrente = fixture.Create<bool>();
            var dataDeNascimento = dataAtual.AddYears(- new Random().Next(10));
            var sala = fixture.Create<Salinha>();
            var responsavel = fixture.Create<Responsavel>();
    
            var crianca = new Crianca(nome, isCrente, dataDeNascimento, sala, responsavel);

            //Act 
            var idade = crianca.GetIdade();

            //Assert
            idade.Should().Be(dataAtual.Year - crianca.DataDeNascimento.Year);
            
        }

        [Fact]
        public void Should_Convert_Crianca()
        {
            //Arrange
            var dataAtual = DateTime.Now;
            var identificador = fixture.Create<Guid>();
            var nome = fixture.Create<string>();
            var isCrente = false;
            var dataDeNascimento = dataAtual.AddYears(-new Random().Next(10));
            var sala = fixture.Create<Salinha>();
            var responsavel = fixture.Create<Responsavel>();

            var crianca = new Crianca(nome, isCrente, dataDeNascimento, sala, responsavel);


            //Act 
            crianca.Converter();

            //Assert
            crianca.IsCrente.Should().BeTrue();
        }

    }
}
