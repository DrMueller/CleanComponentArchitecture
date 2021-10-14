using System.Collections.Generic;
using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Roles;

namespace Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Organisations
{
    public class Organisation : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}