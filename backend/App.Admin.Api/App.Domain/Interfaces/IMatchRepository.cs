﻿using App.Models;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IMatchRepository
    {
        Task<int> AddAsync(Match match);
        Task<Match> GetByMatchNumerAsync(int id, int competitionId);
        Task<Match> GetAsync(int id);
    }
}
