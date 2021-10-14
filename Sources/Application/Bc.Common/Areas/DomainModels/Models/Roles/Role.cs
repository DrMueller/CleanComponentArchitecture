using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Individuals;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Organisations;

namespace Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Roles
{
    public class Role : EntityBase
    {
        public string Description { get; set; }

        public Individual Individual { get; set; }

        public Organisation Organisation { get; set; }
    }
}