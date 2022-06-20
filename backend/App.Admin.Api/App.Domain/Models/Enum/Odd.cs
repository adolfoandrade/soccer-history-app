using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models.Enum
{
    public enum Odd
    {
        MatchWinner = 1,
        HomeOrAway = 2,
        SecondHalfWinner = 3,
        AsianHandicap = 4,
        GoalsOverOrUnder = 5,
        GoalsOverOrUnderFirstHalf = 6,
        HTOrFTDouble = 7,
        BothTeamsScore = 8,
        HandicapResult = 9,
        ExactScore  = 10,
        HighestScoringHalf = 11,
        DoubleChance = 12,
        FirstHalfWinner = 13,
        TeamToScoreFirst = 14,
        TeamToScoreLast = 15,
        TotalHome = 16,
        TotalAway = 17,
        HandicapResultFirstHalf = 18,
        AsianHandicapFirstHalf = 19,
        DoubleChanceFirstHalf = 20,
        OddOrEven = 21,
        OddOrEvenFirstHalf = 22,
        HomeOddOrEven = 23,
        ResultsOrBothTeamsScore = 24,
        ResultOrTotalGoals = 25,
        GoalsOverOrUnderSecondHalf = 26,

        CornersOverUnder = 45
    }
}
