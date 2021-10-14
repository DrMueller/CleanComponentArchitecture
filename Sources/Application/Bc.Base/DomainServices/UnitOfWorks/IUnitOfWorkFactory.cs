namespace Mmu.Cca.Bc.Base.DomainServices.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}