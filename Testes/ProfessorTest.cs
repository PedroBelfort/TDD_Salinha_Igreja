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
    public class ProfessorTest
    {
        private readonly Fixture fixture;
        public ProfessorTest()
        {
            this.fixture = new Fixture();
        }

        [Fact]
        public void Professor_Should_Be_Valid()
        {
            //Arrange 
            var nome = this.fixture.Create<string>();

            //Act
            Action action = () => new Professor(nome);

            //Assert
            action.Should().NotThrow<ValidationException>();
        }

        [Fact]
        public void Professor_Should_Not_Be_Valid()
        {
            //Arrange 
            var nome = string.Empty;

            //Act
            Action action = () => new Professor(nome);

            //Assert
            action.Should().Throw<ValidationException>();
        }
    }
}
