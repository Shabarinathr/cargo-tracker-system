namespace CargoTracker.Models;

public class Vessel
{
    public int Id { get; set; }
    public string IMO { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int CapacityTEU { get; set; }
    public string CurrentPort { get; set; } = string.Empty;
    public VesselStatus Status { get; set; }
}

public enum VesselStatus 
{ 
    Idle, InPort, AtSea, Maintenance 
}

public class CreateVesselDto
{
    public string IMO { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int CapacityTEU { get; set; }
    public string CurrentPort { get; set; } = string.Empty;
    public VesselStatus Status { get; set; }
}
