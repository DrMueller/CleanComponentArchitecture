using System;
using System.Collections.Generic;
using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Roles;

namespace Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Individuals
{
    public class Individual : EntityBase
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public string LastName { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}