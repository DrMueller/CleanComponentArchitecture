using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Specs;
using Xunit;

namespace Mmu.CleanArchitecture.UseCases.UnitTests.TestingAreas.Areas.Individuals.LoadAllIndividuals.Specifications
{
    public class LoadAllIndividualsSpecificationUnitTests
    {
        private readonly LoadAllIndividualsSpec _sut;

        public LoadAllIndividualsSpecificationUnitTests()
        {
            _sut = new LoadAllIndividualsSpec();
        }

        [Fact]
        public void Applying_LoadsAllIndividuals()
        {
            // Arrange
            var individuals = new List<Individual>
            {
                new(),
                new(),
                new()
            };

            // Act
            var actualResult = _sut.Apply(individuals.AsQueryable()).ToList();

            // Assert
            actualResult.Count.Should().Be(individuals.Count);
            actualResult.Should().ContainInOrder(individuals);
        }

        [Fact]
        public void Applying_SortsByFirstName()
        {
            // Arrange
            var individualA = new Individual
            {
                FirstName = "A"
            };

            var individualB = new Individual
            {
                FirstName = "B"
            };

            var individualC = new Individual
            {
                FirstName = "C"
            };

            var individuals = new List<Individual>
            {
                individualA,
                individualC,
                individualB
            };

            // Act
            var actualResult = _sut.Apply(individuals.AsQueryable()).ToList();

            // Assert
            actualResult.ElementAt(0).Should().Be(individualA);
            actualResult.ElementAt(1).Should().Be(individualB);
            actualResult.ElementAt(2).Should().Be(individualC);
        }

        [Fact]
        public void Selector_MapsEntries()
        {
            // Arrange
            var individual = new Individual
            {
                FirstName = "Matthias",
                LastName = "Müller",
                Gender = Gender.Male,
                BirthDate = new DateTime(1986, 12, 29)
            };

            // Act
            var actualResult = _sut.Selector.Compile().Invoke(individual);

            // Assert
            actualResult.BirthDate.Should().Be(individual.BirthDate);
            actualResult.FirstName.Should().Be(individual.FirstName);
            actualResult.LastName.Should().Be(individual.LastName);
            actualResult.GenderDescription.Should().Be(IndividualResultDto.GenderMale);
        }
    }
}