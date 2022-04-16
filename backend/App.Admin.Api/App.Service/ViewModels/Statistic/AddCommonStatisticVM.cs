namespace App.Service.ViewModels.Statistic
{
    public class AddCommonStatisticVM
    {
        public EventTimeStatisticVM EventTimeStatistic { get; set; }
        public int EventTimeStatisticId { get; set; }
        public int BallPossession { get; set; }
        public int GoalAttempts { get; set; }
        public int ShotsOnGoal { get; set; }
        public int ShotsOffGoal { get; set; }
        public int BlockedShots { get; set; }
        public int CornerKicks { get; set; }
        public int FreeKicks { get; set; }
        public int Offsides { get; set; }
        public int Throwin { get; set; }
        public int GoalkeeperSaves { get; set; }
        public int Fouls { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int TotalPasses { get; set; }
        public int CompletedPasses { get; set; }
        public int Trackles { get; set; }
        public int Attacks { get; set; }
        public int DangerousAttacks { get; set; }
    }
}
