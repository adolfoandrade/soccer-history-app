using System.Collections.Generic;

namespace App.Service.ViewModels.SoccerEvent
{
    public class FilterEventResultVM
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<SoccerEventVM> Data { get; set; }
    }
}
