using System.Collections.Generic;

namespace MCB.Business.Models.Geo
{
    public class ContinentWithRegionsModel : ContinentModel
    {
        public List<RegionModel> Regions { get; set; }
    }
}
