using System;
using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainServices.UnitOfWorks;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.CreateIndividual.Dtos;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Individuals;
using Mmu.Cca.CrossCutting.Areas.Logging.Services;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.CreateIndividual.Interactors.Implementation
{
    public class CreateIndividualInteractor : ICreateIndividualInteractor
    {
        private readonly ILoggingService _loggingService;
        private readonly IUnitOfWorkFactory _uowFactory;

        public CreateIndividualInteractor(
            ILoggingService loggingService,
            IUnitOfWorkFactory uowFactory)
        {
            _loggingService = loggingService;
            _uowFactory = uowFactory;
        }

        public async Task<CreateIndividualResultDto> ExecuteAsync(CreateIndividualRequestDto dto)
        {
            _loggingService.LogInformation("Creating new Individual..");

            var individual = new Individual
            {
                BirthDate = dto.BirthDate,
                FirstName = dto.FirstName + " " + Guid.NewGuid(),
                Gender = dto.Gender,
                LastName = dto.LastName + " " + Guid.NewGuid()
            };

            using (var uow = _uowFactory.Create())
            {
                var individualRepo = uow.GetGenericRepository<Individual>();
                await individualRepo.UpsertAsync(individual);
                await uow.SaveAsync();
            }

            _loggingService.LogInformation("Individual created");

            return new CreateIndividualResultDto
            {
                IndividualId = individual.Id
            };
        }
    }
}