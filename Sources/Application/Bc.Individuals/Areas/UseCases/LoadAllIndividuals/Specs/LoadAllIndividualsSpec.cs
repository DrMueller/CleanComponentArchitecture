using System;
using System.Linq;
using System.Linq.Expressions;
using Mmu.Cca.Bc.Base.DomainModels.Specs;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadAllIndividuals.Dtos;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Individuals;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadAllIndividuals.Specs
{
    internal class LoadAllIndividualsSpec : ISpecification<Individual, IndividualResultDto>
    {
        public Expression<Func<Individual, IndividualResultDto>> Selector
        {
            get
            {
                return ind => new IndividualResultDto
                {
                    BirthDate = ind.BirthDate,
                    FirstName = ind.FirstName,
                    GenderDescription = ind.Gender == Gender.Male ? IndividualResultDto.GenderMale : IndividualResultDto.GenderFemale,
                    LastName = ind.LastName,
                    IndividualId = ind.Id
                };
            }
        }

        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry.OrderBy(f => f.FirstName);
        }
    }
}