using System.ComponentModel.DataAnnotations.Schema;

namespace CargoTracker.Models
{
    public class Container 
    {
        public int Id { get; set; }
        public string ContainerNumber { get; set; } = "";
        public int VesselId { get; set; }
        [ForeignKey("VesselId")]
        public Vessel? Vessel { get; set; }
    }
}
