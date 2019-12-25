using System.Collections.Generic;

namespace MCB.Business.Models.Geo
{
    public class ContinentWithRegionsModel : ContinentModel
    {
        public List<RegionModelWithStats> Regions { get; set; }
    }
}
