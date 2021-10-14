using System;

namespace Mmu.Cca.Bc.Base.DomainModels.Models
{
    public abstract class EntityBase
    {
        public DateTime CreatedDate { get; set; }
        public long Id { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}