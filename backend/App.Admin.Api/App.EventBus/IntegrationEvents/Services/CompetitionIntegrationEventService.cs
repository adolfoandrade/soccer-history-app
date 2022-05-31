using App.Domain.Interfaces;
using App.Domain.Models;
using App.Models;
using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.Services
{
    public class CompetitionIntegrationEventService : ICompetitionIntegrationEventService
    {
        private readonly IApiValueReferenceRepository _referenceRepository;
        private readonly ICompetitionRepository _competitionRepository;

        public CompetitionIntegrationEventService(IApiValueReferenceRepository referenceRepository,
            ICompetitionRepository competitionRepository)
        {
            _referenceRepository = referenceRepository;
            _competitionRepository = competitionRepository;
        }

        public async Task<bool> AddAsync(List<LeaguesResponseVM> vm)
        {
            foreach (var item in vm)
            {
                var has = await _referenceRepository.GetByApiIdAsync("COMPETITIONS", item.LeagueVM.Id);
                if (has == null)
                {
                    var competition = new Competition() { 
                        Country = item.CountryVM.Name, 
                        Name = item.LeagueVM.Name, 
                        Image = item.LeagueVM.Logo, 
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                    };
                    var competitionId = await _competitionRepository.AddAsync(competition);
                    var reference = new ApiValueReference() { 
                        TableReference = "COMPETITIONS", 
                        ApiName = "api-football", 
                        ApiId = item.LeagueVM.Id, 
                        AppId = competitionId 
                    };
                    await _referenceRepository.AddAsync(reference);
                }
            }
            return true;
        }

    }
}
