using System;
using System.Linq;
using System.Linq.Expressions;
using Mmu.Cca.Bc.Base.DomainModels.Models;

namespace Mmu.Cca.Bc.Base.DomainModels.Specs
{
    public interface ISpecification<TEntity, TResult> : ISpecification<TEntity>
        where TEntity : EntityBase
    {
        Expression<Func<TEntity, TResult>> Selector { get; }
    }

    public interface ISpecification<TEntity>
        where TEntity : EntityBase
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> qry);
    }
}