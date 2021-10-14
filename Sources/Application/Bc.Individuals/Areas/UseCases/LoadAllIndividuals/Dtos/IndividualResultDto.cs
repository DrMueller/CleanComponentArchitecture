using System;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadAllIndividuals.Dtos
{
    public class IndividualResultDto
    {
        public const string GenderFemale = "Female";
        public const string GenderMale = "Male";

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string GenderDescription { get; set; }

        public string LastName { get; set; }

        public long IndividualId { get; set; }
    }
}