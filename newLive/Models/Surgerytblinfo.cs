﻿namespace newLive.Models;

public partial class Surgerytblinfo
{
    public DateTime? SurgeryDate { get; set; }

    public string? SurgeryRoom { get; set; }

    public double? SurgeryTime { get; set; }

    public string? SurgeryType { get; set; }

    public string? DoctorIdName { get; set; }

    public int PatientId { get; set; }
}
