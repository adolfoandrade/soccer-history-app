﻿using App.Service.ViewModels.SoccerTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.ViewModels.SoccerEvent
{
    public class EventTimeLineVM
    {
        public int Id { get; set; }
        public string Half { get; set; }
        public SoccerTeamVM SoccerTeam { get; set; }
        public TimeLineItemVM Item { get; set; }
    }
}
