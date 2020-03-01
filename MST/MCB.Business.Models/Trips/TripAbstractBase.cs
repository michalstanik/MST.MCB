using System.ComponentModel.DataAnnotations;

namespace MCB.Business.Models.Trips
{
    public abstract class TripAbstractBase
    {
        /// <summary>
        /// The name of the Trip
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public TripType TripTypeAssesment { get; set; }

        public enum TripType
        {
            Empty,
            BussinessTrip,
            JustVisit,
            Transfer,
            RealTrip
        }
    }
}