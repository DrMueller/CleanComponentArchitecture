using System;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Individuals;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.CreateIndividual.Dtos
{
    public class CreateIndividualRequestDto
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public string LastName { get; set; }
    }
}